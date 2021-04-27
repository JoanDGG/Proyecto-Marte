using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Checkpoint-1")){
            print("Has llegado al checkpoint del nivel 1-1");
            SceneManager.LoadScene("MisionCohete-2");
        }

        if (collider.gameObject.CompareTag("Checkpoint-2")){
            print("Has llegado al checkpoint del nivel 1-2");
            SceneManager.LoadScene("MisionCohete-3");
        }

        if (collider.gameObject.CompareTag("Checkpoint-3")){
            print("Has llegado al checkpoint del nivel 1-3");
            SceneManager.LoadScene("ColoniaMarte");
        }
    }
}
