using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApareceTexto : MonoBehaviour
{

    private GameObject Texto;
    private Image Image;

    void Start()
    {
        Texto = transform.GetChild(0).gameObject;
        Image = GetComponent<Image>();
    }

    public void Entra()
    {
        Texto.SetActive(true);
        Image.color = new Color32(255, 255, 255, 50);
    }

    public void Sale()
    {
        Texto.SetActive(false);
        Image.color = new Color32(255, 255, 255, 0);
    }
}