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
    private PlayerMovement player;
    private Dictionary<string, string[]> funciones = new Dictionary<string, string[]>();

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnviarInstrucciones()
    {
        //Debug.Log(instruccionesUsuario);
        instruccionesUsuario = Instrucciones.text.ToLower();
        string[] lineas = instruccionesUsuario.Split('.');
        StartCoroutine(EjecutarInstruccion(lineas));
    }

    IEnumerator EjecutarInstruccion(string[] lineas)
    {
        //foreach (string comando in lineas)
        for (int comando = 0; comando < lineas.Length; comando++)
        {
            Debug.Log(lineas[comando]);
            float wait = 0;
            string[] instrucciones = lineas[comando].Split(' ');
            for (int i = 0; i < instrucciones.Length; i++)
            {
                if (instrucciones[i].Contains("der"))
                {
                    Debug.Log("Moviendo derecha...");
                    int duracion = 10;
                    if (i + 1 < instrucciones.Length - 1)
                    {
                        duracion = Int16.Parse(instrucciones[i + 1]);
                    }
                    wait += duracion / 2;
                    player.MoveRight(duracion);
                }
                else if (instrucciones[i].Contains("izq"))
                {
                    Debug.Log("Moviendo izquierda...");
                    int duracion = 10;
                    if (i + 1 < instrucciones.Length - 1)
                    {
                        duracion = Int16.Parse(instrucciones[i + 1]);
                    }
                    wait += duracion / 2;
                    player.MoveLeft(duracion);
                }
                else if (instrucciones[i].Contains("sal"))
                {
                    int force = 8;
                    if (i < instrucciones.Length - 1)
                    {
                        force = Int16.Parse(instrucciones[i + 1]);
                    }
                    Debug.Log("Esperando...");
                    while (!is_grounded_controller.is_grounded) yield return null;
                    yield return new WaitForSeconds(0.1f);
                    Debug.Log("Saltando...");
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
                    string nombre_funcion = instrucciones[i + 1];
                    if (!funciones.ContainsKey(nombre_funcion))
                    {
                        List<string> funcion = new List<string>();
                        int linea = i + 1;
                        while (linea + 1 < lineas.Length)
                        {
                            if(lineas[linea].Contains("alto"))
                            {
                                break;
                            }
                            funcion.Add(lineas[linea]);
                            linea++;
                        }
                        funciones.Add(nombre_funcion, funcion.ToArray());
                    }
                    StartCoroutine(EjecutarInstruccion(funciones[nombre_funcion]));
                }
            }
            
            Debug.Log(wait * 0.1f);
            yield return new WaitForSeconds(wait * 0.1f);
        }
    }
}
