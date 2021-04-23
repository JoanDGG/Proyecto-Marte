using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionMision : MonoBehaviour
{
    public Canvas canvasMisionCohete;
    public Canvas canvasMisionRobot;

    void Start()
    {
        canvasMisionCohete.enabled = false;
        canvasMisionRobot.enabled = false;
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
    }

    private void OnTriggerExit2D() 
    {
        canvasMisionCohete.enabled = false;
        canvasMisionRobot.enabled = false;
    }
}
