using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
    public static bool is_open;
    private Game_Controller game_controller;
    // Start is called before the first frame update
    void Start()
    {
        is_open = false;
        game_controller = FindObjectOfType<Game_Controller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            if (!is_open)
            { 
                GetComponent<Animator>().SetTrigger("Open");
                print("Abrid!");
                is_open = true;
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Close");
                print("Cerrad!");
                is_open = false;
                game_controller.Desbloquear(1);
            }
        }
    }
}
