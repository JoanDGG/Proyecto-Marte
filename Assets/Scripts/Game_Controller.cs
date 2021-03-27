using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public static bool is_editing;
    public static bool oleada = true;
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

    public Transform FireEffect;

    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        is_editing = false;
        player = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
                            //Normal=95%, Fuego = 0.1%, Puertas = 0.8%
        float[] problemas = {        0.95f,         0.001f,           0.0008f};

        if (oleada)
        {
            //Llamada aleatoria para crear fuego o abrir puertas solo en estados de emergencia
            float problema = Choose(problemas);
            if (problema == 1)
            {
                Fuego(nivel);
            }
            else if (problema == 2)
            {
                Puerta(nivel);
            }
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
            xMin = 27.5f;
            xMax = 50.0f;
        }

        float x = Mathf.Clamp(player.transform.position.x + Random.Range(-8.0f, 8.0f), xMin, xMax);
        float y = player.transform.position.y + Random.Range(0.0f, 2.0f);

        Vector3 spawn = new Vector3(x, y, 0);
        Instantiate(FireEffect, spawn, player.transform.rotation);
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
        Debug.Log("Desbloquear " + llave.ToString());
        if (llave == 1)
        {
            key1.SetActive(true);
        }
        else if (llave == 2)
        {
            key2.SetActive(true);
        }
        else if(llave == 3)
        {
            key3.SetActive(true);
        }
        nivel += 1;
    }

    public void FaseUno()
    {
        Desbloquear(1);
    }

    public void Edit()
    {
        is_editing = !is_editing;
        //Debug.Log("Cambio");
    }
}
