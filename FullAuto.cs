using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullAuto : MonoBehaviour
{
    public Transform pelletSpawnPoint;
    public GameObject pelletPrefab;
    public Animator boltAnimator;
    public Animator magAnimator;
    public Animator chargingHandleAnimator;
    public float pelletSpeed = 200;
    public bool isFiring;
    public bool isReloading;
    public bool canFire = true;


    public Transform caseSpawnPoint;
    public GameObject casePrefab;
    public float caseSpeed = 3;


    float shotCounter;
    public float rateOfFire = 0.1f;

    public float Aika = 5f;
    public float reloadTime = 3.0f;
    public float reloadProgress = 0f;

    

    // Update is called once per frame
    void Update()
    {
        Aika -= Time.deltaTime;
        if (Aika <= 0)
        {
            Aika = 0.0f;
        }

        //shoot input
        if (Input.GetButton("Fire1") && canFire)
        {
            isFiring = true;
            boltAnimator.SetBool("isFiring", true);
        }
        else if (Input.GetButtonUp("Fire1") || !canFire)
        {
            isFiring = false;
            boltAnimator.SetBool("isFiring", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
        }

           

        if (isReloading)
        {
            canFire = false;
            magAnimator.SetBool("isMagChange", true);
            boltAnimator.SetBool("isFiring", false);
            chargingHandleAnimator.SetBool("isReloading", true);
            //aika
            if (reloadProgress >= reloadTime)
            {
                isReloading = false;
                canFire = true;

                magAnimator.SetBool("isMagChange", false);
                chargingHandleAnimator.SetBool("isReloading", false);

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

        var shell = Instantiate(casePrefab, caseSpawnPoint.position, caseSpawnPoint.rotation);
        shell.GetComponent<Rigidbody>().velocity = caseSpawnPoint.forward * caseSpeed;

    }
}
