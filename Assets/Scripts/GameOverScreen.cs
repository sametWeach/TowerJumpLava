using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI pointsText;
    [SerializeField] public TextMeshProUGUI highScore;
    [SerializeField] public Button button;
    Score sr;
    public gameGecisAdmob gecisAdmob;


    private void Awake()
    {
        //gameObject.SetActive(false);
        button = GetComponent<Button>();
        sr = Score.instance;

    }

    [System.Obsolete]
    public void Setup()
    {

       
        gameObject.SetActive(true);
        pointsText.text = (sr.valueX + sr.enemy_score).ToString() + " POINTS";
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        Time.timeScale = 0;
        gecisAdmob.GameOver();


    }

   
    public void RestartButton()
    {
       
        SceneManager.LoadScene("IGame");
        Time.timeScale = 1;
       
    }

    // Main menu Butonu
   
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1; 
       
    }
}
