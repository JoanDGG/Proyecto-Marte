using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public static bool is_editing;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    // Start is called before the first frame update
    void Start()
    {
        is_editing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desbloquear(int llave)
    {
        Debug.Log("Desbloquear " + llave.ToString());
        if (llave == 1)
        {
            key1.SetActive(true);
        }
        else if (llave == 2)
        {
            key2.SetActive(true);
        }
        else if(llave == 3)
        {
            key3.SetActive(true);
        }
    }

    public void Edit()
    {
        is_editing = !is_editing;
        Debug.Log("Cambio");
    }
}
