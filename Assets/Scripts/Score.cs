using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // public static Score instance { get; private set; }

    [SerializeField] public TextMeshProUGUI textScore;
    public static Score instance;

    public int _score = 0;
    public int valueX = 0;
    public int enemy_score = 0;
    public int toplamSkor = 0;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Instance of Inventory found");
            return;
        }

        instance = this;


    }

    void Update()
    {

        if (valueX < _score)
        {

            valueX = _score;

        }

        toplamSkor = valueX + enemy_score;

        textScore.text = toplamSkor.ToString();

        // en yüksek skor
        if (toplamSkor > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", toplamSkor);
        }


    }

}




