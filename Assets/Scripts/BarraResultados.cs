using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
Descripcion:
Este script maneja el llenado de la barra de resultados de un nivel. Crea una instancia del script para
que pueda ser accesible por otros objetos dentro de la escena e incluye la funcion SetValue() que 
recibe un valor flotante entre el 0 y 1 para hacer que la barra se llene dependiende del valor
que se le asigne. Para utilizar dicha funcion, se debe llamar por medio de la siguiente instruccion:

    BarraResultados.instance.SetValue(valorActual / valorMax);

Autor: Joan Daniel Guerrero Garcia
*/

public class BarraResultados : MonoBehaviour
{
    public Image mask;
    public static BarraResultados instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetValue(float value)
    {
        /* 
         * Cambia el valor de la longitud de la mascara que cubre la barra, 
         * eso hace que se oculte parte de esta. Modifica el ancho de la mascara 
         * conforme a su valor multiplicado por el valor dado.
        */
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mask.rectTransform.rect.width * value);
    }
}
