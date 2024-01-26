using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSwap : MonoBehaviour
{
    public GameObject arSwap;
    public GameObject pistolSwap;
    public GameObject bmSword;

    // Update is called once per frame

    private void Start()
    {
        arSwap.SetActive(false);
        pistolSwap.SetActive(false);
        bmSword.SetActive(false);
    }


    void Update()
    {
        Ar();
        Pistol();
        BmMelee();
    }

    void Ar()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            arSwap.gameObject.SetActive(true);
            pistolSwap.gameObject.SetActive(false);
            bmSword.gameObject.SetActive(false);
        }
    }
    void Pistol()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            pistolSwap.gameObject.SetActive(true);
            arSwap.gameObject.SetActive(false);
            bmSword.gameObject.SetActive(false);
        }
    }

    void BmMelee()
    {
        if (Input.GetKey(KeyCode.Alpha3))
        {
            pistolSwap.gameObject.SetActive(false);
            arSwap.gameObject.SetActive(false);
            bmSword.gameObject.SetActive(true);

        }
    }

}
