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
        //Debug.Log(instruccionesUsuario);
        string[] lineas = instruccionesUsuario.Split('.');
        StartCoroutine(EjecutarInstruccion(lineas));
    }

    IEnumerator EjecutarInstruccion(string[] lineas)
    {
        foreach (string comando in lineas)
        {
            Debug.Log(comando);
            float wait = 0;
            string[] instrucciones = comando.Split(' ');
            for (int i = 0; i < instrucciones.Length; i++)
            {
                //string palabra = instrucciones[i];
                //if(comandos.Contains(palabra[0]))
                if (instrucciones[i].Contains("mover"))
                {
                    int duracion = Int16.Parse(instrucciones[i + 2]);
                    wait += duracion;
                    if (instrucciones[i + 1] == "derecha")
                    {
                        player.MoveRight(duracion);   
                    }
                    else if (instrucciones[i + 1] == "izquierda")
                    {
                        player.MoveLeft(duracion);
                    }
                }
                else if (instrucciones[i].Contains("saltar"))
                {
                    var force = Int16.Parse(instrucciones[i + 1]);
                    player.Jump(force);
                    wait += 5;
                }
                else if (instrucciones[i].Contains("atacar"))
                {
                    player.Attack();
                    wait += 10;
                }
            }

            Debug.Log("Esperando...");
            Debug.Log(wait * 0.1f);
            yield return new WaitForSeconds(wait * 0.1f);
        }
    }
}
