using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Script para registrar la colisión de los asteroides con el automóvil.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 23 de abril de 2021
 */

public class RegistraColisionAsteroide : MonoBehaviour
{

    public AudioSource sonidoChoque;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Automovil"))
        {
            GameManager.dano += 1 - GameManager.resistencia;
            sonidoChoque.Play();
            Destroy(this.gameObject, t: 0.2f);
        }
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
