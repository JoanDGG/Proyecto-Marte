using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionMision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("SeleccionCohete")){
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            print("¿Quieres entrar a esta mision?");
        }


    }
}
