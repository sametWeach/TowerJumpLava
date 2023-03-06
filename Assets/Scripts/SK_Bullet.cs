using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;
    public KýllObject ko;    

    void Start()
    {
        ko = GameObject.FindGameObjectWithTag("Ko").GetComponent<KýllObject>();       
        rb.velocity = -transform.up * speed;
        Destroy(this.gameObject, 2f);
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            
            ko.GameOverScreen.Setup();
        }
    }
}
