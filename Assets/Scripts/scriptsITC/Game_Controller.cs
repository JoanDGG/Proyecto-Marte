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
    private int nivel = 1;
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
    public GameObject texto;
    private Text aviso;
    public GameObject aviso_nivel;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;

    public static Game_Controller instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        constante_original = constante;
        aviso = GameObject.Find("Aviso").GetComponent<Text>();
        Spawn(PlayerPrefs.GetInt("Nivel3", 1));
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
        if (accidentes <= 0)
        {
            oleada = false;
            if (integridad > 0 && fuegos_activos <= 0 && puertas_abiertas <= 0)
            {
                print("Nivel terminado!!");
                aviso_nivel.SetActive(true);
                Desbloquear(nivel);
            }
        }
        else
        {
            if (fuegos_activos > 0 || puertas_abiertas > 0)
            {
                integridad--;
                //print(fuegos_activos);
            }
            else
            {
                aviso.text = "Estable";
            }
            if (integridad <= 0)
            {
                //print("Perdiste!!");
                aviso.text = "Perdiste!";
            }
        }

        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        valor = integridad / 7000;
        barra.value = valor;
        barra.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color =
                Color.Lerp(Mincolor, Maxcolor, valor);
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
        aviso.text = "Fuego!!";
    }

    public void Puerta(int nivel)
    {
        if(nivel == 1)
        {
            puerta1.GetComponent<GateAnimation>().Open();
            Debug.Log("Puerta 1 Abierta!");
        }
        else if(nivel == 2)
        {
            puerta2.GetComponent<GateAnimation>().Open();
            Debug.Log("Puerta 2 Abierta!");
        }
        else if(nivel == 3)
        {
            float[] puertas = { 0.5f, 0.5f };
            float puerta = Choose(puertas);
            if(puerta == 1)
            {
                puerta3.GetComponent<GateAnimation>().Open();
                Debug.Log("Puerta 3 Abierta!");
            }
            else
            {
                puerta4.GetComponent<GateAnimation>().Open();
                Debug.Log("Puerta 4 Abierta!");
            }
        }
        aviso.text = "Puerta Abierta!";
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
        integridad = 7000.0f;
        nivel += 1;
        Guardar();
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
        PlayerPrefs.SetInt("Nivel3", nivel);
        PlayerPrefs.Save();
    }

    public void Spawn(int lugar)
    {
        nivel = lugar;
        integridad = 7000.0f;
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
