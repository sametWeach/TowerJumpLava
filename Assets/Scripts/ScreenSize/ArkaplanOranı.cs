using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaplanOranı : MonoBehaviour
{
    private SpriteRenderer sr;
   // private Transform tr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
      //  tr = GetComponent<Transform>();

        // world height is always camera's orthographicSize * 2
        float worldScreenHeight = Camera.main.orthographicSize * 2;

        // world width is calculated by diving world height with screen heigh
        // then multiplying it with screen width
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // to scale the game object we divide the world screen width with the
        // size x of the sprite, and we divide the world screen height with the
        // size y of the sprite



        //3D PLANE İÇİN ARKAPLAN AYARLAMA

       // transform.localScale = new Vector3(worldScreenWidth / (tr.localScale.x * 7.3f), 1, tr.localScale.z);

       


        //STANDRART ARKAPLANLAR İÇİN EN BOY ORANI AYARLAMA KODU

        
        transform.localScale = new Vector3(
             worldScreenWidth / sr.sprite.bounds.size.x,
             worldScreenHeight / sr.sprite.bounds.size.y, 1);  




    }
}
