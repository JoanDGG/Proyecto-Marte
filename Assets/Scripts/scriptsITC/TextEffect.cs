using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public Image img;
    public float fadeOutTime = 60.0f;
    private bool fadeOut = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        if (fadeOut)
        {
            while (img.color.a > 0.0f)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - (Time.deltaTime / fadeOutTime));
                yield return null;
            }
            fadeOut = false;
        }
        else
        {
            while (img.color.a < 1.0f)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a + (Time.deltaTime / fadeOutTime));
                yield return null;
            }
            fadeOut = true;
        }
    }
}
