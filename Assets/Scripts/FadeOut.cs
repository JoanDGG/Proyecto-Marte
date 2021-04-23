using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image imagenFondo;
    public float tiempo = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        imagenFondo.canvasRenderer.SetAlpha(1f);
        imagenFondo.CrossFadeAlpha(0, tiempo, false);
        StartCoroutine(EsperarFadeOut());
    }

    public IEnumerator EsperarFadeOut()
    {
        yield return new WaitForSeconds(tiempo);
        imagenFondo.gameObject.SetActive(false);
    }
}
