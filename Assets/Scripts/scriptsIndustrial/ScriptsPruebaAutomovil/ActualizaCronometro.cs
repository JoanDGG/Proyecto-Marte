using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Script para actualizar el texto de tiempo del nivel de automóvil.
Autor: Luis Ignacio Ferro Salinas A01378248.
Última actualización: 21 de abril de 2021. 
 */

public class ActualizaCronometro : MonoBehaviour
{

    // La variable del tiempo de inicio.
    private float startTime;
    private  float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time - startTime;
        GameManager.numeroSegundos = timeElapsed;
        string minutes = ((int)timeElapsed / 60).ToString();
        string seconds = (timeElapsed % 60).ToString("f2"); // Dejamos 2 decimales.
        this.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = minutes + ":" + seconds;
    }
}
