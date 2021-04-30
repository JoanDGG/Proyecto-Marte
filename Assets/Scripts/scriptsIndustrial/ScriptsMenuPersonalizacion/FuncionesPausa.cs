using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/*
Script con funciones que se asocian a los botones de la pausa.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 26 de abril de 2021.
*/

public class FuncionesPausa : MonoBehaviour
{
    public AudioSource musicaFondo;
    public AudioSource musicaPausa;

    public void Continuar() {
        this.gameObject.SetActive(false);
        musicaFondo.Play();
        musicaPausa.Stop();
        Time.timeScale = 1;
    }

    public void MenuPrincipal() {
        GameManager.tiempoFinNivel = System.DateTime.Now;
        SceneManager.LoadScene("Resena");
    }

    public void CambiarAuto() {
        SceneManager.LoadScene("MenuPersonalizarAuto");
        GameManager.budget = 38;
        GameManager.tiempoFinNivel = System.DateTime.Now;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
