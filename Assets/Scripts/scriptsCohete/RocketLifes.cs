using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Este script detecta el número de vidas del cohete
* Autor: Daniel Garcia Barajas
*/
public class RocketLifes : MonoBehaviour
{
    public int vidas = 3;

    public static RocketLifes instance;
    
    private void Awake()
    {
        instance = this;
    }
}
