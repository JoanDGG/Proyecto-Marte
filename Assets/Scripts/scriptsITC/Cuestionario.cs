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
    private string[] preguntas;
    private string[] opciones1;
    private string[] opciones2;
    private string[] opciones3;
    private string[] opciones4;
    private string[] opciones_correctas;
    private string respuesta;
    private string opcion_correcta;

    public void DesbloquearPreguntas()
    {
        preguntas = new string[4] { GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4)],
                                    GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4) + 1],
                                    GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4) + 2],
                                    GameManager.preguntas[((GameManager.nivelGlobal - 1) * 4) + 3]};

        opciones1 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4)];
        opciones2 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4) + 1];
        opciones3 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4) + 2];
        opciones4 = GameManager.opciones[((GameManager.nivelGlobal - 1) * 4) + 3];

        opciones_correctas = new string[4] { GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4)],
                                             GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4) + 1],
                                             GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4) + 2],
                                             GameManager.opciones_correctas[((GameManager.nivelGlobal - 1) * 4) + 3]};
        
        nivel = GameManager.oleada - 1;
        print("pregunta del nivel " + nivel);
        if (nivel == 2)
        {
            nivel = UnityEngine.Random.Range(2, 3);
        }
        print("pregunta: " + preguntas[nivel]);
        pregunta.text = preguntas[nivel];
        if(nivel == 0)
        {
            opcionA.text = opciones1[0];
            opcionB.text = opciones1[1];
            opcionC.text = opciones1[2];
        }
        else if (nivel == 1)
        {
            opcionA.text = opciones2[0];
            opcionB.text = opciones2[1];
            opcionC.text = opciones2[2];
        }
        else if (nivel == 2)
        {
            opcionA.text = opciones3[0];
            opcionB.text = opciones3[1];
            opcionC.text = opciones3[2];
        }
        else if (nivel == 3)
        {
            opcionA.text = opciones4[0];
            opcionB.text = opciones4[1];
            opcionC.text = opciones4[2];
        }
        opcion_correcta = opciones_correctas[nivel];
    }

    public void Responder(string res)
    {
        respuesta = res;
        print("Respondío: " + respuesta);
        print(opcion_correcta);
        if (respuesta == opcion_correcta)
        {
            GameManager.correcta = true;
            print("Respuesta correcta!");
            respuestaTexto.text = "Respuesta correcta!";
        }
        else
        {
            GameManager.correcta = false;
            print("Respuesta incorrecta :(");
            respuestaTexto.text = "Respuesta incorrecta :(";
        }
        switch (nivel)
        {
            case 0:
                switch (res)
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
                switch (res)
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
                switch (res)
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
                switch (res)
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