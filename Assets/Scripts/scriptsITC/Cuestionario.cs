using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //Para red

public class Cuestionario : MonoBehaviour
{
    private int nivel = 1;
    public Text pregunta;
    public Text opcionA;
    public Text opcionB;
    public Text opcionC;
    public Text respuestaTexto;
    private string[] preguntas = new string[4];
    private string[] opciones = new string[12];
    private string[] opciones_correctas = new string[4];
    private string respuesta;
    private string opcion_correcta;

    public void DesbloquearPreguntas()
    {
        GetJSON.instance.LeerJSON("pregunta/verPreguntasDato?dato=texto");
        StartCoroutine(EsperarPregunta());
    }

    public void DesbloquearOpciones(int pregunta)
    {
        print("PreguntaId: " + pregunta);
        GetJSON.instance.LeerJSON("opcion/verOpcionPregunta?PreguntumId=" + pregunta);
        StartCoroutine(EsperarOpciones());
    }

    public void DesbloquearOpcionCorrecta()
    {
        GetJSON.instance.LeerJSON("pregunta/verPreguntasDato?dato=opcion_correcta");
        StartCoroutine(EsperarOpcionCorrecta());
    }

    public void Responder(string res)
    {
        respuesta = res;
        print("Respondío: " + respuesta);
        print(opcion_correcta);
        if (respuesta == opcion_correcta)
        {
            print("Respuesta correcta!");
            respuestaTexto.text = "Respuesta correcta!";
        }
        else
        {
            print("Respuesta incorrecta :(");
            respuestaTexto.text = "Respuesta incorrecta :(";
        }
    }

    private IEnumerator EsperarPregunta()
    {
        yield return new WaitForSeconds(0.1f);
        preguntas = GetJSON.instance.elementos.ToArray();
        print(preguntas.Length);
        nivel = Game_Controller.instance.nivel - 2;
        print("pregunta del nivel " + nivel);
        if (nivel == 2)
        {
            nivel = UnityEngine.Random.Range(2, 3);
        }
        print("pregunta: " + preguntas[nivel]);
        pregunta.text = preguntas[nivel];
        DesbloquearOpciones(nivel + 1);
    }

    private IEnumerator EsperarOpciones()
    {
        yield return new WaitForSeconds(0.1f);
        opciones = GetJSON.instance.elementos.ToArray();
        print(opciones.Length);
        opcionA.text = opciones[0];
        opcionB.text = opciones[1];
        opcionC.text = opciones[2];
        DesbloquearOpcionCorrecta();
    }

    private IEnumerator EsperarOpcionCorrecta()
    {
        yield return new WaitForSeconds(0.1f);
        opciones_correctas = GetJSON.instance.elementos.ToArray();
        print(opciones_correctas.Length);
        opcion_correcta = opciones_correctas[nivel];
    }
}