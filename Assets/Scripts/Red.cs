using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class Red : MonoBehaviour
{

    public Text Gamertag;
    public InputField Contraseña;
    public Text resultado;
    public static DateTime inicio;
    public static DateTime fin;
    public static string textoPlano;
    
    public void PedirLogIn()
    {
        StartCoroutine(ComprobarLogIn());
    }

    private IEnumerator ComprobarLogIn()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("gamertag", Gamertag.text);
        forma.AddField("contrasena", Contraseña.text);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/LogIn", forma);
        yield return request.SendWebRequest();
        bool exito = true;
        print(request.result);
        if (request.result == UnityWebRequest.Result.Success)
        {
            textoPlano = request.downloadHandler.text;
            string texto = "Log in exitoso, bienvenido";
            if (textoPlano != Gamertag.text)
            {
                texto = "No se encontró el usuario";
                exito = false;
            }
            else
            {

            }
            resultado.text = texto;
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
        if (exito)
        {
            yield return new WaitForSeconds(3.0f);
            inicio = System.DateTime.Now;
            SceneManager.LoadScene("ColoniaMarte");
        }
    }
}
