using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject hareketliPlatform;
    public GameObject yokPlt;
    public GameObject mobPlt;
    public GameObject booster; 

    public int numberOfPlatforms;
    public float levelWidth = 2.75f;
    public float minY = 2.54f;
    public float maxY = 2.95f;

    private float spawnTimer;
    private float spawnTimerMax;
    private float A = 8;

    Score sr; 
    private void Awake()
    {
        sr = Score.instance;
        spawnTimerMax = .3f;


        for (int i = 0; i < numberOfPlatforms; i++)
        {
            yokSpawner();


            for (int t = 0; t < 1; t++)
            {
                enemySpawner();

                for (int p = 0; p < 1; p++)
                {
                    // enemySpawner();

                    for (int e = 0; e < 3; e++)
                    {
                        moverSpawner();

                        for (int j = 0; j < 3; j++)
                        {
                            platformSpawner();

                        }
                    }
                }


            }

        }


    }

    public void Update()
    {
        if (125 < sr.valueX)
        {
            minY = 5.54f;
            maxY = 5.95f;

        }
    }


    private void platformSpawner()
    {
        spawnTimer -= Time.deltaTime;


        if (spawnTimer < 0)
        {
            spawnTimer += spawnTimerMax;
            Vector3 spawnPosition = new Vector3();
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);   //  spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            A = A + spawnPosition.y;
            GameObject tem = Instantiate(platformPrefab, new Vector3(spawnPosition.x, A, 0), Quaternion.identity);

            if (Random.Range(0, 8) == 2)
            {
                //tutucu = Random.Range(spawnPosition.x-0.5f, spawnPosition.x +0.5f);
                GameObject temp = Instantiate(booster);
                temp.transform.position = new Vector3(tem.transform.position.x, A + 0.75f, 0);
               
            }

        }
    }

    private void moverSpawner()
    {
        spawnTimer -= Time.deltaTime;


        if (spawnTimer < 0)
        {
            spawnTimer += spawnTimerMax;
            Vector3 spawnPosition = new Vector3();
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            A = A + spawnPosition.y;
            Instantiate(hareketliPlatform, new Vector3(spawnPosition.x, A, 0), Quaternion.identity);

        }
    }

    private void yokSpawner()
    {
        spawnTimer -= Time.deltaTime;


        if (spawnTimer < 0)
        {
            spawnTimer += spawnTimerMax;
            Vector3 spawnPosition = new Vector3();
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            A = A + spawnPosition.y;
            Instantiate(yokPlt, new Vector3(spawnPosition.x, A, 0), Quaternion.identity);

        }
    }


    public void enemySpawner()
    {
        spawnTimer -= Time.deltaTime;


        if (spawnTimer < 0)
        {
            spawnTimer += spawnTimerMax;
            Vector3 spawnPosition = new Vector3();
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            A = A + spawnPosition.y;
            Instantiate(mobPlt, new Vector3(spawnPosition.x , A, 0), Quaternion.identity);

        }
    }




    private void OnTriggerEnter2D(Collider2D plt)
    {
        if (plt.gameObject.tag == "Platform")
        {

            for (int m = 0; m < 3; m++)
            {
                moverSpawner();

                for (int o = 0; o < 1; o++)
                {
                    platformSpawner();
                }




            }

            Destroy(plt.gameObject);

        }

        if (plt.gameObject.tag == "Booster")
        {
            Destroy(plt.gameObject);
        }


    }










}
