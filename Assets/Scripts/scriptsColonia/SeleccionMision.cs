using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionMision : MonoBehaviour
{
    public Canvas canvasMisionCohete;
    public Canvas canvasMisionRobot;
    public Canvas canvasMisionTaller;
    public Canvas canvasMisionLab;

    public Canvas canvasBandera;
    public Canvas canvasCreditos;

    void Start()
    {
        canvasMisionCohete.enabled = false;
        canvasMisionRobot.enabled = false;
        canvasMisionTaller.enabled = false;
        canvasMisionLab.enabled = false;
        canvasBandera.enabled = false;
        canvasCreditos.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("SeleccionCohete")){
            print("¿Quieres entrar a esta mision?");
            canvasMisionCohete.enabled = true;
        }

        if (collider.gameObject.CompareTag("SeleccionMaquinas")){
            print("¿Quieres entrar a esta mision?");
            canvasMisionRobot.enabled = true;
        }

        if (collider.gameObject.CompareTag("SeleccionTaller")){
            print("¿Quieres entrar a esta mision?");
            canvasMisionTaller.enabled = true;
        }

        if (collider.gameObject.CompareTag("SeleccionLab")){
            print("¿Quieres entrar a esta mision?");
            canvasMisionLab.enabled = true;
        }

        if (collider.gameObject.CompareTag("AreaBandera")){
            print("Mexicanos al grito de guerra");
            canvasBandera.enabled = true;
        }

        if (collider.gameObject.CompareTag("AreaCreditos")){
            print("Creditos");
            canvasCreditos.enabled = true;
        }
    }

    private void OnTriggerExit2D() 
    {
        canvasMisionCohete.enabled = false;
        canvasMisionRobot.enabled = false;
        canvasMisionTaller.enabled = false;
        canvasMisionLab.enabled = false;
        
        canvasBandera.enabled = false;
        canvasCreditos.enabled = false;
    }
}
