using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{

    public GameObject bulletPrefab;
    public GameObject cannon;

    public float bulletSpeed;

    public float speed = 30;






    void Update() {
        if(IsLocalPlayer)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + (transform.forward * speed * Time.deltaTime), 0.1f);
            }
        

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - (transform.forward * speed * Time.deltaTime), 0.1f);
            }
        
            if (Input.GetKey(KeyCode.Q))
            {
                transform.rotation *= Quaternion.AngleAxis(-5 * speed * Time.deltaTime, Vector3.up);
            }
        
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation *= Quaternion.AngleAxis(5 * speed * Time.deltaTime, Vector3.up);
            }
        }
    }
}