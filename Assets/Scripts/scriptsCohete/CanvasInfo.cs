using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    public Canvas canvasInfo;

    // Start is called before the first frame update
    void Start()
    {
        canvasInfo.enabled = true; 
    }

    public void JugarNivel()
    {
        canvasInfo.enabled = false;
    } 
}
