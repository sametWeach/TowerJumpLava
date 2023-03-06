using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.phase == TouchPhase.Began)
            {
                if (Camera.main.ScreenToWorldPoint(parmak.position).x > 0)
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, (Camera.main.ScreenToViewportPoint(parmak.position).x * -20) +20);
                    Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

                }
                else
                {
                    this.transform.rotation = Quaternion.Euler(0, 0, (Camera.main.ScreenToViewportPoint(parmak.position).x * 20) -2);
                    Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

                }



                // this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(parmak.position).x, Camera.main.ScreenToWorldPoint(parmak.position).y,0);



            }



        }

    }

}
