using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    [SerializeField] private BoxCollider espada;

    private void Start()
    {
        DesactivarCollidersArmas();
    }

    public void ActivarCollidersArmas()
    {
        espada.enabled = true;
    }

    public void DesactivarCollidersArmas()
    {
        espada.enabled = false;
    }
}
