using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script para obtener las cualidades dependiendo de las partes escogidas y asignarlas al automóvil.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 21 de abril de 2021
 */

public class ObtenCualidades : MonoBehaviour
{

    // Tablas de hash para mapear las partes del automóvil con sus respectivas cualidades.
    Hashtable partesAVolumenCuerpo = new Hashtable()
        {
            {0, 0.633f},
            {1, 0.8667f },
            {2, 1f }
        };

    Hashtable partesAFriccionAgarreLlantas = new Hashtable()
        {
            {0, 0.1f},
            {1, 0.5f},
            {2, 1f}
        };

    Hashtable partesAFuerzaFrenos = new Hashtable()
        {
            {0, 0.3f},
            {1, 0.4f},
            {2, 1f}
        };

    Hashtable partesAAmortiguamientoSuspension = new Hashtable()
        {
            {0, 0.6f},
            {1, 0.85f},
            {2, 1f}
        };

    Hashtable partesAResistenciaChasis = new Hashtable()
        {
            {0, 0.1f},
            {1, 0.6f},
            {2, 1f},
            {3, 0.1f},
            {4, 0.6f},
            {5, 1f},
            {6, 0.1f},
            {7, 0.6f},
            {8, 1f}
        };

    Hashtable partesAPotenciaMotor = new Hashtable()
        {
            {6, 0.15f},
            {7, 0.3f },
            {8, 1f}
        };


    // Start is called before the first frame update
    void Start()
    {
        // Uso las tablas de hash para establecer las cualidades del automóvil.

        GameManager.volumen = GameManager.volumenMaximo * (float)partesAVolumenCuerpo[(int)GameManager.cuerpo[1]];
        GameManager.friccionLlantasEnHielo = GameManager.friccionLlantasEnHieloMaxima * (float)partesAFriccionAgarreLlantas[(int)GameManager.llantas[1]];
        GameManager.friccionLlantasEnHielo = GameManager.friccionLlantasEnHieloMaxima * (float)partesAFriccionAgarreLlantas[(int)GameManager.llantas[1]];
        GameManager.friccionLlantasArranque = GameManager.friccionLlantasArranqueMaxima * (float)partesAFriccionAgarreLlantas[(int)GameManager.llantas[1]];
        GameManager.fuerzaFreno = GameManager.fuerzaFrenoMaxima * (float)partesAFuerzaFrenos[(int)GameManager.frenos[1]];
        GameManager.calidadAmortiguamiento = GameManager.calidadAmortiguamientoMaxima * (float)partesAAmortiguamientoSuspension[(int)GameManager.suspensiones[1]];
        GameManager.resistencia = GameManager.resistenciaMaxima * (float)partesAResistenciaChasis[(int)GameManager.chasis[1]];
        GameManager.fuerzaMotor = GameManager.fuerzaMotorMaxima * (float)partesAPotenciaMotor[(int)GameManager.motor[1]];
        GameManager.velocidadMaxima = GameManager.velocidadMaximaMaxima * (float)partesAPotenciaMotor[(int)GameManager.motor[1]];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
