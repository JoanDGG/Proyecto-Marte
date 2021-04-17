using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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