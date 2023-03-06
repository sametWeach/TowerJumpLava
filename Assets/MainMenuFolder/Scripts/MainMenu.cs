using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Animator animPlay,animOpt,animLevel;    
    [SerializeField]GameObject Opt;
    [SerializeField] AudioSource tasSes;


    private void Start()
    {
        animPlay = GameObject.FindGameObjectWithTag("btnPlay").GetComponent<Animator>();
        animOpt = GameObject.FindGameObjectWithTag("btnOpt").GetComponent<Animator>();
        animLevel = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<Animator>();

    }

    public void playGame()
    {
        tasSes.Play();
        animPlay.SetBool("startON", true);
        StartCoroutine(playOn());



    }
    public void options()
    {
        tasSes.Play();
        animOpt.SetTrigger("opt");
        StartCoroutine(optOn());

    }

    public void QuitGame()
    {
        Application.Quit();

    }
    public void btnBack()
    {
       
        animOpt.SetBool("optON", false);
        Opt.SetActive(false);
        this.gameObject.SetActive(true);
       


    }


    IEnumerator playOn()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(IGame());

    }

    IEnumerator IGame()
    {
        animLevel.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("IGAME");

    }
    IEnumerator optOn()
    {
        yield return new WaitForSeconds(0.8f);
        
        Opt.SetActive(true); 
        this.gameObject.SetActive(false);


    }
 


}
