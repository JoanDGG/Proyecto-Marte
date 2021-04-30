using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
/*
* Script para mostrar el HUD en la mision 1
* Autor: Daniel Garcia Barajas
*/
public class HUDMisionCohete : MonoBehaviour
{
    public static HUDMisionCohete instance;

    public Image Image1;
    public Image Image2;
    public Image Image3;

    public Text puntajeCoheteTxt;
    private void Awake()
    {
        instance = this;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        GameManager.nivelGlobal = 1;
        GameManager.tiempoInicioNivel = System.DateTime.Now;
        if (sceneName == "MisionCohete-1")
        {
            GameManager.oleada = 0;
            GameManager.puntuacionNivelCohete = 3.77f;
        }
    }

    internal void UpdateLifes()
    {
        int vidas = RocketLifes.instance.vidas;
        GameManager.puntuacionNivelCohete -= 0.41f;
        if (vidas == 2){
            Image1.enabled = false;
            
        } else if (vidas == 1){
            Image2.enabled = false;
        } else if (vidas == 0){
            Image3.enabled = false;
        }

        puntajeCoheteTxt.text = GameManager.puntuacionNivelCohete.ToString();
    }
}
