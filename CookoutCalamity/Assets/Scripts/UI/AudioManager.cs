using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("---Audio Source ---")]
	[SerializeField] AudioSource musicSource;
	[SerializeField] AudioSource SFXSource;
	
	[Header("---Audio Clip - family ---")]
	public AudioClip TeenBored;
	public AudioClip TwinBored; 
	public AudioClip TeenReady;
	public AudioClip TwinReady;

	[Header("---Audio Clip - UI ---")]
	public AudioClip Fork;
	public AudioClip Plate;
	public AudioClip TakePlate;
	public AudioClip CountdownFor20;
	public AudioClip StaminaRep;
	public AudioClip GlassClink;
	public AudioClip Timer;

	public void PlaySFX(AudioClip clip)
	{
	SFXSource.PlayOneShot(clip);
	}









}
