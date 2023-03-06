using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //  [SerializeField] private AudioSource aa;
    // public static AudioManager instance;
    //public Score sr;
    Score sr;
    public AudioSource msc;
    void Awake()
    {
        sr = Score.instance;
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("ThemeMusic");

        if (musicObj.Length >1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
       

        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

        //DontDestroyOnLoad(gameObject);       
    }  


}
