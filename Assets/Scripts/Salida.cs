using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class Salida : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnApplicationQuit()
    {
        print("Registro Log Out");
        PostsBaseDatos post = gameObject.GetComponent<PostsBaseDatos>();
        if (SceneManager.GetActiveScene().name != "Log in")
        {
            post.PedirLogOut();
            if(GameManager.nivelGlobal > 0)
            {
                post.PedirInfoNivel();
            }
        }
    }
}
