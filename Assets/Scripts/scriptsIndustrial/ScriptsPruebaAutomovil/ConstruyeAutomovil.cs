using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script para construir el automóvil igual que como estaba en el menu.
PROBAR COPIANDO LA FUNCION DE CAMBIAPARTE RECONSTRUIR PREFAB
 */

public class ConstruyeAutomovil : MonoBehaviour
{
    private GameObject autoDesdeMenu;
    public GameObject autoEnPrueba;

    // Start is called before the first frame update
    void Start()
    {
        autoDesdeMenu = GameObject.FindGameObjectWithTag("Auto");
        autoEnPrueba = autoDesdeMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
