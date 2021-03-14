using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class is_grounded_controller : MonoBehaviour
{
    public static bool is_grounded;
    public static bool is_landing;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Piso"))
        {
            is_grounded = true;
            print("Esta en piso");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piso"))
        {
            is_grounded = false;
            print("No esta en piso");
        }
    }
}
