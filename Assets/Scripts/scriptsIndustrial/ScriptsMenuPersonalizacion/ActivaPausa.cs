using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script para activar la pausa en el nivel industrial.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 26 de abril de 2021.
*/

public class ActivaPausa : MonoBehaviour
{

    public AudioSource musicaPausa;
    public AudioSource musicaFondo;
    public GameObject panelPausa;

    public void ActivarPausa() {
        Time.timeScale = 0;
        musicaFondo.Stop();
        musicaPausa.Play();
        panelPausa.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
