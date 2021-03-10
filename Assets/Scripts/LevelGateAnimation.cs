using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGateAnimation : MonoBehaviour
{
    public void Open()
    {
        GetComponent<Animator>().SetTrigger("Open");
        print("Nivel terminado!");
        gameObject.SetActive(false);
    }
}
