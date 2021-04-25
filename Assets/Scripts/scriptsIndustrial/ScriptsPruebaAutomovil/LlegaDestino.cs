using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script para avisar al jugador que llegó al destino y al fin del nivel.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 24 de abril de 2021
*/

public class LlegaDestino : MonoBehaviour
{
    public GameObject panelFinNivel;

    // sonidos de motor para quitarlos
    public AudioSource s1;
    public AudioSource s2;
    public AudioSource s3;
    public AudioSource s4;
    public AudioSource s5;
    public AudioSource s6;
    public AudioSource s7;
    public AudioSource s8;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Automovil"))
        {
            s1.Stop();
            s2.Stop();
            s3.Stop();
            s4.Stop();
            s5.Stop();
            s6.Stop();
            s7.Stop();
            s8.Stop();
            panelFinNivel.SetActive(true);
            Time.timeScale = 0;
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {
        panelFinNivel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
