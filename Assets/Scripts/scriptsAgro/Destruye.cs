using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruye : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("DESTRUYEEEEEEEE!!!!!!");
        Destroy(other.gameObject);
        print("Felicidades! Ganaste 0.5 puntos");
        GameManager.puntuacion += 0.5f;
    }
}
