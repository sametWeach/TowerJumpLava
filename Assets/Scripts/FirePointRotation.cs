using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointRotation : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject cross;
    [SerializeField] GameObject bulletPrefab;
    Vector3 mousePos;

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        cross.transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


        Vector3 targetDirection = mousePos - transform.position;
        float rotateZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ - 90f);


    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);

    }




}
