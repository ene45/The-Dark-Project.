using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject,2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}