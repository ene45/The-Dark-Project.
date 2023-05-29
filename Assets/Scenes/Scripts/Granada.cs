using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    [SerializeField] private GameObject prefabGranada;
    [SerializeField] private Transform spawnGranada;

    public void SpawnGranada()
    {
        Instantiate(prefabGranada, spawnGranada.position, spawnGranada.rotation);
    }
}
