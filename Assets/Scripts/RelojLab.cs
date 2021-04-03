using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RelojLab : MonoBehaviour
{

    public GameObject alarma;
    public Text tempo;
    private AudioSource audio;
    public GameObject camara;
    private AudioSource musica;
    public GameObject Imagen;
    public Sprite[] eventos = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(reloj());
        alarma.GetComponent<Image>().enabled = false;
        tempo.GetComponent<Text>().text = (GameManager.reloj >= 0) ? GameManager.reloj.ToString() : "0";
        audio = alarma.GetComponent<AudioSource>();
        musica = camara.GetComponent<AudioSource>();
        musica.mute = false;
        audio.mute = true;
        Imagen.GetComponent<Image>().sprite = eventos[GameManager.clima];
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
            bool Audio = (GameManager.tiempo >= GameManager.tiempoLimite - 6) ? false : true;
            alarma.GetComponent<Image>().enabled = (GameManager.tiempo == GameManager.tiempoLimite - 6) ? true : (GameManager.tiempo == GameManager.tiempoLimite - 4) ? true : (GameManager.tiempo == GameManager.tiempoLimite - 2) ? true : false;
            musica.mute = !Audio;
            audio.mute = Audio;
            if (GameManager.tiempo >= GameManager.tiempoLimite)
            {
                alarma.SetActive(false);
                SceneManager.LoadScene("NivelBio");
            }
        }
    }
}
