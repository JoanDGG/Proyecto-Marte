using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasEjecuta : MonoBehaviour
{
    public void JugarCohete()
    {
        SceneManager.LoadScene("MisionCohete-1");
    }

    public void JugarITC()
    {
        SceneManager.LoadScene("MinijuegoITC");
    }
}
