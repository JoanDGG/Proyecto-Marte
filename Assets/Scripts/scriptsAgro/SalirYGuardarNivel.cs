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
        GameManager.primero = true;
        SceneManager.LoadScene("Resena");
    }
}
