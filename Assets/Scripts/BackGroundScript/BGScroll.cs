using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    //{
    //    public float speed = 4f;
    //    private Vector3 startPosition;
    //    public GameObject Player;
    //    float vHiz = 1f;
    //    float sonHýz = 0f;
    //    float chHigh;
    //    public float yavasHiz = 10f;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeY;

    void Start()
    {
        // startPosition = transform.position;
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;

    }


    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * -1.05f;
        lastCameraPosition = cameraTransform.position;

        if (cameraTransform.position.y - transform.position.y >= textureUnitSizeY -1 )
        {
           // float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY ;
            transform.position = new Vector3(transform.position.x , cameraTransform.position.y);
        }

        
    }








    //void Update()
    //{

    //    if (vHiz < Player.transform.position.y)
    //    {
    //        vHiz = Player.transform.position.y;
    //    }

    //    if (sonHýz <= vHiz)
    //    {
    //        sonHýz = vHiz;

    //        transform.Translate(Vector3.down * speed * Time.deltaTime);
    //    }
    //    else
    //    {
    //        transform.Translate(Vector3.down * 0);
    //    }

    //    if (transform.position.y < (Player.transform.position.y - 5) )
    //    {
    //        transform.position = startPosition;


    //    }
    //    // chHigh = vHiz / yavasHiz;
    //}







}
