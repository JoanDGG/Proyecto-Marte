using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resena : MonoBehaviour, IDropHandler
{
    public GameObject Enviar;
    public int valor;
    public bool continuar = false;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            valor = eventData.pointerDrag.GetComponent<Arrastrar>().resena;
            print(valor);
            GameManager.resena = valor;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Enviar.SetActive(true);
        }
    }

    public void Continuar()
    {
        continuar = true;
    }
}
