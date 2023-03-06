using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject AtesBG;
    public GameObject BuzulBG;
    public Animator anim;
    int toplamSkor = 0;
    Score sr;
    bool sonuc;

    void Start()
    {
        sr = Score.instance;
        anim = GetComponent<Animator>();
        sonuc = true;

    }


    void Update()
    {
        toplamSkor = (sr.valueX + sr.enemy_score);

        if (toplamSkor > 35 && sonuc == true)
        {
            sonuc = false;
            // Debug.Log("0");
            LoadNextBG();



        }
    }

    void LoadNextBG()
    {
        
        StartCoroutine(LoadLevel());


    }
    IEnumerator LoadLevel()
    {
        anim.SetBool("Start",true);
        AtesBG.SetActive(false);
       
        yield return new WaitForSeconds(1f);

        BuzulBG.SetActive(true);
       
        //yield return null;


    }


}
