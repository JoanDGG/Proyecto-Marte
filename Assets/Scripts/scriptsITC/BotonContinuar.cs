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
                float puntuacion = Game_Controller.instance.puntaje / 7000.0f;
                print(puntuacion);
                BarraResultados.instance.SetValue(puntuacion);
                GameManager.puntuacion = puntuacion;
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
        else if(sceneName == "MisionCohete-1")
        {
            SceneManager.LoadScene("MisionCohete-2");
        }
        else if(sceneName == "MisionCohete-2")
        {
            SceneManager.LoadScene("MisionCohete-3");
        }
        else if(sceneName == "MisionCohete-3")
        {
            Resultados.SetActive(true);
            float puntuacion = GameManager.puntuacionNivelCohete / 5.0f;
            print(puntuacion);
            BarraResultados.instance.SetValue(puntuacion);
            GameManager.puntuacion = puntuacion;
            //SceneManager.LoadScene("Resena");
        } 
    }
}
