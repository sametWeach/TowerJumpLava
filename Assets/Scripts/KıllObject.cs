using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KıllObject : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public Score sr;
    [SerializeField] float speed = 2f;
    public Transform nokta;
    public float distance = 20f;
    [SerializeField] AudioSource fire;


    private void Awake()
    {
        sr = Score.instance;

    }


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(nokta.position, transform.TransformDirection(Vector2.up), distance);  //transform.TransformDirection(Vector2.up)
        if (hit.collider != null)
        {
            // Vector2 forward = transform.TransformDirection(Vector2.up) * distance;
            Debug.DrawRay(nokta.position, transform.TransformDirection(Vector2.up) * distance, Color.green);

            //Debug.Log("var");

            if (hit.collider.tag == "Cizgi") //hit.distance <= 4f && 
            {
                // Debug.Log("var");
                transform.Translate(0, Time.deltaTime * speed / 80, 0);

            }
            else
            {
                transform.Translate(0, Time.deltaTime * speed / 10, 0);
            }

        }
        else
        {
            transform.Translate(0, Time.deltaTime * speed / 10, 0);
        }





    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.transform.CompareTag("Player"))
        {
            fire.Play();
            Time.timeScale = 0;
            GameOver();
        }
    }

    [System.Obsolete]
    public void GameOver()
    {
        
        GameOverScreen.Setup();
      
    }

}
