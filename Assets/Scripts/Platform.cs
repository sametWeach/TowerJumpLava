using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float JumpForce = 13.5f;
    Rigidbody2D rb;
    public bool isGrounded;
    Score sr;
    int toplamSkor=0;
  // public Player py;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = Score.instance;
      //  py = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        toplamSkor = (sr.valueX + sr.enemy_score);

        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
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
               FindObjectOfType<Player>().JumpAwake();

            }
        }

    }

    

}
