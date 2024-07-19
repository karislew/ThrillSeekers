using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScreen : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        //fail condition
        if (maxProgress -= 70 && gameTimer < 120)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("Lose Screen");
        }

        //win condition
        if (maxProgress = 100 && gameTimer != 0)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("Win Screen");
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu. . .");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    
}
