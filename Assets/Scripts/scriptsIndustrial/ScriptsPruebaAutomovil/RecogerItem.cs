using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Script que administra el recogimiento de los items.
Autor: Luis Ignacio Ferro Salinas A01378248
Última actualización: 22 de abril de 2021.
*/

public class RecogerItem : MonoBehaviour
{
    // El sonido de recoger un item
    public AudioSource sonidoRecoger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(GameManager.itemsRecolectados);   
    }


    // El choque del automovil con el item.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Automovil"))
        {
            sonidoRecoger.Play();
            GameManager.itemsRecolectados = GameManager.itemsRecolectados + 1;
            Destroy(this.gameObject, t: 0f);
        }
    }
}
