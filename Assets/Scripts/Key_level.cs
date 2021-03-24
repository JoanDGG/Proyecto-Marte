using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_level : MonoBehaviour
{
    public int id=1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GetComponent<SpriteRenderer>().enabled = false;

            Debug.Log("Llave encontrada!!");
            Destroy(gameObject);
        }
    }
}
