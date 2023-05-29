using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceOnSpawn : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private float fuerza;
    public void AplicarFuerza()
    {
        myRigidbody.AddForce(transform.forward * fuerza, ForceMode.Impulse);
    }
}
