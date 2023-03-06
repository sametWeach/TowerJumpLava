using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject platformPrefab;
    //private Spawner sp;
    //public int numberOfPlatforms = 5;
    //public float levelWidth = 5f;
    //public float minY = 1.7f;
    //public float maxY = 2.6f;

    private void Start()
    {


    }



    private void OnTriggerEnter2D(Collider2D plt)
    {
        if (plt.gameObject.tag == "Platform")
        {
            Destroy(plt.gameObject);
        }

        


        //spawn();


    }
    //public void spawn()
    //{
    //    Vector3 spawnPosition = new Vector3();
    //   // spawnPosition.y = sp.transform.position.y;
    //    spawnPosition.y += Random.Range(minY, maxY);
    //    spawnPosition.x = Random.Range(-levelWidth, levelWidth);
    //    Instantiate(platformPrefab, spawnPosition, Quaternion.identity);


    //}

}
