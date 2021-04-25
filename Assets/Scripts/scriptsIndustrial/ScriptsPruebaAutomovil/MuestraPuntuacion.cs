using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraPuntuacion : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.puntuacionNivelCarro = Mathf.Abs((GameManager.dano / 7.2f) - 1) + GameManager.itemsRecolectados / 4 + Mathf.Pow(0.99f, GameManager.numeroSegundos) * 3;
        this.GetComponent<Text>().text = GameManager.puntuacionNivelCarro.ToString("f1");
        print(GameManager.numeroSegundos);
    }
}
