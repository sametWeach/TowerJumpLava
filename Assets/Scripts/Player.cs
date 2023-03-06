using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] public GameObject rPortalPreb;
    [SerializeField] public GameObject lPortalPreb;
    [SerializeField] public float movementSpeed = 35f;
    [SerializeField] private float _boundX;
    [SerializeField] private float _boundY;
    [SerializeField] public AudioSource JumpAudio;
    private AudioSource boosterAudio = null;
    public ParticleSystem dust;
    Rigidbody2D rb;
    Animator anim;
    float movement = 0f;

    //y�n kontrol
    private bool facingRight = true;

    //telefonda vekt�rel sa� sol yapabilmesi i�in
    public float dirX;

    //platforma temas ediyor mu kontrol
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] const float groundCheckRadius = 0.2f;
    [SerializeField] public bool isGrounded = false;

    // karakterin y de�erine ba�l� olarak skore tutulacak de�er - Score class�ndan sr �retme
    public Score sr;

    public Transform leftLimit;
    public Transform rightLimit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = Score.instance;
    }




    void Update()
    {
        //telefon i�in
        dirX = Input.acceleration.x * movementSpeed * 1.1f;




        // //hareket kodlar�

        movement = Input.GetAxis("Horizontal") * movementSpeed;

        // Skore bilgisi i�in karakterin y de�eri al�n�yor
        // Score.instance.Scoring = (int)transform.position.y;

        sr._score = (int)transform.position.y;

        anim.SetFloat("yVelocity", rb.velocity.y);

        //Score 500'den fazla ise karakterin h�z�n� 70f e ayarl�yoruz.

        if (600 < sr.valueX)
        {
            movementSpeed = 70f;
        }


    }

    private void FixedUpdate()
    {
        //  rb.velocity = new Vector2(dirX, 0f);

        Vector2 velocity = rb.velocity;
        //y�n tu�lar�
        //velocity.x = movement;

        //telefon sa� sol sens�r hareketi
        velocity.x = dirX;
        rb.velocity = velocity;


        //Flip(); //movement

        if (dirX < -2f || dirX > 1.8f)
        {
            FlipPhone();
        }


        GroundCheck();





        leftLimit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight / 2, leftLimit.transform.position.z));

        rightLimit.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, rightLimit.transform.position.z));



        //  karakterin sa�dan sola ge�i� yapmas�n� sa�l�yor //
        Vector3 temp = transform.position;
        if (temp.x > rightLimit.transform.position.x)
        {//sa�dan sola

            StartCoroutine(PortalR());
            transform.Translate(new Vector2(-2 * rightLimit.transform.position.x, 0));

        }
        else if (temp.x < leftLimit.transform.position.x)
        {//soldan sa�a
            StartCoroutine(PortalL());
            transform.Translate(new Vector2(2 * leftLimit.transform.position.x, 0));

        }



    }

    IEnumerator PortalR()
    {
        GameObject temp = Instantiate(rPortalPreb);
        temp.transform.position = new Vector3(rightLimit.transform.position.x - .5f, this.transform.position.y, 0); ; //portalPoint.position

        GameObject temp2 = Instantiate(lPortalPreb);
        temp2.transform.position = new Vector3(leftLimit.transform.position.x + .5f, this.transform.position.y, 0);

        yield return new WaitForSeconds(1.5f);
        Destroy(temp);
        Destroy(temp2);

    }

    IEnumerator PortalL()
    {
        GameObject temp = Instantiate(lPortalPreb);
        temp.transform.position = new Vector3(leftLimit.transform.position.x + .5f, this.transform.position.y, 0);

        GameObject temp2 = Instantiate(rPortalPreb);
        temp2.transform.position = new Vector3(rightLimit.transform.position.x - .5f, this.transform.position.y, 0);

        yield return new WaitForSeconds(1.5f);
        Destroy(temp);
        Destroy(temp2);


    }


    private void Flip() //float movement
    {

        if (movement < 0 && facingRight || movement > 0 && !facingRight)
        {

            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);

            /* Vector3 theScale = transform.localScale;
             theScale.x *= -1;
             transform.localScale = theScale; */
        }
    }

    private void FlipPhone() //float DirX
    {

        if (dirX < 0 && facingRight || dirX > 0 && !facingRight)
        {

            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);

            /* Vector3 theScale = transform.localScale;
             theScale.x *= -1;
             transform.localScale = theScale; */
        }
    }

    private void GroundCheck()
    {
        isGrounded = false;
        anim.SetBool("jump", false);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);

        if (colliders.Length > 0)
        {
            dustAwake();
            isGrounded = true;


            anim.SetBool("jump", true);
        }
    }


    void dustAwake()
    {

        dust.Play();
    }

    public void JumpAwake()
    {
        JumpAudio.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Booster")
        {
            boosterAudio = collision.gameObject.GetComponent<AudioSource>();
            boosterAudio.Play();
            Destroy(collision.gameObject,2f);
        }
    }


}
