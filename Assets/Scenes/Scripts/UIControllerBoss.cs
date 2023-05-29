using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerBoss : MonoBehaviour
{
    public GameObject Vida;
    public Image barradeVida;

    public boss boss;

    public Transform Player;
    public Transform Boss;

    public float distance;

    private void Start()
    {
        Vida.SetActive(false);
    }

    void Update()
    {
        barradeVida.fillAmount = boss.Life / boss.MaxLife;
        AparecerBarraVida();
    }

    public void AparecerBarraVida()
    {
        if(Vector3.Distance(Player.transform.position, Boss.transform.position) < distance)
        {
            Vida.SetActive(true);
        }
        else
        {
            Vida.SetActive(false);
        }
    }
}
