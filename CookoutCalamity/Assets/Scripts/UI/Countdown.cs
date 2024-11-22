using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Countdown : MonoBehaviour
{
   // Start is called before the first frame update
   public int countdownTime;
   public TMP_Text countdownDisplay;
   public delegate void CountdownComplete();
   public static event CountdownComplete onCountdownComplete;


   private void Start()
   {
     
       StartCoroutine(CountdownStart());
   }
   IEnumerator CountdownStart()
   {
       while (countdownTime > 0)
       {
           countdownDisplay.text = countdownTime.ToString();
     
           yield return new WaitForSeconds(1f);


           countdownTime--;


       }
       countdownDisplay.text= "GO!";


       yield return new WaitForSeconds(1f);
       countdownDisplay.gameObject.SetActive(false);
       onCountdownComplete?.Invoke();
   }


}



