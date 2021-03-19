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
        if (other.gameObject.CompareTag("Tormenta") && !GameManager.resTor)
        {
            anim.SetBool("Vida", false);
            GameManager.perder = true;
        }
        else if(other.gameObject.CompareTag("Sequia") && !GameManager.resSeq){
            anim.SetBool("Vida", false);
            GameManager.perder = true;
        }
        else if(other.gameObject.CompareTag("Frio") && !GameManager.resFrio){
            anim.SetBool("Vida", false);
            GameManager.perder = true;
        }
        else if(other.gameObject.CompareTag("Calor") && !GameManager.resCalor){
            anim.SetBool("Vida", false);
            GameManager.perder = true;
        }
    }
}
