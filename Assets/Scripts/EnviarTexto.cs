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
    //public InputField inputText;
    string instruccionesUsuario;
    //string instruccionesUsuario2;
    string[] comandos = {"M", "S", "C", "Ab", "Ap"}; //M: Mover, S: Saltar, C: Cerrar, Ab: Abrir, Ap: Apagar
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

    public void VaciarContenido()
    {
        Instrucciones.text = "";
        //inputText.text = "";
    }

    public void EnviarInstrucciones()
    {
        //instruccionesUsuario2 = inputText.text;
        //Debug.Log(instruccionesUsuario2);
        instruccionesUsuario = Instrucciones.text;
        Debug.Log(instruccionesUsuario);

        string[] instrucciones = instruccionesUsuario.Split(' ');
        for (int i = 0; i < instrucciones.Length; i++)
        {
            //if(comandos.Contains(letra))
            //{

            //}

            //string palabra = instrucciones[i];
            //if(comandos.Contains(palabra[0]))

            if(instrucciones[i] == "Mover")
            {
                if (instrucciones[i + 1] == "derecha")
                {
                    var duration = Int16.Parse(instrucciones[i + 2]);
                    player.MoveRight(duration);
                }
                else if(instrucciones[i + 1] == "izquierda")
                {
                    player.MoveLeft(Int16.Parse(instrucciones[i + 2]));
                }
            }
            else if (instrucciones[i] == "Saltar")
            {
                var force = Int16.Parse(instrucciones[i + 1]);
                player.Jump(force);
            }
        }
        
        
    }
}
