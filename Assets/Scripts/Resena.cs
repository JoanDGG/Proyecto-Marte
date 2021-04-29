using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Resena : MonoBehaviour, IDropHandler
{
    public GameObject Enviar;
    public Text Nivel;
    public int valor;
    public bool continuar = false;
    private string[] niveles = {"Despegue", "El robot", "Busca y recolecta", "Crece la cosecha"};

    void Start()
    {
        Nivel.text = niveles[GameManager.nivelGlobal - 1];
    }

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
