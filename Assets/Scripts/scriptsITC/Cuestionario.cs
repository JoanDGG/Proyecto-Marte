using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cuestionario : MonoBehaviour
{
    private int nivel = 1;
    public Text pregunta;
    public Text opcionA;
    public Text opcionB;
    public Text opcionC;
    public Text respuestaTexto;

    private string[] preguntas_ITC = { "¿Para que sirven las funciones?",
                                       "¿Que cosas se pueden hacer con la programacion?",
                                       "¿Que son las cosas mas importantes para dedicarte a una carrera de programacion o robotica?",
                                       "¿Como se le llama al conjunto de instrucciones que resuelven un problema especifico?"};
    private string[] opcionesA_ITC = { "Para conocer el nombre de un conjunto de instrucciones",
                                       "Robots, videojuegos y paginas de internet",
                                       "Paciencia y Originalidad",
                                       "Programa"};
    private string[] opcionesB_ITC = { "Para tener una forma mas facil y rapida de acceder a varias instrucciones",
                                       "Construir edificios, viajar al espacio y crear musica",
                                       "Creatividad, Determinacion, y Pensamiento logico",
                                       "Software"};
    private string[] opcionesC_ITC = { "Para cambiar los valores de las instrucciones por el nombre de la función",
                                       "Viajar en el tiempo, crear aplicaciones y crear inteligencia artificial",
                                       "Pensamiento rapido y trabajo en equipo",
                                       "Computadora"};

    private string respuesta;
    
    // Update is called once per frame
    public void Desbloquear()
    {
        //StartCoroutine(DescargarTextoPlano());
        nivel = Game_Controller.instance.nivel - 2;
        print("pregunta del nivel " + nivel);
        if(nivel == 2)
        {
            Random.Range(2, 3);
        }
        pregunta.text = preguntas_ITC[nivel];
        opcionA.text = opcionesA_ITC[nivel];
        opcionB.text = opcionesB_ITC[nivel];
        opcionC.text = opcionesC_ITC[nivel];

    }

    public void Responder(string res)
    {
        respuesta = res;
        print("Respondío: " + respuesta);
        if(nivel == 0)
        {
            if(respuesta == "b")
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
        else if (nivel == 1)
        {
            if (respuesta == "a")
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
        else if (nivel == 2)
        {
            if (respuesta == "b")
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
        else if (nivel == 3)
        {
            if (respuesta == "a")
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
    }

    //PENDIENTE RECIBIR DATOS DE BASE DE DATOS

    //// Inicio es síncrono, pero termina antes del codigo asíncrono
    //private IEnumerator DescargarTextoPlano()
    //{
    //    UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/plantillaEJS");
    //    yield return request.SendWebRequest(); //Ejecuta, regresa, espera...
    //    //Ya regresó... continuar...
    //    if (request.result == UnityWebRequest.Result.Success)
    //    {   //Procesar resultados
    //        string textoPlano = request.downloadHandler.text;
    //        resultado.text = textoPlano;
    //    }
    //    else
    //    {
    //        resultado.text = "Error en la descarga " + request.responseCode.ToString();
    //    }
    //}
}
