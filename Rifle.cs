using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rifle : MonoBehaviour
{
    public Transform pelletSpawnPoint;
    public GameObject pelletPrefab;
    
    public float pelletSpeed = 200;
    public bool isFiring;
    public bool isReloading;
    public bool canFire = true;

    public float ammunitionLeft;


    public AudioSource source;
    public AudioClip clip;

    float shotCounter;
    public float rateOfFire = 0.1f;

    public float Aika = 5f;
    public float reloadTime = 3.0f;
    public float reloadProgress = 0f;

    private void Start()
    {
        ammunitionLeft = 30;
    }

    // Update is called once per frame
    void Update()
    {



        if (ammunitionLeft <= 0)
        {
            canFire = false;
            
        }
            


       




        Aika -= Time.deltaTime;
        if (Aika <= 0)
        {
            Aika = 0.0f;
        }

        //shoot input
        if (Input.GetButton("Fire1") && canFire)
        {
            isFiring = true;
        }
        else if (Input.GetButtonUp("Fire1") || !canFire)
        {
            isFiring = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
        }



        if (isReloading)
        {
            canFire = false;
            source.PlayOneShot(clip);

            //aika
            if (reloadProgress >= reloadTime)
            {
                isReloading = false;
                canFire = true;
                ammunitionLeft = 30;


                reloadProgress = 0f;
            }
            else
            {
                reloadProgress += 1 * Time.deltaTime;
                
            }
        }

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter < 0)
            {
                shotCounter = rateOfFire;
                Shoot();
            }
        }
        else
        {
            shotCounter -= Time.deltaTime;
        }
    }
    private void Shoot()
    {
        var pellet = Instantiate(pelletPrefab, pelletSpawnPoint.position, pelletSpawnPoint.rotation);
        pellet.GetComponent<Rigidbody>().velocity = pelletSpawnPoint.forward * pelletSpeed;

        ammunitionLeft -= 1;

    }




}
