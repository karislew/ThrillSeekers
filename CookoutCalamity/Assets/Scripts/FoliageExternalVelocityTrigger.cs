using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageExternalVelocityTrigger : MonoBehaviour
{
    private FoliageVelocityController foliageVelocityController;

    private GameObject _player;

    private Material _material;

    private Rigidbody2D _playerRB;

    private bool _easeInCoroutineRunning;
    private bool _easeOutCoroutineRunning;

    private int _externalInfluence = Shader.PropertyToID("_ExternalInfluence");

    private float _startingxVelocity;
    private float _velocityLastFrame;

    private void Start()
    {
        _player = Gameobject.FindGameObjectWithTag("Player");
        _playerRB = _player.GetComponent<Rigidbody2D>();
        _foliageVelocityController = GetComponentInParent<FoliageVelocityController>();

        _material = GetComponent<SpriteRenderer>().material;
        _startingxVelocity = _material.GetFloat(_externalInfluence);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == _player)
        {
            if (!_easeInCoroutineRunning && Mathf.Abs(_playerRB.velocity.x) > Mathf.Abs(_foliageVelocityController.VelocityThreshold))
          {
            StartCoroutine(EaseIn(_playerRB.velocity.x * _foliageVelocityController.ExternalInfluenceStrength));
        }  

        }
        
         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            StartCoroutine(EaseOut());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            if (Mathf.Abs(_velocityLastFrame) > Mathf.Abs(_foliageVelocityController.VelocityThreshold) && 
                Mathf.Abs(_playerRB.velocity.x) < Mathf.Abs(_foliageVelocityController.VelocityThreshold))
            {
                StartCoroutine(EaseOut());
            }

            else if (Mathf.Abs(_velocityLastFrame) < Mathf.Abs(_foliageVelocityController.VelocityThreshold) &&
                Mathf.Abs(_playerRB.velocity.x) > Mathf.Abs(_foliageVelocityController.VelocityThreshold))
            {
                StartCoroutine(EaseIn(_playerRB.velocity.x * _foliageVelocityController.ExternalInfluenceStrength));
            }

            else if (!_easeInCoroutineRunning && !_easeOutCoroutineRunning && 
                Mathf.Abs(_playerRB.velocity.x) > Mathf.Abs(_foliageVelocityController.VelocityThreshold))
            {
                _foliageVelocityController.InfluenceGrass(_material, _playerRB.velocity.x * _foliageVelocityController.ExternalInfluenceStrength);
            }

            _velocityLastFrame = _playerRB.velocity.x;
        }
    }

    private IEnumerator EaseIn(float xVelocity){
        _easeInCoroutineRunning = true;

        float elaspedTime = 0f;
        while(elaspedTime < _foliageVelocityController.EaseInTime)
        {
            elaspedTime += Time.deltaTime;

            float lerpedAmount = Mathf.Lerp(_startingxVelocity, xVelocity, (elaspedTime / _foliageVelocityController.EaseInTime));
            _foliageVelocityController.InfluenceGrass(_material, lerpedAmount);

            yield return null;
        }

        _easeInCoroutineRunning = false;

    }

        private IEnumerator EaseOut()
        {
            _easeOutCoroutineRunning = true;
            float currentXInfluence = _material.GetFloat(_externalInfluence);

            float elaspedTime = 0f;
            while(elaspedTime < _foliageVelocityController.EaseOutTime)
            {
                elaspedTime += Time.deltaTime;

                float lerpedAmount = Mathf.Lerp(currentXInfluence, _startingxVelocity, (elaspedTime / _foliageVelocityController.EaseOutTime));
                _foliageVelocityController.InfluenceGrass(_material, lerpedAmount);

                yield return null; 
            }

            _easeOutCoroutineRunning = false; 

        }
    }
