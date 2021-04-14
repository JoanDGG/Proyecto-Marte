using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLifes : MonoBehaviour
{
    public int vidas = 3;

    public static RocketLifes instance;
    
    private void Awake()
    {
        instance = this;
    }
}
