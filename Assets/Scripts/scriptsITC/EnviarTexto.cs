using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/* 
Descripcion:
Este script se utiliza para manejar el texto que sea ingresado por el usuario 
dentro del nivel 3 del Robot. Los comandos que se reciban son analizados palabra 
por palabra para determinar el comando que debe ser ejecutado por el personaje.

Autor: Joan Daniel Guerrero Garcia
*/

public class EnviarTexto : MonoBehaviour
{
    public Text Instrucciones;                      // Campo de texto que contiene el texto del usuario
    string instruccionesUsuario;                    // String del texto ingresado por el usuario
    private PlayerMovement player;                  // Referencia al script PlayerMovement del personaje
    private Dictionary<string, string[]> funciones; // Diccionario con las posibles funciones que declare el usuario
    public Text textError;

    void Start()
    {
        // Se inicializa el personaje, debe contener PlayerMovement
        player = FindObjectOfType<PlayerMovement>();

        // La llave de funciones es el nombre de la funcion, y la lista de string son los comandos
        funciones = new Dictionary<string, string[]>(); 
    }

    public void EnviarInstrucciones()
    {
        // Se reciben las instrucciones y se separan por puntos para analizar cada una
        instruccionesUsuario = Instrucciones.text.ToLower();
        string[] lineas = instruccionesUsuario.Split('.');
        StartCoroutine(EjecutarInstruccion(lineas));
    }

    IEnumerator EjecutarInstruccion(string[] lineas)
    {
        // Para cada linea de los comandos, se analiza palabra por palabra para mandar las instrucciones
        for (int comando = 0; comando < lineas.Length; comando++)
        {
            // Wait es el tiempo en 1/60 seg. Que debe esperar por funcion
            float wait = 0;
            string[] instrucciones = lineas[comando].Split(' ');
            for (int i = 0; i < instrucciones.Length; i++)
            {
                if (instrucciones[i].Contains("der"))
                {
                    //Debug.Log("Moviendo derecha...");
                    int duracion = 10;
                    if (i < instrucciones.Length - 1)
                    {
                        if (instrucciones[i + 1] == "")
                        {
                            textError.text = "Te sobran espacios! (linea " + comando + ")";
                        }
                        else
                        {
                            // Se convierte la cantidad de string a int
                            duracion = Mathf.Clamp(Int16.Parse(instrucciones[i + 1]), 0, 50);
                        }
                    }
                    wait += duracion / 2;
                    player.MoveRight(duracion);
                }
                else if (instrucciones[i].Contains("izq"))
                {
                    //Debug.Log("Moviendo izquierda...");
                    int duracion = 10;
                    if (i < instrucciones.Length - 1)
                    {
                        if (instrucciones[i + 1] == "")
                        {
                            textError.text = "Te sobran espacios! (linea " + comando + ")";
                        }
                        else
                        {
                            // Se convierte la cantidad de string a int
                            duracion = Mathf.Clamp(Int16.Parse(instrucciones[i + 1]), 0, 50);
                        }
                    }
                    wait += duracion / 2;
                    player.MoveLeft(duracion);
                }
                else if (instrucciones[i].Contains("sal"))
                {
                    int force = 8;
                    if (i < instrucciones.Length - 1)
                    {
                        if (instrucciones[i + 1] == "")
                        {
                            textError.text = "Te sobran espacios! (linea " + comando + ")";
                        }
                        else
                        {
                            // Se convierte la cantidad de string a int
                            force = Mathf.Clamp(Int16.Parse(instrucciones[i + 1]), 0, 25);
                        }
                    }
                    //Debug.Log("Esperando...");

                    // Revisa que el personaje no este en el aire, y espera hasta que toque el suelo
                    while (!is_grounded_controller.is_grounded) yield return null;
                    yield return new WaitForSeconds(0.1f);
                    //Debug.Log("Saltando...");
                    player.Jump(force);
                    wait += 5;
                }
                else if (instrucciones[i].Contains("atk"))
                {
                    while (!is_grounded_controller.is_grounded) yield return null;
                    Debug.Log("Atacando...");
                    player.Attack();
                    wait += 8;
                }
                else if (instrucciones[i].Contains("fuego"))
                {
                    Debug.Log("Apagando fuego...");
                    player.Fire();
                    wait += 4;
                }
                else if (instrucciones[i].Contains("func"))
                {
                    // El nombre de la funcion es la palabra que va despues de func
                    string nombre_funcion = instrucciones[i + 1];
                    
                    // Se revisa si la funcion aun no existe
                    if (!funciones.ContainsKey(nombre_funcion))
                    {
                        List<string> funcion = new List<string>();
                        int linea = i + 1;
                        // Por cada linea siguiente hasta el final, se añade a la funcion declarada
                        while (linea + 1 < lineas.Length)
                        {
                            /* Si se encuentra el comando "alto" o el nombre de la funcion, se detiene.
                             * Se decidio evitar la recursividad por cualquier loop infinito.
                             */
                            if(lineas[linea].Contains("alto") || lineas[linea].Contains(nombre_funcion))
                            {
                                break;
                            }
                            funcion.Add(lineas[linea]);
                            linea++;
                        }
                        funciones.Add(nombre_funcion, funcion.ToArray());
                    }
                    // Se llama de nuevo a EjecutarInstruccion para la funcion declarada
                    StartCoroutine(EjecutarInstruccion(funciones[nombre_funcion]));
                }
            }
            
            //Debug.Log(wait * 0.1f);
            yield return new WaitForSeconds(wait * 0.1f);
        }
    }
}
