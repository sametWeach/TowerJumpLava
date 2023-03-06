using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{   
    private void Start()
    {
       
    }

    public void pauseMenuActivate()
    {
        gameObject.SetActive(true);
        
       

        Time.timeScale = 0;

    }

    public void resume()
    {      
        gameObject.SetActive(false);   
      
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene("IGAME");
        Time.timeScale = 1;
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;        
    }

    public void quit()
    {

        Application.Quit();
    }






    
}
