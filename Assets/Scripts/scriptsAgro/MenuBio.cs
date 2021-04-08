using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBio : MonoBehaviour
{
    public void Adelantar()
    {
        if(!GameManager.evento)
        GameManager.tiempo = GameManager.tiempoLimite;
    }
}
