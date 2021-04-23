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

    public void PedirTiempoNivel(DateTime inicio) //Debe llamarse al finalizar el nivel y debe enviársele el tiempo en el que se inicio el nivel
    {
        StartCoroutine(PublicarTiempoNivel(inicio));
    }

    private IEnumerator PublicarTiempoNivel(DateTime inicio)
    {
        WWWForm forma = new WWWForm();
        forma.AddField("JugadorGamertag", GameManager.GamerTag);
        forma.AddField("NivelIdNivel", GameManager.nivelGlobal);
        forma.AddField("tiempoInicio", inicio.ToString());
        forma.AddField("tiempoFinal", System.DateTime.Now.ToString());
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/juega/tiempoNivel", forma); //Falta crearlo en el ServidorProyectoMarte
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

    public void PedirRespuesta() //Debe llamarse al responder una pregunta y debe enviársele la respuesta, si es correcta y el id de la pregunta a la que corresponde (FORMATO PENDIENTE)
    {
        StartCoroutine(PublicarRespuestaNivel());
    }

    private IEnumerator PublicarRespuesta()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("JugadorGamertag", GameManager.GamerTag);
        forma.AddField("PreguntumId", "".ToString()); //Falta
        forma.AddField("respuesta", ""); //Falta
        forma.AddField("estado", ""); //Falta
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
