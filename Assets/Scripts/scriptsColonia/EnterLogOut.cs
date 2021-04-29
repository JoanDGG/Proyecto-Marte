using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLogOut : MonoBehaviour
{
    public GameObject BotonLogOut;
    private void OnTriggerEnter2D(Collider2D other)
    {
        BotonLogOut.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        BotonLogOut.SetActive(false);
    }
}
