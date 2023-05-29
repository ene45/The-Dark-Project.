using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image barradeVida;

    public PlayerMovement PlayerMovement;

    void Update()
    {
        barradeVida.fillAmount = PlayerMovement.Life / PlayerMovement.MaxLife;
    }
}
