using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPltrm : MonoBehaviour
{    // New Moving Platform Code
    [SerializeField] private float _speed;
    bool moveRight;
    Score sr;

    private void Start()
    {
        sr = Score.instance;
    }

    void FixedUpdate()
    {

        if (transform.position.x > 2.9f)
        {
            moveRight = false;

        }
        if (transform.position.x < -2.9f)
        {
            moveRight = true;
        }

        if (moveRight)
            transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }




}
