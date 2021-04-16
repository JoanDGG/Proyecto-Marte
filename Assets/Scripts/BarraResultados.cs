using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraResultados : MonoBehaviour
{
    public Image mask;
    private float TamañoOriginal;

    public static BarraResultados instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        TamañoOriginal = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, TamañoOriginal * value);
    }
}
