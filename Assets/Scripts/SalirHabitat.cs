using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SalirHabitat : MonoBehaviour
{

    public Dropdown[] listas = new Dropdown[3];
    public GameObject adn;
    public GameObject info;
    public GameObject main;

    public void Salir()
    {
        SceneManager.LoadScene("NivelBio");
    }

    public void Cancelar()
    {
        print("GENES CANCELADOS");
        GameManager.resTorAux = false;
        GameManager.resFrioAux = false;
        GameManager.resCalorAux = false;
        GameManager.resSeqAux = false;
    }

    public void Confirmar()
    {
        print("GENES CONFIRMADOS");
        GameManager.resTor = GameManager.resTorAux;
        GameManager.resFrio = GameManager.resFrioAux;
        GameManager.resCalor = GameManager.resCalorAux;
        GameManager.resSeq = GameManager.resSeqAux;
    }

    public void Resistencia(int gen)
    {
        int eleccion = listas[gen].value;
        print("ELEGISTE " + eleccion.ToString() + " EN LA LISTA " + (gen+1).ToString() + " FELICIDADES");
        if(eleccion == 1)
        {
            GameManager.resTorAux = true;
        }
        else if(eleccion == 2)
        {
            GameManager.resCalorAux = true;
        }
        else if(eleccion == 3)
        {
            GameManager.resFrioAux = true;
        }
        else if(eleccion == 4)
        {
            GameManager.resSeqAux = true;
        }
    }

    public void ADN()
    {
        print("ADN");
        adn.SetActive(true);
        main.SetActive(false);
    }

    public void INFO()
    {
        print("INFO");
        info.SetActive(true);
        main.SetActive(false);
    }

    public void CerrarVentana()
    {
        print("MAIN");
        adn.SetActive(false);
        info.SetActive(false);
        main.SetActive(true);
    }
}
