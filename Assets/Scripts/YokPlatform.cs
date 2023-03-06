using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokPlatform : MonoBehaviour
{

    [SerializeField] GameObject yokOlacakPlt;

    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            anim.SetBool("TemasEdildi", true);
            Destroy(gameObject, 1.5f);

        }





    }




    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Destroy(gameObject,1f);


    //    }
    //}








}
