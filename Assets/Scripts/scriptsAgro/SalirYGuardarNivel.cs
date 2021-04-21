using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirYGuardarNivel : MonoBehaviour
{
    public void SalirMenu()
    {
        PlayerPrefs.SetInt("primero", GameManager.primero);
        PlayerPrefs.SetInt("tiempo", GameManager.tiempo);
        PlayerPrefs.SetInt("tiempoLimite", GameManager.tiempoLimite);
        PlayerPrefs.SetInt("evento", GameManager.evento);
        PlayerPrefs.SetInt("tiempoEvento", GameManager.tiempoEvento);
        PlayerPrefs.SetInt("reloj", GameManager.reloj);
        PlayerPrefs.SetInt("resist0", GameManager.resist[0]);
        PlayerPrefs.SetInt("resist1", GameManager.resist[1]);
        PlayerPrefs.SetInt("resist2", GameManager.resist[2]);
        PlayerPrefs.SetInt("resist3", GameManager.resist[3]);
        PlayerPrefs.SetInt("perder", GameManager.perder);
        PlayerPrefs.SetInt("pagina", GameManager.pagina);
        PlayerPrefs.SetInt("clima0", GameManager.clima[0]);
        PlayerPrefs.SetInt("clima1", GameManager.clima[1]);
        PlayerPrefs.SetInt("clima2", GameManager.clima[2]);
        PlayerPrefs.SetInt("genes0", GameManager.genes[0]);
        PlayerPrefs.SetInt("genes1", GameManager.genes[1]);
        PlayerPrefs.SetInt("genes2", GameManager.genes[2]);
        PlayerPrefs.SetInt("oleada", GameManager.oleada);
        PlayerPrefs.SetInt("respondido", GameManager.oleada);
        PlayerPrefs.SetInt("respuestas0", GameManager.respuestas[0]);
        PlayerPrefs.SetInt("respuestas1", GameManager.respuestas[1]);
        PlayerPrefs.SetInt("respuestas2", GameManager.respuestas[2]);
        PlayerPrefs.SetInt("puntuacion", GameManager.puntuacion);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MenuMisiones");
    }
}
