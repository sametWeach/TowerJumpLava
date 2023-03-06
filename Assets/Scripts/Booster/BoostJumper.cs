using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostJumper : MonoBehaviour
{
    public float JumpForce = 12f;
    Rigidbody2D rb;   
    Score sr;
    int toplamSkor=0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = Score.instance;
    }

    private void Update()
    {
        toplamSkor = (sr.enemy_score + sr.valueX);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;           


                if (toplamSkor < 500)
                {
                    velocity.y = JumpForce;

                }
                else if (toplamSkor < 800)
                {
                    velocity.y = JumpForce + 5;
                }
                else
                    velocity.y = JumpForce + 10;

                rb.velocity = velocity;
            }

        }
    }
}
