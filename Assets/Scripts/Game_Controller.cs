using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public static bool is_editing;

    // Start is called before the first frame update
    void Start()
    {
        is_editing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Edit()
    {
        is_editing = !is_editing;
        Debug.Log("Cambio");
    }
}
