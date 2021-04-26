using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SalirYGuardarNivel : MonoBehaviour
{
    public void SalirMenu()
    {
        GameManager.tiempoFinNivel = System.DateTime.Now;
        GameManager.tiempoLogOut = System.DateTime.Now;
        PlayerPrefs.SetInt("primero", (true) ? 1:0);
        PlayerPrefs.SetInt("tiempo", 0);
        PlayerPrefs.SetInt("tiempoLimite", 60);
        PlayerPrefs.SetInt("evento", (false) ? 1:0);
        PlayerPrefs.SetInt("tiempoEvento", 5);
        PlayerPrefs.SetInt("reloj", 60);
        PlayerPrefs.SetInt("resist0", (false) ? 1:0);
        PlayerPrefs.SetInt("resist1", (false) ? 1:0);
        PlayerPrefs.SetInt("resist2", (false) ? 1:0);
        PlayerPrefs.SetInt("resist3", (false) ? 1:0);
        PlayerPrefs.SetInt("pagina", 0);
        PlayerPrefs.SetInt("clima0", 0);
        PlayerPrefs.SetInt("clima1", 0);
        PlayerPrefs.SetInt("clima2", 0);
        PlayerPrefs.SetInt("genes0", 0);
        PlayerPrefs.SetInt("genes1", 0);
        PlayerPrefs.SetInt("genes2", 0);
        PlayerPrefs.SetInt("oleada", 1);
        PlayerPrefs.SetInt("respondido", (false) ? 1:0);
        PlayerPrefs.SetFloat("puntuacion", 0.0f);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Resena");
    }
}
