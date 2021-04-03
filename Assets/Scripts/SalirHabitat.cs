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
    public GameObject[] paginas = new GameObject[2];

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
        for(int i = 0; i<3; i++)
        {
            listas[i].value = 0;
        }
    }

    public void Confirmar()
    {
        print("GENES CONFIRMADOS");
        GameManager.resTor = GameManager.resTorAux;
        GameManager.resFrio = GameManager.resFrioAux;
        GameManager.resCalor = GameManager.resCalorAux;
        GameManager.resSeq = GameManager.resSeqAux;
        for(int i = 0; i < 3; i++)
        {
            GameManager.genes[i] = listas[i].value;
        }
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
        for (int i = 0; i < 3; i++)
        {
            listas[i].value = GameManager.genes[i];
        }
    }

    public void INFO()
    {
        print("INFO");
        info.SetActive(true);
        GameManager.pagina = 0;
        main.SetActive(false);
    }

    public void CerrarVentana()
    {
        print("MAIN");
        adn.SetActive(false);
        info.SetActive(false);
        main.SetActive(true);
    }

    public void Siguiente()
    {
        paginas[GameManager.pagina].SetActive(false);
        GameManager.pagina = (GameManager.pagina == paginas.Length - 1) ? 0 : GameManager.pagina + 1;
        paginas[GameManager.pagina].SetActive(true);
    }

    public void Anterior()
    {
        paginas[GameManager.pagina].SetActive(false);
        GameManager.pagina = (GameManager.pagina == 0) ? paginas.Length - 1 : GameManager.pagina - 1;
        paginas[GameManager.pagina].SetActive(true);
    }
}
