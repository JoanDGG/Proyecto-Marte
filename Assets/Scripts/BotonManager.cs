using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonManager : MonoBehaviour
{
    public static BotonManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Boton()
    {
        if(TextoIntro.instance.contadorTexto > 0)
        {
            TextoIntro.instance.Ejecutar();
        }
        else
        {
            if(GameManager.nivelGlobal == 0)
            {
                SceneManager.LoadScene("MinijuegoITC");
            }
        }
    }
}
