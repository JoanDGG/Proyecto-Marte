using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; //Para red

public class GetJSON : MonoBehaviour
{
    public static GetJSON instance;
    public List<string> elementos = new List<string>();
    public bool ejecucion = true;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void LeerJSON(String ruta)
    {
        ejecucion = true;
        elementos.Clear();
        StartCoroutine(DescargarJSON(ruta));
    }

    // Inicio es síncrono, pero termina antes del codigo asíncrono
    private IEnumerator DescargarJSON(String ruta)
    {
        print("http://localhost:8080/" + ruta);
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/" + ruta);
        yield return request.SendWebRequest(); //Ejecuta, regresa, espera...
        //Ya regresó... continuar...
        if (request.result == UnityWebRequest.Result.Success)
        {   //Procesar resultados
            string textoPlano = request.downloadHandler.text;
            //resultado.text = textoPlano;
            textoPlano = textoPlano.Trim(new Char[] { '[', ']' });
            print(textoPlano);
            List<String> preguntas = new List<String>(textoPlano.Split(','));
            foreach (var pregunta in preguntas)
            {
                Dictionary<String, String> datos =
                JsonConvert.DeserializeObject<Dictionary<String, String>>(pregunta);

                foreach (var dato in datos)
                {
                    print(dato.Value);
                    elementos.Add(dato.Value);
                }
            }
        }
        else
        {
            print("Error en la descarga " + request.responseCode.ToString());
        }
        ejecucion = false;
    }
}
