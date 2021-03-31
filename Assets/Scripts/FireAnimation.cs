using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    private Game_Controller game_controller;

    void Start()
    {
        game_controller = FindObjectOfType<Game_Controller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Extintor") || other.gameObject.CompareTag("Piso"))
        {
            game_controller.fuegos_activos -= 1;
            Destroy(gameObject);
            //Debug.Log("Fuego apagado!");
        }
    }
}
