using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public static bool is_editing = false;
    public bool oleada = false;
    public int puertas_abiertas = 0;
    public int fuegos_activos = 0;
    public int nivel = 1;
    //Puertas nivel 1
    public GameObject puerta1;

    //Puertas nivel 2
    public GameObject puerta2;

    //Puertas nivel 3
    public GameObject puerta3;
    public GameObject puerta4;

    //Llaves
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public GameObject FireEffect;

    public GameObject player;

    public Slider barra;

    private int constante = 300;
    private int constante_original;

                           //Normal=99%, Fuego = 0.55%, Puertas = 0.35%
    private float[] problemas = { 0.99f,       0.0055f,         0.0035f };
    private float problema;
    private int accidentes = 10;
    private float integridad = 7000.0f;
    private float valor;
    private Color Maxcolor = Color.green;
    private Color Mincolor = Color.red;
    private bool pausa = false;
    private string final = "false";
    public GameObject texto;
    private Text aviso;
    public GameObject aviso_nivel;
    public GameObject imagen_alerta;
    public AudioSource Alerta;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;

    public float puntaje = 7000.0f;

    public static Game_Controller instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.nivelGlobal = 2;
        constante_original = constante;
        aviso = GameObject.Find("Aviso").GetComponent<Text>();
        puntaje = PlayerPrefs.GetFloat("Nivel3Puntaje", 7000.0f);
        int niv = PlayerPrefs.GetInt("Nivel3", 1);
        final = PlayerPrefs.GetString("Nivel3Fin", "false");
        if(final == "true" || niv >= 4)
        {
            puntaje = 7000.0f;
            final = "false";
            nivel = 1;
        }
        else
        {
            nivel = niv;
        }
        print(puntaje);
        Spawn(nivel);
        Pausar();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (oleada && accidentes > 0)
        {
            //Llamada aleatoria para crear fuego o abrir puertas solo en estados de emergencia
            problema = Choose(problemas);
            if (problema == 1)
            {
                Fuego(nivel);
                --accidentes;
            }
            else if (problema == 2)
            {
                Puerta(nivel);
                --accidentes;
            }
            --constante;
            if (constante == 0)
            {
                Fuego(nivel);
                --accidentes;
                constante = constante_original;
                //print("Constante");
            }
        }
        else if (accidentes <= 0)
        {
            oleada = false;
            if (integridad > 0 && fuegos_activos <= 0 && puertas_abiertas <= 0)
            {
                if (final == "false")
                {
                    print("Nivel terminado!!");
                    aviso_nivel.SetActive(true);
                    Desbloquear(nivel);
                }
            }
        }
        if (fuegos_activos <= 0 && puertas_abiertas <= 0)
        {
            aviso.text = "Estable";
        }
        if ((fuegos_activos > 0 || puertas_abiertas > 0) && integridad >= 0)
        {
            integridad--;
            puntaje -= 0.25f;
            //print(integridad);
            if(puertas_abiertas > 0)
            {
                aviso.text = "Puerta Abierta!";
            }
            else if (fuegos_activos > 0)
            {
                aviso.text = "Fuego!!";
            }
        }
        if (integridad <= 0)
        {
            print("Perdiste!!");
            aviso.text = "Perdiste!";
        }
        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        valor = integridad / 7000;
        barra.value = valor;
        barra.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color =
                Color.Lerp(Mincolor, Maxcolor, valor);
        if(integridad < 2000)
        {
            imagen_alerta.SetActive(true);
            Alerta.enabled = true;
        }
    }

    public void Fuego(int nivel)
    {
        float xMin = -9.0f;
        float xMax = 10.0f;
        if(nivel == 2)
        {
            xMin = 11.0f;
            xMax = 26.0f;
        }
        else if(nivel == 3)
        {
            xMin = 35.0f;
            xMax = 50.0f;
        }

        float x = Mathf.Clamp(player.transform.position.x + Random.Range(-8.0f, 8.0f), xMin, xMax);
        float y = player.transform.position.y + Random.Range(0.0f, 2.0f);

        Vector3 spawn = new Vector3(x, y, 0);
        Instantiate(FireEffect.transform, spawn, player.transform.rotation);
        fuegos_activos++;
        //Debug.Log("Fuego!!");
    }

    public void Puerta(int nivel)
    {
        if(nivel == 1)
        {
            puerta1.GetComponent<GateAnimation>().Open();
            //Debug.Log("Puerta 1 Abierta!");
        }
        else if(nivel == 2)
        {
            puerta2.GetComponent<GateAnimation>().Open();
            //Debug.Log("Puerta 2 Abierta!");
        }
        else if(nivel == 3)
        {
            float[] puertas = { 0.5f, 0.5f };
            float puerta = Choose(puertas);
            if(puerta == 1)
            {
                puerta3.GetComponent<GateAnimation>().Open();
                //Debug.Log("Puerta 3 Abierta!");
            }
            else
            {
                puerta4.GetComponent<GateAnimation>().Open();
                //Debug.Log("Puerta 4 Abierta!");
            }
        }
        
    }

    public float Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    public void Desbloquear(int llave)
    {
        //Debug.Log("Desbloquear " + llave.ToString());
        if (llave == 1)
        {
            key1.SetActive(true);
            accidentes = 15;
            puertas_abiertas = 0;
            fuegos_activos = 0;
        }
        else if (llave == 2)
        {
            key2.SetActive(true);
            accidentes = 20;
            puertas_abiertas = 0;
            fuegos_activos = 0;
        }
        else if(llave == 3)
        {
            key3.SetActive(true);
        }
        print(nivel);
        if (nivel >= 3)
        {
            final = "true";
        }
        nivel += 1;
        integridad = 7000.0f;
        puntaje = Mathf.Clamp(puntaje+50, 0, 7000);
        imagen_alerta.SetActive(false);
        Alerta.enabled = false;
        Guardar();
        print("Puntaje: " + puntaje.ToString());
    }

    public void Edit()
    {
        is_editing = !is_editing;
        //Debug.Log("Cambio");
    }

    public void Pausar()
    {
        pausa = !pausa;

        texto.SetActive(pausa);
        Time.timeScale = pausa ? 0 : 1;
    }

    public void Guardar()
    {
        print("guardar" + nivel);
        PlayerPrefs.SetFloat("Nivel3Puntaje", puntaje);
        PlayerPrefs.SetString("Nivel3Fin", final);
        PlayerPrefs.SetInt("Nivel3", nivel);
        PlayerPrefs.Save();
    }

    public void Spawn(int lugar)
    {
        integridad = 7000.0f;
        imagen_alerta.SetActive(false);
        print("Spawn " + lugar);
        nivel = lugar;
        if (lugar == 1)
        {
            oleada = true;
            player.transform.position = spawn1.position;
        }
        else if(lugar == 2)
        {
            accidentes = 15;
            oleada = false;
            player.transform.position = spawn2.position;
            puertas_abiertas = 0;
            fuegos_activos = 0;
        }
        else if (lugar == 3)
        {
            accidentes = 20;
            oleada = false;
            player.transform.position = spawn3.position;
            puertas_abiertas = 0;
            fuegos_activos = 0;
        }
    }
}
