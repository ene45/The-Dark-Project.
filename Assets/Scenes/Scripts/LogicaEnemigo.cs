using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigo : MonoBehaviour
{
    private Animator enemigoAnimator;
    int life = 5;
    public GameObject bot;
    public CapsuleCollider mycollider;
    public GameObject particulasSangre;
    public Transform spawnSangre;
    
    private void Awake()
    {
        enemigoAnimator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Espada" || other.gameObject.tag == "Granada")
        { 
                enemigoAnimator.SetBool("Golpe" , true); 
                Instantiate(particulasSangre, spawnSangre.position, spawnSangre.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Espada" || other.gameObject.tag == "Granada")
             enemigoAnimator.SetBool("Golpe", false);

    }
}
