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

    public void Open()
    {
        if (!is_open)
        {
            GetComponent<Animator>().SetTrigger("Open");
            is_open = true;
            game_controller.puertas_abiertas += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            if (!is_open)
            {
                GetComponent<Animator>().SetTrigger("Open");
                //print("Abrid!");
                is_open = true;
                game_controller.puertas_abiertas += 1;
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Close");
                //print("Cerrad!");
                is_open = false;
                game_controller.puertas_abiertas -= 1;
            }
        }
    }
}
