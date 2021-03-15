using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnviarTexto : MonoBehaviour
{
    public Text Instrucciones;
    string instruccionesUsuario;
    string[] comandos = {"M", "S","A", "Ap"}; //M: Mover, S: Saltar, A: Atacar, Ap: Apagar
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        instruccionesUsuario = Instrucciones.text.ToLower();
    }

    public void UpdateText(InputField Resultados)
    {
        Resultados.text += "\n" + instruccionesUsuario;
    }

    public void EnviarInstrucciones()
    {
        int tiempo = 0;
        int contador = 0;
        Debug.Log(instruccionesUsuario);
        string[] lineas = instruccionesUsuario.Split('.');
        while (contador < lineas.Length-1)
        {
            tiempo = EjecutarInstruccion(lineas[contador]);
            while (tiempo > 0)
            {
                --tiempo;
            }
            if (tiempo == 0)
            {
                ++contador;
            }
        }
    }

    private int EjecutarInstruccion(string instruccion)
    {
        int wait = 0;
        string[] instrucciones = instruccion.Split(' ');
        for (int i = 0; i < instrucciones.Length; i++)
        {
            //if(comandos.Contains(letra))
            //{

            //}

            //string palabra = instrucciones[i];
            //if(comandos.Contains(palabra[0]))

            if (instrucciones[i] == "mover")
            {
                if (instrucciones[i + 1] == "derecha")
                {
                    int duracion = Int16.Parse(instrucciones[i + 2]);
                    player.MoveRight(duracion);
                    wait += duracion;
                }
                else if (instrucciones[i + 1] == "izquierda")
                {
                    int duracion = Int16.Parse(instrucciones[i + 2]);
                    player.MoveLeft(duracion);
                    wait += duracion;
                }
            }
            else if (instrucciones[i] == "saltar")
            {
                var force = Int16.Parse(instrucciones[i + 1]);
                player.Jump(force);
                wait += 5;
            }
            else if (instrucciones[i] == "abrir" || instrucciones[i] == "cerrar" || instrucciones[i] == "atacar")
            {
                player.Attack();
                wait += 10;
            }
        }
        //wait += 10;
        Debug.Log("Esperando...");
        Debug.Log(wait);
        return wait;
    }
}
