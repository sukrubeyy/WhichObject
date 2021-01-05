using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anaMenuScript : MonoBehaviour
{
   public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitButton()
    {
        Application.Quit();
    }

    public void SocialMediButton()
    {
        Application.OpenURL("https://www.instagram.com/sukru.beyy/");
    }
}
