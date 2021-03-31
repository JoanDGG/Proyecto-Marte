using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGateAnimation : MonoBehaviour
{
    private Game_Controller game_controller;

    void Start()
    {
        game_controller = FindObjectOfType<Game_Controller>();
    }

    public void Open()
    {
        GetComponent<Animator>().SetTrigger("Open");
        print("Nivel terminado!");
    }

    public void Close()
    {
        GetComponent<Animator>().SetTrigger("Close");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Llave"))
        {
            if (gameObject.name == "Level_gate 1-2") {
                GameObject.Find("Level_gate 1").GetComponent<LevelGateAnimation>().Close();
                GetComponent<Animator>().SetTrigger("Open");
                print("Empieza el nivel!");
                game_controller.oleada = true;
            }
            else if (gameObject.name == "Level_gate 2-3") {
                GameObject.Find("Level_gate 2").GetComponent<LevelGateAnimation>().Close();
                GetComponent<Animator>().SetTrigger("Open");
                print("Empieza el nivel!");
                game_controller.oleada = true;
            }
        }
    }
}
