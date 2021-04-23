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
        int tiempo = (int)(((System.DateTime.Now - LogIn.inicio).TotalSeconds) / 60);
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
            Application.Quit();
        }
        else
        {
            print("Error en la descarga: " + request.responseCode.ToString());
        }
    }
}
