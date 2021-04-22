using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public Cuestionario cuestionario;
    public GameObject imagenPreguntas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        imagenPreguntas.SetActive(true);
        cuestionario.DesbloquearPreguntas();
    }
}
