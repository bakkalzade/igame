using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletType;

    [HideInInspector]
    public static readonly int AMMO_LIMIT = 5;
    private int ammoCount = 5; //initial ammo count
    private int reloadTime = 4;
    private float coolDownTime = 0.1f;


    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(increaseAmmo());
        StartCoroutine(shoot());
    }
    // Update is called once per frame   
    IEnumerator shoot()
    {

        while (true)
        {

            if (Input.GetKey(KeyCode.Q))
            {
                bool reverse = false;
                if (Input.GetKey(KeyCode.DownArrow)) reverse = true;

                if (ammoCount != 0)
                {
                    ammoCount--;
                    controller.ammo = ammoCount;
                    GameObject bu = Instantiate(bulletType);

                    bu.transform.position = transform.position;

                    if (reverse)
                    {
                        if (sr.flipX == false) bu.GetComponent<bullet>().speed = -10;
                        else bu.GetComponent<bullet>().speed = 10;
                    }
                    else
                    {
                        if (sr.flipX == false) bu.GetComponent<bullet>().speed = 10;
                        else bu.GetComponent<bullet>().speed = -10;
                    }
                }
                Debug.Log("kalan kurþun sayýsý: " + ammoCount);

            }
            yield return new WaitForSeconds(coolDownTime);

        }

    }
    IEnumerator increaseAmmo()
    {

        while (true)
        {
            yield return new WaitForSeconds(reloadTime); 
            if (ammoCount < AMMO_LIMIT) ammoCount++;
            controller.ammo = ammoCount;
        }
    }

}
