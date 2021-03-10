using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Detecta la colision entre la moneda y el personaje
 */


public class MonedaItem : MonoBehaviour
{

    // Se ejecuta cuando hay una colision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            GetComponent<SpriteRenderer>().enabled = false;

            Debug.Log("Moneda recogida");
            Destroy(gameObject, 0.2f);
        }
    }
}
