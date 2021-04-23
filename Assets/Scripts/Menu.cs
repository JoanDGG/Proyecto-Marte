using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    // Metodo que atiende al boton
    public void Jugar()
    {
        // Cambiar a la escena 'EscenaTransicion'
        SceneManager.LoadScene("EscenaTransicion");
    }

    public void InicioSesion()
    {
        // Cambiar a la escena 'Log In'
        SceneManager.LoadScene("Log In");
    }

    public void MainMenu()
    {
        // Cambiar a la escena 'MainMenu'
        SceneManager.LoadScene("ColoniaMarte");
    }

}
