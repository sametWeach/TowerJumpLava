using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawn : MonoBehaviour
{
    [SerializeField] GameObject skull;
    [SerializeField] GameObject surekli;
    [SerializeField] private float _speed;
    Score sr;
    int toplamScore;
    bool normal;
    bool hareketli;
    GameObject temp;
    GameObject temp2;
    public Transform maxSol;
    public Transform maxSag;
    bool moveRight;

    void Start()
    {
        sr = Score.instance;
        normal = true;
        hareketli = true;

        maxSol.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight / 2, maxSol.transform.position.z));

        maxSag.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, maxSag.transform.position.z));

    }


    void Update()
    {
        toplamScore = (sr.valueX + sr.enemy_score);

        if (toplamScore > 210) //400
        {
            while (normal == true)
            {
                // skullSpawn();
                temp = Instantiate(skull, surekli.transform.position, Quaternion.identity);
                normal = false;
            }
            if (temp != null)
            {
                temp.transform.position = new Vector3(0f, Camera.main.transform.position.y + 9, 0f);  //temp.transform.position.y + 0.02f

            }
            else
            {
                temp = null;
            }

        }


        if (toplamScore > 450 && temp == null)
        {
            while (hareketli == true)
            {

                temp2 = Instantiate(skull, surekli.transform.position, Quaternion.identity);
                hareketli = false;
            }
            if (temp2 != null)
            {
                temp2.transform.position = new Vector3(temp2.transform.position.x, Camera.main.transform.position.y + 9, 0f);  //temp.transform.position.y + 0.02f

                if (temp2.transform.position.x > maxSag.position.x -1f)
                {
                    moveRight = false;

                }
                if (temp2.transform.position.x < maxSol.position.x + 1f)
                {
                    moveRight = true;
                }

                if (moveRight)
                    temp2.transform.position = new Vector2(temp2.transform.position.x + _speed * Time.deltaTime, temp2.transform.position.y);
                else
                    temp2.transform.position = new Vector2(temp2.transform.position.x - _speed * Time.deltaTime, temp2.transform.position.y);


            }

        }

    }


}
