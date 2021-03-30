using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Extintor"))
        {
            Destroy(gameObject);
            Debug.Log("Fuego apagado!");
        }
    }
}
