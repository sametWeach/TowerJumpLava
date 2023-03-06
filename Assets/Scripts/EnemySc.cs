using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySc : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] int ekscr=20;
    Animator anim;
    public KýllObject ko;
    Score sr;
   

    private void Start()
    {
        anim = GetComponent<Animator>();        
        ko = GameObject.FindGameObjectWithTag("Ko").GetComponent<KýllObject>();
  

        sr = Score.instance;
    }

    [Obsolete]
    private void OnTriggerEnter2D(Collider2D cl)
    {

        if (cl.transform.CompareTag("Player"))
        {
            Time.timeScale = 0;
     
            ko.GameOverScreen.Setup();        

        }

    }


    public void Die()
    {        
        hitSound.Play();
        anim.SetBool("IsDead", true);
        Destroy(gameObject, 0.5f);
        sr.enemy_score +=ekscr;       

    }   
}
