using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RelojLab : MonoBehaviour
{

    public GameObject alarma;
    public Text tempo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(reloj());
        alarma.GetComponent<Image>().enabled = false;
        tempo.GetComponent<Text>().text = (GameManager.reloj >= 0) ? GameManager.reloj.ToString() : "0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator reloj()
    {
        while (!GameManager.perder)
        {
            print(GameManager.tiempo);
            yield return new WaitForSeconds(1.0f);
            GameManager.tiempo += 1;
            GameManager.reloj = GameManager.evento ? (GameManager.tiempoEvento - GameManager.tiempo) : (GameManager.tiempoLimite - GameManager.tiempo);
            tempo.GetComponent<Text>().text = (GameManager.reloj >= 0) ? GameManager.reloj.ToString() : "0";
            alarma.GetComponent<Image>().enabled = (GameManager.tiempo == GameManager.tiempoLimite - 6) ? true : (GameManager.tiempo == GameManager.tiempoLimite - 4) ? true : (GameManager.tiempo == GameManager.tiempoLimite - 2) ? true : false;
            if (GameManager.tiempo >= GameManager.tiempoLimite)
            {
                alarma.GetComponent<Image>().enabled = false;
                SceneManager.LoadScene("NivelBio");
            }
        }
    }
}
