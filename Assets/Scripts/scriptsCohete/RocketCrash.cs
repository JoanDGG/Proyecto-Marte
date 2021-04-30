using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Este script detecta si el cohete choco con algun enemigo
* Autor: Daniel Garcia Barajas
*/
public class RocketCrash : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy")){
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (collision.gameObject.CompareTag("BlackHole")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
