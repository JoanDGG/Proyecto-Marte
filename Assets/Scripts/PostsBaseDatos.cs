using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class PostsBaseDatos : MonoBehaviour
{
    public void PedirLogOut()
    {
        StartCoroutine(HacerLogOut());
    }

    private IEnumerator HacerLogOut()
    {
        WWWForm forma = new WWWForm();
        //float tiempoFin = PlayerPrefs.GetInt("tiempoFin", 0.0f);
        int tiempo = (int)(((System.DateTime.Now - LogIn.inicio).TotalSeconds) / 60); //Tiempo en minutos enteros
        print(tiempo);
        forma.AddField("gamertag", GameManager.GamerTag);
        forma.AddField("tiempoTotal", tiempo.ToString());
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/LogOut", forma);
        yield return request.SendWebRequest();
        //bool exito = true;
        print(request.result);
        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Tiempo registrado con exito");
            Application.Quit(); //Salir del juego
            //SceneManager.LoadScene("Log in"); O regresar a la pantalla del Log In
        }
        else
        {
            print("Error en la descarga: " + request.responseCode.ToString());
        }
    }

    public void PedirInfoNivel() //Debe llamarse al finalizar el nivel y debe enviársele el tiempo en el que se inicio el nivel, la puntuacion y la reseña
    {
        print("Solicitud confirmada");
        GameManager.GamerTag = "Diego";
        GameManager.nivelGlobal = 4;
        DateTime inicio = System.DateTime.Now;
        int resena = 0;
        float puntuacion = GameManager.puntuacion; //Solo funciona con el nivel Agropecuario
        StartCoroutine(PublicarTiempoNivel(inicio, resena, puntuacion));
    }

    private IEnumerator PublicarTiempoNivel(DateTime inicio, int resena, float puntuacion)
    {
        DateTime fin = System.DateTime.Now;
        WWWForm forma = new WWWForm();
        forma.AddField("JugadorGamertag", GameManager.GamerTag.ToString());
        forma.AddField("NivelIdNivel", GameManager.nivelGlobal.ToString());
        forma.AddField("ano", inicio.Year);
        forma.AddField("mes", inicio.Month);
        forma.AddField("diaInicio", inicio.Day);
        forma.AddField("horaInicio", inicio.Hour);
        forma.AddField("minutoInicio", inicio.Minute);
        forma.AddField("diaFin", fin.Day);
        forma.AddField("horaFin", fin.Hour);
        forma.AddField("minutoFin", fin.Minute);
        forma.AddField("calificacion", resena.ToString());
        forma.AddField("puntuacion", puntuacion.ToString());
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/juega/insertarJuega", forma); //Falta cambiarlo en el ServidorProyectoMarte
        yield return request.SendWebRequest();
        //bool exito = true;
        print(request.result);
        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Tiempos de nivel registrados con éxito");
        }
        else
        {
            print("Error en la descarga: " + request.responseCode.ToString());
        }
    }

    public void PedirRespuesta() //Debe llamarse al responder una pregunta y debe enviársele la respuesta, si es correcta y el id de la pregunta a la que corresponde 
    {
        GameManager.GamerTag = "Diego";
        string res = "Hola";
        int correct = 1;
        int pregunta = 1;
        StartCoroutine(PublicarRespuesta(res, correct, pregunta));
    }

    private IEnumerator PublicarRespuesta(string res, int correct, int pregunta)
    {
        WWWForm forma = new WWWForm();
        forma.AddField("JugadorGamertag", GameManager.GamerTag);
        forma.AddField("PreguntumId", pregunta.ToString());
        forma.AddField("respuesta", res);
        forma.AddField("estado", correct.ToString()); 
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/respuesta/insertarRespuesta", forma); //Falta cambiarlo en el ServidorProyectoMarte
        yield return request.SendWebRequest();
        //bool exito = true;
        print(request.result);
        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Respuesta registrada con éxito");
        }
        else
        {
            print("Error en la descarga: " + request.responseCode.ToString());
        }
    }
}
