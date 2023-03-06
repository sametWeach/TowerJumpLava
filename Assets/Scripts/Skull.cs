using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] GameObject skBullet;
    [SerializeField] Transform tNokta;
    [SerializeField] public int healt = 100;
    [SerializeField] int alinanHasar = 50;
    Animator anim;
    Rigidbody2D rb;
    Score sr;
    float coolDown = 0;
    [SerializeField] float coolDownSuresi=3f;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = Score.instance;

    }


    void Update()
    {
        coolDown += Time.deltaTime;
        if (coolDown > coolDownSuresi && healt>1)
        {
            GameObject temp = Instantiate(skBullet);
            temp.transform.position =tNokta.position;
            coolDown = 0;
                 
        }

    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.gameObject.tag == "Bullet")
        {
            healt -= alinanHasar;
            Destroy(cl.gameObject);          

            if (healt <= 0)
            {
                Die();
            }

        }
    }


    void Die()
    {
        anim.SetBool("Death", true);
        Destroy(this.gameObject,1.5f);
        sr.enemy_score += 30;

    }





}
