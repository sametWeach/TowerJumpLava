using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeOptions : MonoBehaviour
{
    public GameObject bgMscGo;
     AudioSource bgMusic;
    [SerializeField] Slider slider;
    [SerializeField] Slider soundsSlider;

    private void Awake()
    {
        bgMscGo = GameObject.FindWithTag("ThemeMusic");
        bgMusic = bgMscGo.GetComponent<AudioSource>();
       // slider = GameObject.FindGameObjectWithTag("ThmSlider").GetComponent<Slider>();
        //soundsSlider = GameObject.FindGameObjectWithTag("SndSlider").GetComponent<Slider>();
    }

    public void Start()
    {
        LoadAudio();
        LoadSounds();
    }


    // SADECE ARKAPLAN MÜZÝÐÝNÝ AYARLAMA KISMI

    public void SetAudio(float value)
    {
        bgMusic.volume = value;
        SaveAudio();

    }

    void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume", bgMusic.volume);

    }

    void LoadAudio()
    {
        if (PlayerPrefs.HasKey("audioVolume"))
        {
            bgMusic.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");

        }
        else
        {
            PlayerPrefs.SetFloat("audioVolume", 0.8f);
            bgMusic.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }


    }

    //BÜTÜN SESLERÝN AYARLANMASI YAPILAN KISIM

    public void SetSounds(float value)
    {
        AudioListener.volume = value;
        SaveSounds();

    }

    void SaveSounds()
    {
        PlayerPrefs.SetFloat("soundsVolume", AudioListener.volume);

    }

    void LoadSounds()
    {
        if (PlayerPrefs.HasKey("soundsVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("soundsVolume");
            soundsSlider.value = PlayerPrefs.GetFloat("soundsVolume");

        }
        else
        {
            PlayerPrefs.SetFloat("soundsVolume", 1);
            AudioListener.volume = PlayerPrefs.GetFloat("soundsVolume");
            soundsSlider.value = PlayerPrefs.GetFloat("soundsVolume");
        }


    }






}
