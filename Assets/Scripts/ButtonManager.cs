using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject boton_izq;
    public GameObject boton_der;

    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;

    private int pagina = 1;

    public void Avanzar()
    {
        if(pagina == 1)
        {
            texto1.SetActive(false);
            texto2.SetActive(true);
            boton_izq.SetActive(true);
        }
        else if (pagina == 2)
        {
            texto2.SetActive(false);
            texto3.SetActive(true);
            boton_der.SetActive(false);
        }
        pagina++;
    }

    public void Retroceder()
    {
        if (pagina == 2)
        {
            texto1.SetActive(true);
            texto2.SetActive(false);
            boton_izq.SetActive(false);
        }
        else if (pagina == 3)
        {
            texto2.SetActive(true);
            texto3.SetActive(false);
            boton_der.SetActive(true);
        }
        pagina--;
    }
}
