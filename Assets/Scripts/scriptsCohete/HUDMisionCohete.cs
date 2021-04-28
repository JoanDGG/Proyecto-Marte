using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDMisionCohete : MonoBehaviour
{
    public static HUDMisionCohete instance;

    public Image Image1;
    public Image Image2;
    public Image Image3;

    private void Awake()
    {
        instance = this;
        GameManager.nivelGlobal = 1;
        GameManager.tiempoInicioNivel = System.DateTime.Now;
        GameManager.oleada = 0;
    }

    internal void UpdateLifes()
    {
        int vidas = RocketLifes.instance.vidas;

        if (vidas == 2){
            Image1.enabled = false;
        } else if (vidas == 1){
            Image2.enabled = false;
        } else if (vidas == 0){
            Image3.enabled = false;
        }
    }
}
