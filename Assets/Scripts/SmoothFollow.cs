using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Descripcion:
Este script maneja el movimiento de la camara de forma suave, recibe los parametros como los
limites hasta donde puede llegar y los margenes que le dan al objetivo para moverse sin que la
camara se mueva

Autor: Joan Daniel Guerrero Garcia
*/

public class SmoothFollow : MonoBehaviour
{
    public float xMargin = 1.0f;    // Cantidad en x para que no se mueva mientras que el objetivo lo haga
    public float yMargin = 3.0f;    // Cantidad en y para que no se mueva mientras que el objetivo lo haga

    public float xSmooth = 10.0f;   // Valor de la suavidad con la que la camara se mueve en el eje x
    public float ySmooth = 10.0f;   // Valor de la suavidad con la que la camara se mueve en el eje y

    public Vector2 maxYandX;        // Limites maximos en x & y para que la camara se mueva
    public Vector2 minYandX;        // Limites minimos en x & y para que la camara se mueva

    public GameObject target;       // GameObject que seguira

    private Transform CameraTarget; // Transform del GameObject objetivo

    void Awake()
    {
        CameraTarget = target.transform;
    }

    bool CheckXMargin()     // Revisa si la posicion en x del personaje supera al margen en el eje x
    {
        return Mathf.Abs(transform.position.x - CameraTarget.position.x) > xMargin;
    }

    bool CheckYMargin()     // Revisa si la posicion en x del personaje supera al margen en el eje y
    {
        return Mathf.Abs(transform.position.y - CameraTarget.position.y) > yMargin;
    }

    void FixedUpdate()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if(CheckXMargin())
        {
            // Se utiliza la funcion Lerp para hacer una transicion suave con la camara hacia el target
            targetX = Mathf.Lerp(transform.position.x, CameraTarget.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, CameraTarget.position.y, ySmooth * Time.deltaTime);
        }

        // Se utiliza la funcion Clamp para mover la camara hacia el target dentro de los limites en x & y
        targetX = Mathf.Clamp(targetX, minYandX.x, maxYandX.x);
        targetY = Mathf.Clamp(targetY, minYandX.y, maxYandX.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
