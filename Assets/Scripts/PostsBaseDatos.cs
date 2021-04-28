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
        SceneManager.LoadScene("Log in");
    }

    private IEnumerator HacerLogOut()
    {
        WWWForm forma = new WWWForm();
        //float tiempoFin = PlayerPrefs.GetInt("tiempoFin", 0.0f);
        int tiempo = (int)(((GameManager.tiempoLogOut - LogIn.inicio).TotalSeconds) / 60); //Tiempo en minutos enteros
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
            //SceneManager.LoadScene("Log in"); O regresar a la pantalla del Log In
        }
        else
        {
            print("Error en la descarga: " + request.responseCode.ToString());
        }
    }

    public void PedirInfoNivel() //Debe llamarse al finalizar el nivel y debe enviarsele el tiempo en el que se inicio el nivel, la puntuacion y la rese?a
    {
        DateTime inicio = GameManager.tiempoInicioNivel;
        int resena = GameManager.resena;
        float puntuacion = GameManager.puntuacion;
        StartCoroutine(PublicarTiempoNivel(inicio, resena, puntuacion));
    }

    private IEnumerator PublicarTiempoNivel(DateTime inicio, int resena, float puntuacion)
    {
        DateTime fin = GameManager.tiempoFinNivel;
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
            print("Tiempos de nivel registrados con ?xito");
        }
        else
        {
            print("Error en la descarga: " + request.responseCode.ToString());
        }
    }

    public void PedirRespuesta() //Debe llamarse al responder una pregunta y debe enviarsele la respuesta, si es correcta y el id de la pregunta a la que corresponde 
    {
        string res = GameManager.respuesta_actual;
        int correct = GameManager.correcta ? 1 : 0;
        int pregunta = GameManager.pregunta_actual;
        StartCoroutine(PublicarRespuesta(res, correct, pregunta));
    }

    // Corrutina para publicar una respuesta del jugador en la base de datos.
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
            print("Respuesta registrada con ?xito");
        }
        else
        {
            print("Error en la descarga: " + request.responseCode.ToString());
        }
    }
}
