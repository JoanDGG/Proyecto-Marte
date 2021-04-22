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

    void Start()
    {
        for (int i = 0; i < GameManager.oleada; i++)
        {
            listas[i].gameObject.SetActive(true);
        }
    }

    public void Salir()
    {
        SceneManager.LoadScene("NivelBio");
    }

    public void Cancelar()
    {
        print("GENES CANCELADOS");
        for(int i = 0; i<3; i++)
        {
            listas[i].value = 0;
        }
    }

    public void Confirmar(AudioSource audio)
    {
        print("GENES CONFIRMADOS");
        audio.Play();
        for (int i = 0; i < GameManager.resist.Length; i++)
        {
            GameManager.resist[i] = false;
        }
        for(int i = 0; i < 3; i++)
        {
            GameManager.genes[i] = listas[i].value;
            switch (listas[i].value)
            {
                case 1:
                    switch (i)
                    {
                        case 0: //+1
                            GameManager.resist[0] = true; //Resistencia Tormenta
                            break;
                        case 1: //+1-1
                            GameManager.resist[0] = true; //Resistencia Tormenta
                            GameManager.resist[3] = false; //Debilidad Sequia
                            break;
                        case 2: //+2-1
                            GameManager.resist[0] = true; //Resistencia Tormenta
                            GameManager.resist[2] = true; //Resistencia Frio
                            GameManager.resist[3] = false; //Debilidad Sequia
                            break;
                    }
                    break;
                case 2:
                    switch (i)
                    {
                        case 0: //+1
                            GameManager.resist[1] = true; //Resistencia Calor
                            break;
                        case 1: //+1-1
                            GameManager.resist[1] = true; //Resistencia Calor
                            GameManager.resist[2] = false; //Debilidad Frio
                            break;
                        case 2: //+2-1
                            GameManager.resist[1] = true; //Resistencia Calor
                            GameManager.resist[3] = true; //Resistencia Sequia
                            GameManager.resist[0] = false; //Debilidad Tormenta
                            break;
                    }
                    break;
                case 3:
                    switch (i)
                    {
                        case 0: //+1
                            GameManager.resist[2] = true; //Resistencia Frio
                            break;
                        case 1: //+1-1
                            GameManager.resist[2] = true; //Resistencia Frio
                            GameManager.resist[0] = false; //Debilidad Tormenta
                            break;
                        case 2: //+2-1
                            GameManager.resist[2] = true; //Resistencia Frio
                            GameManager.resist[3] = true; //Resistencia Sequia
                            GameManager.resist[1] = false; //Debilidad Calor
                            break;
                    }
                    break;
                case 4:
                    switch (i)
                    {
                        case 0: //+1
                            GameManager.resist[3] = true; //Resistencia Sequia
                            break;
                        case 1: //+1-1
                            GameManager.resist[3] = true; //Resistencia Sequia
                            GameManager.resist[1] = false; //Debilidad Calor
                            break;
                        case 2: //+2-1
                            GameManager.resist[3] = true; //Resistencia Sequia
                            GameManager.resist[0] = true; //Resistencia Tormenta
                            GameManager.resist[2] = false; //Debilidad Frio
                            break;
                    }
                    break;
            }
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
