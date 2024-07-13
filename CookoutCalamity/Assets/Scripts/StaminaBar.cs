using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to reference slider
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{

    public Slider staminaBar;
    private int maxStamina=150;
    private int currentStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(.1f);

    public static StaminaBar instance;
    private Coroutine regen;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentStamina= maxStamina;
        staminaBar.maxValue=maxStamina;
        staminaBar.value=maxStamina;
    }
    public void UseStamina(int amount)
    {
         //Debug.Log("The current stamina " + currentStamina);
        //have enough stamina to perform that action
        if(currentStamina - amount >= 0)
        {
            //Debug.Log("Current move speed" + PlayerController.instance.moveSpeed);
            PlayerController.instance.moveSpeed=7f;
            currentStamina-=amount;
            staminaBar.value=currentStamina;

            if(regen!= null)
            //already regenerated stamina
            {
                //can stop

                StopCoroutine(regen);
                //reset to new instance
            }
            regen = StartCoroutine(RegenStamina());

        }
        else
        {
            if (currentStamina < 15)
            {
                PlayerController.instance.moveSpeed=1f;

            }
            
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(3f);
        while(currentStamina<maxStamina)
        {
            currentStamina += maxStamina/150;
            
            staminaBar.value=currentStamina;
    
            yield return regenTick;
        }
        regen=null;

    }

    // Update is called once per frame
    
}
