using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RelojLab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(reloj());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.tiempo >= GameManager.tiempoLimite)
        {
            SceneManager.LoadScene("NivelBio");
        }
    }

    IEnumerator reloj()
    {
        while (!GameManager.perder)
        {
            print(GameManager.tiempo);
            yield return new WaitForSeconds(1.0f);
            GameManager.tiempo += 1;
        }
    }
}
