using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    public GameObject menuPausa;
    
    public void Pausar()
    {
        print("Pausar");
        menuPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reanudar()
    {
        print("Reanudar");
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }
}
