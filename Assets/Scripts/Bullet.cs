using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;
 

    
    void Start()
    {
        rb.velocity = transform.up * speed;


    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        EnemySc enemySc =  cl.GetComponent<EnemySc>();

        if (enemySc != null)
        {
            enemySc.Die();
            
        } 
        Destroy(gameObject,2f);
    }


}
