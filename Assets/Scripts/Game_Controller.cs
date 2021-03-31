using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public static bool is_editing = false;
    public bool oleada = true;
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
    private int accidentes = 15;
    private float integridad = 6000.0f;
    private float valor;
    private Color Maxcolor = Color.green;
    private Color Mincolor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        constante_original = constante;
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
                //print("Nivel terminado!!");
                Desbloquear(nivel);
            }
        }

        if (fuegos_activos > 0 || puertas_abiertas > 0)
        {
            integridad--;
            //print(fuegos_activos);
        }
        if(integridad <= 0)
        {
            print("Perdiste!!");
        }

        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        valor = integridad / 6000;
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
        Debug.Log("Fuego!!");
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
            accidentes = 25;
            integridad = 6000.0f;
            puertas_abiertas = 0;
        }
        else if (llave == 2)
        {
            key2.SetActive(true);
            accidentes = 45;
            integridad = 6000.0f;
            puertas_abiertas = 0;
        }
        else if(llave == 3)
        {
            key3.SetActive(true);
        }
        nivel += 1;
    }

    public void Edit()
    {
        is_editing = !is_editing;
        //Debug.Log("Cambio");
    }
}
