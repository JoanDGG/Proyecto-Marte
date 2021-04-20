using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supervivencia : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tormenta") && !GameManager.resist[0])
        {
            print("Tormenta");
            anim.SetBool("Vida", false);
            GameManager.perder = true;
            Time.timeScale = 0;
        }
        else if(other.gameObject.CompareTag("Sequia") && !GameManager.resist[3])
        {
            anim.SetBool("Vida", false);
            GameManager.perder = true;
            Time.timeScale = 0;
        }
        else if(other.gameObject.CompareTag("Frio") && !GameManager.resist[2]){
            anim.SetBool("Vida", false);
            GameManager.perder = true;
            Time.timeScale = 0;
        }
        else if(other.gameObject.CompareTag("Calor") && !GameManager.resist[1])
        {
            anim.SetBool("Vida", false);
            GameManager.perder = true;
            Time.timeScale = 0;
        }
    }
}
