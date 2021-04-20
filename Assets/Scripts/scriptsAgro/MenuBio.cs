using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBio : MonoBehaviour
{
    public void Adelantar()
    {
        if(!GameManager.evento)
        GameManager.tiempo = GameManager.tiempoLimite;
        print("Felicidades! Ganaste 0.2 puntos");
        GameManager.puntuacion += 0.2f;
    }
}
