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
    //string[] comandos = {"M", "S","A", "Ap"}; //M: Mover, S: Saltar, A: Atacar, Ap: Apagar
    private PlayerMovement player;

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
                    Debug.Log("Moviendo...");
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
                    Debug.Log("Esperando...");
                    while (!is_grounded_controller.is_grounded) yield return null;
                    yield return new WaitForSeconds(0.1f);
                    Debug.Log("Saltando...");
                    player.Jump(force);
                    wait += 5;
                }
                else if (instrucciones[i].Contains("atacar"))
                {
                    while (!is_grounded_controller.is_grounded) yield return null;
                    Debug.Log("Atacando...");
                    player.Attack();
                    wait += 5;
                }
                else if (instrucciones[i].Contains("fuego"))
                {
                    Debug.Log("Apagando fuego...");
                    player.Fire();
                    wait += 2;
                }
            }
            
            Debug.Log(wait * 0.1f);
            yield return new WaitForSeconds(wait * 0.1f);
        }
    }
}
