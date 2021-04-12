using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruye : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("DESTRUYEEEEEEEE!!!!!!");
        Destroy(other.gameObject);
    }
}
