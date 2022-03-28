using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    private bool canFire;
    //public int life = 2;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(canFire)
            {
                GameObject newBullett = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
                canFire = false;
                Invoke("CanShoot", 1f);
            }
        }
    }

    void CanShoot()
    {
        canFire = true;
    }
}
