using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprRenderer;
    private Animator anim;
    private Image img;
    public GameObject go;
    public GameObject osc;
    //public GameObject tor;
    public GameObject alarma;
    public GameObject[] evento = new GameObject[4];
    public Text tempo;
    public float velocidad = 7;
    private GameObject[] tor = new GameObject[3];
    private AudioSource audio;
    public GameObject[] Prediccion = new GameObject[3];
    public Sprite[] eventos = new Sprite[4];
    public GameObject camara;
    private AudioSource musica;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        osc.GetComponent<Image>().enabled = false;
        alarma.GetComponent<Image>().enabled = false;
        tempo.GetComponent<Text>().text = (GameManager.reloj >= 0) ? GameManager.reloj.ToString() : "0";
        musica = camara.GetComponent<AudioSource>();
        musica.mute = false;
        audio = alarma.GetComponent<AudioSource>();
        audio.mute = true;
        StartCoroutine(reloj());
        if (GameManager.primero)
        {
            musica.Play();
            for (int i = 0; i < GameManager.oleada; i++)
            {
                GameManager.clima[i] = Random.Range(0, evento.Length);
                print("Elegi " + GameManager.clima[i].ToString());
            }
            GameManager.primero = false;
        }
        for (int i = 0; i < GameManager.oleada; i++)
        {
            tor[i] = evento[GameManager.clima[i]];
            Prediccion[i].SetActive(true);
            Prediccion[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = eventos[GameManager.clima[i]];
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(movHorizontal * velocidad, movVertical * velocidad);
        float ABSvelocidad = Mathf.Abs((rigidbody.velocity.x + rigidbody.velocity.y));
        anim.SetFloat("velocidad", ABSvelocidad);
        if (rigidbody.velocity.x > 0.1)
        {
            sprRenderer.flipX = false;
        }
        else if (rigidbody.velocity.x < -0.1)
        {
            sprRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Puerta"))
        {
            SceneManager.LoadScene("Laboratorio");
        }
        else if(other.gameObject.CompareTag("Tormenta")){
            print("TORMENTA!!!!!!!!!!!!");
        }
    }

    IEnumerator reloj()
    {
        while(!GameManager.perder)
        {
            print(GameManager.tiempo);
            yield return new WaitForSeconds(1.0f);
            GameManager.tiempo += 1;
            GameManager.reloj = GameManager.evento ? (GameManager.tiempoEvento - GameManager.tiempo) : (GameManager.tiempoLimite - GameManager.tiempo);
            tempo.GetComponent<Text>().text = (GameManager.reloj >= 0) ? GameManager.reloj.ToString() : "0";
            bool Audio = ((GameManager.tiempo >= GameManager.tiempoLimite - 6) || GameManager.evento) ? false : true;
            alarma.GetComponent<Image>().enabled = (GameManager.tiempo == GameManager.tiempoLimite - 6) ? true : (GameManager.tiempo == GameManager.tiempoLimite - 4) ? true : (GameManager.tiempo == GameManager.tiempoLimite - 2) ? true : false;
            audio.mute = Audio;
            musica.mute = !Audio;
            if (!Audio)
            {
                musica.Play();
            }
            else
            {
                audio.Play();
            }
            if (GameManager.tiempo >= GameManager.tiempoLimite && !GameManager.evento)
            {
                audio.mute = true;
                musica.mute = true;
                alarma.GetComponent<Image>().enabled = false;
                osc.GetComponent<Image>().enabled = true;
                yield return new WaitForSeconds(0.25f);
                go.transform.position = new Vector3(-1.5f, 1.5f, 0.0f);
                yield return new WaitForSeconds(0.25f);
                GameManager.tiempo = 0;
                GameManager.evento = true;
                osc.GetComponent<Image>().enabled=false;
                for (int i = 0; i < GameManager.oleada; i++)
                {
                    Instantiate(tor[i]);
                    /*if(tor[i].tag == "Calor" || tor[i].tag == "Frio")
                    {
                        Image image = tor[i].GetComponent<Image>();
                        Color c = image.color;
                        image.color = c;
                        for (float j = 0.0f; j <= 0.75f; j += 0.01f)
                        {
                            c.a = j;
                            image.color = c;
                        }
                        for (float j=0.75f; j >= 0.0f; j -= 0.01f)
                        {
                            c.a = j;
                            image.color = c;
                        }
                    }*/
                    yield return new WaitForSeconds(4.0f);
                }
            }
            else if (GameManager.tiempo >= GameManager.tiempoEvento && GameManager.evento)
            {
                GameManager.oleada++;
                if (GameManager.oleada <= 3)
                {
                    osc.GetComponent<Image>().enabled = true;
                    yield return new WaitForSeconds(0.25f);
                    go.transform.position = new Vector3(6.5f, 0.8f, 0.0f);
                    yield return new WaitForSeconds(0.25f);
                    GameManager.tiempo = 0;
                    GameManager.evento = false;
                    osc.GetComponent<Image>().enabled = false;
                    for (int i = 0; i < GameManager.oleada; i++)
                    {
                        GameManager.clima[i] = Random.Range(0, evento.Length);
                        print("Elegi " + GameManager.clima[i].ToString());
                        tor[i] = evento[GameManager.clima[i]];
                        Prediccion[i].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = eventos[GameManager.clima[i]];
                    }
                    Prediccion[GameManager.oleada - 1].SetActive(true);
                }
            }
            if (GameManager.perder) //Perder
            {
                print("Perdiste, tus patatas murieron");
                Application.Quit();
            }
            else if(GameManager.oleada>=4) //Ganar
            {
                print("Felicidades tus patatas sobrevivieron");
                Application.Quit();
            }
        }
    }
}
