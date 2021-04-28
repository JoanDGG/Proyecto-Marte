using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class LogIn : MonoBehaviour
{

    // Elementos del canvas para login.
    public Text Gamertag;
    public InputField Contrasena;
    public Text resultado;
    public static DateTime inicio;
    public static string textoPlano;
    
    public void PedirLogIn()
    {
        StartCoroutine(ComprobarLogIn());
    }

    private IEnumerator ComprobarLogIn()
    {
        // El objeto form para enviar la información al servidor.
        WWWForm forma = new WWWForm();

        forma.AddField("gamertag", Gamertag.text);
        forma.AddField("contrasena", Contrasena.text);

        // Post de login, regresa el nombre de usuario o un texto de login fallido.
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/LogIn", forma);
        yield return request.SendWebRequest();

        bool exito = true;

        // Si existe el usuario en la base de datos se imprime su gamertag.
        print(request.result);


        if (request.result == UnityWebRequest.Result.Success)
        {
            textoPlano = request.downloadHandler.text;
            string texto = "Log in exitoso, bienvenido";
            if (textoPlano != Gamertag.text)
            {
                texto = "No se encontro el usuario";
                exito = false;
            }
            else
            {
                GameManager.GamerTag = Gamertag.text;
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
            SceneManager.LoadScene("EscenaTransicion"); //Esto est� comentado para poder probar el LogOut antes de ponerlo en la escena de la ColoniaMarte
        }
    }
}
