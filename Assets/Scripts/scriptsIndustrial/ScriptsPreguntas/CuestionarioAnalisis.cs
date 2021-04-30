using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //Para red
using UnityEngine.SceneManagement;

public class CuestionarioAnalisis : MonoBehaviour
{
    public Text pregunta; // El objeto de texto de pregunta para cambiar.

    public Text opcionA; // Los objetos de opciones de texto para cambiar.
    public Text opcionB;
    public Text opcionC;

    public Text respuestaTexto; // El objeto de respuesta.

    //private string respuesta; // La respuesta que da el jugador.

    private string opcion_correcta; // La opcion correcta.

    private int indicePregunta; // El indice de la pregunta.

    private string[] preguntas;

    private string[] opciones1;
    private string[] opciones2;
    private string[] opciones3;
    private string[] opciones4;

    private string[] opciones_correctas;


    // Para tener la referencia del numero de pregunta.
    private int numeroPregunta;

    public void LlenaPregunta1()
    {
    // Las 4 preguntas de mi nivel.
    preguntas = new string[4] { GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4)],
                                                GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4) + 1],
                                                GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4) + 2],
                                                GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4) + 3]};

    // Los 4 arreglos de strings, cada uno contiene las opciones para cada pregunta de mi nivel.
    opciones1 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4)];
    opciones2 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4) + 1];
    opciones3 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4) + 2];
    opciones4 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4) + 3];

    // Las 4 opciones correctas para cada pregunta de mi nivel.
    opciones_correctas = new string[4] { GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4)],
                                                 GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4) + 1],
                                                 GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4) + 2],
                                                 GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4) + 3]};

    // La llave de la pregunta en la tabla.
    indicePregunta = ((GameManager.nivelGlobal) - 1) * 4;
        opcion_correcta = opciones_correctas[0];

        numeroPregunta = 0;

        // Actualizo los valores de la pregunta y las opciones mostradas al jugador.
        pregunta.text = preguntas[0];
        opcionA.text = opciones1[0];
        opcionB.text = opciones1[1];
        opcionC.text = opciones1[2];
    }


    public void LlenaPregunta2()
    {
        print("voy a llenar la pregunta 2");
        print("el texto de la pregunta es ");
        print(preguntas[1]);

        // La llave de la pregunta en la tabla.
        indicePregunta = ((GameManager.nivelGlobal - 1) * 4) + 1;
        opcion_correcta = opciones_correctas[1];

        // El numero de pregunta para saber comparar al responder.
        numeroPregunta = 1;

        // Actualizo los valores de la pregunta y las opciones mostradas al jugador.
        pregunta.text = preguntas[1];
        opcionA.text = opciones2[0];
        opcionB.text = opciones2[1];
        opcionC.text = opciones2[2];
    }

    public void LlenaPregunta3()
    {
        // La llave de la pregunta en la tabla.
        indicePregunta = ((GameManager.nivelGlobal - 1) * 4) + 2;
        opcion_correcta = opciones_correctas[2];

        numeroPregunta = 2;

        // Actualizo los valores de la pregunta y las opciones mostradas al jugador.
        pregunta.text = preguntas[2];
        opcionA.text = opciones3[0];
        opcionB.text = opciones3[1];
        opcionC.text = opciones3[2];
    }

    public void LlenaPregunta4()
    {

        // La llave de la pregunta en la tabla.
        indicePregunta = ((GameManager.nivelGlobal - 1) * 4) + 3;
        opcion_correcta = opciones_correctas[3];

        numeroPregunta = 3;

        // Actualizo los valores de la pregunta y las opciones mostradas al jugador.
        pregunta.text = preguntas[3];
        opcionA.text = opciones4[0];
        opcionB.text = opciones4[1];
        opcionC.text = opciones4[2];
    }

    public void CambioAPruebaAuto() {
        SceneManager.LoadScene("PruebaAutomovil");
    }

    public void Responder(string respuesta)
    {
        // La llave primaria de la pregunta para hacer el post.
        GameManager.pregunta_actual = Int32.Parse(GameManager.preguntasID[indicePregunta]);

        //respuesta = res;

        print("Respond?o: " + respuesta);

        print("La opcion correcta es: " + opcion_correcta);

        // La respuesta correcta.
        if (respuesta == opcion_correcta)
        {
            GameManager.correcta = true;
            print("Respuesta correcta!");
            respuestaTexto.text = "Respuesta correcta!";
            /*if (GameManager.nivelGlobal == 4)
            {
                GameManager.puntuacion += 0.5f;
            }*/
        }
        else
        {
            GameManager.correcta = false;
            print("Respuesta incorrecta :(");
            respuestaTexto.text = "Respuesta incorrecta :(";
        }
        switch (numeroPregunta)
        {
            case 0:
                switch (respuesta)
                {
                    case "A":
                        GameManager.respuesta_actual = opciones1[0];
                        break;
                    case "B":
                        GameManager.respuesta_actual = opciones1[1];
                        break;
                    case "C":
                        GameManager.respuesta_actual = opciones1[2];
                        break;
                }
                break;
            case 1:
                switch (respuesta)
                {
                    case "A":
                        GameManager.respuesta_actual = opciones2[0];
                        break;
                    case "B":
                        GameManager.respuesta_actual = opciones2[1];
                        break;
                    case "C":
                        GameManager.respuesta_actual = opciones2[2];
                        break;
                }
                break;
            case 2:
                switch (respuesta)
                {
                    case "A":
                        GameManager.respuesta_actual = opciones3[0];
                        break;
                    case "B":
                        GameManager.respuesta_actual = opciones3[1];
                        break;
                    case "C":
                        GameManager.respuesta_actual = opciones3[2];
                        break;
                }
                break;
            case 3:
                switch (respuesta)
                {
                    case "A":
                        GameManager.respuesta_actual = opciones4[0];
                        break;
                    case "B":
                        GameManager.respuesta_actual = opciones4[1];
                        break;
                    case "C":
                        GameManager.respuesta_actual = opciones4[2];
                        break;
                }
                break;
        }
    }
}