using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //Para red

// Script para obtener de la base de datos las preguntas, los índices de las preguntas, las opciones correspondientes de las preguntas y las opciones correctas para cada nivel.

public class DescargarDatos : MonoBehaviour
{
    public GameObject Boton;
    public GameObject Cargando;

    void Start()
    {
        DesbloquearPreguntas();
    }

    public void DesbloquearPreguntas()
    {
        GetJSON.instance.LeerJSON("pregunta/verPreguntasDato?dato=texto");
        StartCoroutine(EsperarPregunta());
    }

    public void DesbloquearPreguntasID()
    {
        GetJSON.instance.LeerJSON("pregunta/verPreguntasDato?dato=id");
        StartCoroutine(EsperarPreguntaID());
    }

    public void DesbloquearOpciones()
    {
        GetJSON.instance.LeerJSON("opcion/verOpcionPregunta");
        StartCoroutine(EsperarOpciones());
    }

    public void DesbloquearOpcionCorrecta()
    {
        GetJSON.instance.LeerJSON("pregunta/verPreguntasDato?dato=opcion_correcta");
        StartCoroutine(EsperarOpcionCorrecta());
    }

    private IEnumerator EsperarPregunta()
    {
        while (GetJSON.instance.ejecucion) yield return null;
        string[] preguntas = GetJSON.instance.elementos.ToArray();
        print(preguntas.Length);
        GameManager.preguntas = preguntas;
        DesbloquearPreguntasID();
    }

    private IEnumerator EsperarPreguntaID()
    {
        while (GetJSON.instance.ejecucion) yield return null;
        string[] preguntasID = GetJSON.instance.elementos.ToArray();
        print(preguntasID.Length);
        GameManager.preguntasID = preguntasID;
        DesbloquearOpciones();
    }

    private IEnumerator EsperarOpciones()
    {
        while (GetJSON.instance.ejecucion) yield return null;
        string[] opciones = GetJSON.instance.elementos.ToArray();
        print(opciones.Length);
        for (int i = 0; i < opciones.Length; i+=3)
        {
            string[] tripleta = { opciones[i], opciones[i + 1], opciones[i + 2] };
            GameManager.opciones.Add(tripleta);
        }
        foreach(string[] tripleta in GameManager.opciones)
        {
            print(tripleta[0] + ", " + tripleta[1] + ", " + tripleta[2]);
        }
        DesbloquearOpcionCorrecta();
    }

    private IEnumerator EsperarOpcionCorrecta()
    {
        while (GetJSON.instance.ejecucion) yield return null;
        string[] opciones_correctas = GetJSON.instance.elementos.ToArray();
        print(opciones_correctas.Length);
        GameManager.opciones_correctas = opciones_correctas;
        Boton.GetComponent<Button>().enabled = true;
        Cargando.SetActive(false);
    }
}
