using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonContinuar : MonoBehaviour
{
    public GameObject Resultados;
    public void MostrarResultados()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "MinijuegoITC")
        {
            if (GameManager.oleada >= 3)
            {
                Resultados.SetActive(true);
                print(Game_Controller.instance.puntaje / 7000.0f);
                BarraResultados.instance.SetValue(Game_Controller.instance.puntaje / 7000.0f);
            }
        }
        else if(sceneName == "NivelBio")
        {
            GameManager.respondido = true;
            if (GameManager.oleada >= 3)
            {
                Resultados.SetActive(true);
                float puntos = (float)GameManager.puntuacion;
                BarraResultados.instance.SetValue(puntos / 5.0f);
            }
        }
    }
}
