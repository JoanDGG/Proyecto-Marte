using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
    public static bool is_open;
    private LevelGateAnimation level_gate;
    // Start is called before the first frame update
    void Start()
    {
        is_open = false;
        level_gate = FindObjectOfType<LevelGateAnimation>();
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
                level_gate.Open();
            }
        }
    }
}
