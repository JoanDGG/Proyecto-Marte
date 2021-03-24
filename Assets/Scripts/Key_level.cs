using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_level : MonoBehaviour
{
    public LevelGateAnimation level_gate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            GetComponent<SpriteRenderer>().enabled = false;

            Debug.Log("Llave encontrada!!");
            level_gate.Open();
            Destroy(gameObject);
        }
    }
}
