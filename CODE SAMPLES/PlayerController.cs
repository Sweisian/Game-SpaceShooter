﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    public float nextFire;

    

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {          
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            GetComponent<AudioSource>().Play();
         }
    }


    void FixedUpdate ()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        GetComponent<Rigidbody>().velocity = speed * movement;

        GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
    }
}