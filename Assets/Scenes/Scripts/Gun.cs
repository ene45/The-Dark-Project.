using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float count;
    // Start is called before the first frame update
    void Start()
    {
        count = 15;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime; 
        if(Input.GetKeyDown("e") && count > 5)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            count = 0;
        }
    }
}
