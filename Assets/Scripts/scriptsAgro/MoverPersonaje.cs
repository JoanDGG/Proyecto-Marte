using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MoverPersonaje : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprRenderer;
    private Animator anim;
    private Image img;
    public GameObject go;
    public GameObject osc;
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
    public GameObject arena;
    public GameObject cuest;
    public Cuestionario cuestionario;
    private GameObject pausa;
    public GameObject resultados;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        GameManager.nivelGlobal = 4;
        pausa = (GameObject)GameObject.Find("Canvas/Pausar");
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
        if(GameManager.tiempo < GameManager.tiempoLimite - 6)
        {
            musica.Play();
        }
        if (GameManager.primero)
        {
            GameManager.tiempo = 0;
            GameManager.tiempoLimite = 60;
            GameManager.evento = false;
            GameManager.tiempoEvento = 5;
            GameManager.reloj = GameManager.tiempoLimite;
            GameManager.resist[0] = false;
            GameManager.resist[1] = false;
            GameManager.resist[2] = false;
            GameManager.resist[3] = false;
            GameManager.perder = false;
            GameManager.pagina = 0;
            GameManager.genes[0] = 0;
            GameManager.genes[1] = 0;
            GameManager.genes[2] = 0;
            GameManager.oleada = 1;
            GameManager.respondido = false;
            GameManager.puntuacion = 0.0f;
            GameManager.tiempoInicioNivel = System.DateTime.Now;
            GameManager.clima[0] = -1;
            GameManager.clima[1] = -1;
            GameManager.clima[2] = -1;
            for (int i = 0; i < GameManager.oleada; i++)
            {
                int eleccion=-1;
                while (GameManager.clima.Contains(eleccion))
                {
                    eleccion = Random.Range(0, evento.Length);
                }
                GameManager.clima[i] = eleccion;
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
        StartCoroutine(reloj());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("h") && Input.GetKey("a") && Input.GetKey("c") && Input.GetKey("k")) //Herramienta de desarrollador
        {
            print("Hackerman");
            for (int i = 0; i < 4; i++) //Para hacer pruebas
            {
                GameManager.resist[i] = true;
            }

        }
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
        while(!GameManager.perder && GameManager.oleada<4)
        {
            print(GameManager.tiempo);
            yield return new WaitForSeconds(1.0f);
            GameManager.tiempo += 1;
            GameManager.reloj = GameManager.evento ? (GameManager.tiempoEvento - GameManager.tiempo) : (GameManager.tiempoLimite - GameManager.tiempo);
            tempo.GetComponent<Text>().text = (GameManager.reloj >= 0) ? GameManager.reloj.ToString() : "0";
            bool Audio = ((GameManager.tiempo >= GameManager.tiempoLimite - 6) && !GameManager.evento) ? false : true;
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
            if (GameManager.tiempo >= GameManager.tiempoLimite && !GameManager.evento) //Entrar al cuarto de seguridad
            {
                pausa.SetActive(false);
                GameManager.tiempoLimite += 30;
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
                    if (tor[i].tag == "Calor" || tor[i].tag == "Frio")
                    {
                        int r = (tor[i].tag == "Calor") ? 255 : 0;
                        int g = (tor[i].tag == "Calor") ? 216 : 193;
                        int b = (tor[i].tag == "Calor") ? 6 : 255;
                        GameObject peligro = GameObject.Find("Canvas/Calor-Frio");
                        Image image = peligro.GetComponent<Image>();
                        image.enabled = true;
                        image.color = new Color32((byte) r, (byte) g, (byte) b, 255);
                        image.canvasRenderer.SetAlpha(0);
                        image.CrossFadeAlpha(1, 3, false);
                        yield return new WaitForSeconds(2.0f);
                        image.CrossFadeAlpha(0, 3, false);
                        yield return new WaitForSeconds(2.0f);
                        image.enabled = false;
                    }
                    else if (tor[i].tag == "Sequia")
                    {
                        arena.SetActive(true);
                        yield return new WaitForSeconds(4.0f);
                        arena.SetActive(false);
                    }
                    else
                    {
                        yield return new WaitForSeconds(4.0f);
                    }
                }
            }
            else if (GameManager.tiempo >= GameManager.tiempoEvento && GameManager.evento) //Salir del cuarto de seguridad
            {
                cuest.SetActive(true);
                cuestionario.DesbloquearPreguntas();
                while (!GameManager.respondido)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                GameManager.oleada++;
                GameManager.respondido = false;
                cuest.SetActive(false);
                pausa.SetActive(true);
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
                        int eleccion = Random.Range(0, evento.Length);
                        while (GameManager.clima.Contains(eleccion))
                        {
                            eleccion = Random.Range(0, evento.Length);
                        }
                        GameManager.clima[i] = eleccion;
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
                resultados.SetActive(true);
                resultados.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Has perdido";
                resultados.transform.GetChild(0).gameObject.SetActive(false);
                resultados.transform.GetChild(1).gameObject.SetActive(false);
                float puntos = (float)GameManager.puntuacion;
                BarraResultados.instance.SetValue(puntos / 5.0f);
                GameManager.tiempoFinNivel = System.DateTime.Now;
                GameManager.primero = true;
            }
            else if(GameManager.oleada>=4) //Ganar
            {
                GameManager.tiempoFinNivel = System.DateTime.Now;
                GameManager.primero = true;
            }
            //Después de cada oleada
            GameManager.tiempoFinNivel = System.DateTime.Now;
        }
        if (GameManager.puntuacion > 5.0f)
        {
            GameManager.puntuacion = 5.0f;
        }
        pausa.SetActive(false);
        print("Tu puntuación fue de " + GameManager.puntuacion.ToString() + " estrellas");
    }
}
