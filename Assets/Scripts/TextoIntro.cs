using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoIntro : MonoBehaviour
{
    private string TextoActivo;
    public Text textoConsola;
    public GameObject Continuar;
    private bool skip;
    public int contadorTexto = 0;
    public int contadorTextos = 0;

    public static TextoIntro instance;

    private void Awake()
    {
        instance = this;
    }

    private string[] Textos = {
            //Textos[0] --- 1
                                "Bitacora de navegacion:\n Yo, ",
            //Textos[1]
            ", acabo de despegar de la Tierra en ruta a nuestro objetivo, " +
            "colonizar Marte. Seran 23879km que recorrer a una velocidad de 87492km/hr, " +
            "sera una larga ruta.",
            //Textos[2] ---- 2
                                "Bitacora de navegacion:\n Colonizar Marte no sera facil. " +
            "Habra varios obstaculos.\n ¿Como obtendre comida?\n ¿Como recorrere el planeta?\n " +
            "¿Quien me ayudara en la base?",
            //Textos[3] ---- 3
                                "Bitacora de navegacion:\n Mi destino esta cerca. " +
            "Sin embargo, hay un campo de asteroides adelante. Tendre que atravesar sus orbitas" +
            " para seguir en ruta. Me comunicare de nuevo al llegar a Marte.",
            //Textos[4] ---- 4
                                "Bitacora de navegacion:\n Yo, ",
            //Textos[5]
            ", soy la primera persona en Marte.\n La base esta lista. " +
            "Ahora tengo varias misiones que hacer para sobrevivir..."};

    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.nivelGlobal == 0)
        {
            TextoActivo = Textos[0] + GameManager.GamerTag + Textos[1];
            contadorTextos = 1;
            contadorTexto = 3;
            Ejecutar();
        }
        if (GameManager.nivelGlobal == 1)
        {
            TextoActivo = Textos[4] + GameManager.GamerTag + Textos[5];
            contadorTextos = 1;
            contadorTexto = 1;
            Ejecutar();
        }
        print(TextoActivo);
        
    }

    void Update()
    {
        if (Input.anyKey)
        {
            skip = true;
        }
    }

    public void Ejecutar()
    {
        textoConsola.text = "";
        Continuar.SetActive(false);
        StartCoroutine(Escribir());
    }

    private IEnumerator Escribir()
    {
        
        foreach (char letra in TextoActivo)
        {
            if (!skip)
            {
                textoConsola.text = textoConsola.text + letra;
                yield return new WaitForSeconds(0.03f);
            }
            else
            {
                textoConsola.text = TextoActivo;
                break;
            }
        }
        if(contadorTexto > 0)
        {
            contadorTextos += 1;
            print("Siguiente " + Textos[contadorTextos]);
            TextoActivo = Textos[contadorTextos];
            contadorTexto -= 1;
        }
        Continuar.SetActive(true);
    }
}
