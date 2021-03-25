using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprRenderer;
    private Animator anim;
    private Image img;
    public GameObject go;
    public GameObject osc;
    public GameObject tor;
    //public GameObject[] evento;
    public float velocidad = 7;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
        osc.GetComponent<Image>().enabled = false;
        //GameObject tor = evento[GameManager.clima];
        StartCoroutine(reloj());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.perder)
        {
            print("Perdiste, tus patatas murieron");
            Application.Quit();
        }
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(movHorizontal * velocidad, movVertical * velocidad);
        float ABSvelocidad = Mathf.Abs((rigidbody.velocity.x + rigidbody.velocity.y));
        anim.SetFloat("velocidad", ABSvelocidad);
        if (rigidbody.velocity.x > 0.1)
        {
            sprRenderer.flipX = false;
        }
        else if (rigidbody.velocity.x < -0.1)
        {
            sprRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Puerta"))
        {
            SceneManager.LoadScene("Laboratorio");
        }
        else if(other.gameObject.CompareTag("Tormenta")){
            print("TORMENTA!!!!!!!!!!!!");
        }
    }

    IEnumerator reloj()
    {
        while(!GameManager.perder)
        {
            print(GameManager.tiempo);
            yield return new WaitForSeconds(1.0f);
            GameManager.tiempo += 1;
            if (GameManager.tiempo >= GameManager.tiempoLimite && !GameManager.evento)
            {
                osc.GetComponent<Image>().enabled = true;
                yield return new WaitForSeconds(0.25f);
                go.transform.position = new Vector3(-1.5f, 1.5f, 0.0f);
                Instantiate(tor);
                yield return new WaitForSeconds(0.25f);
                GameManager.tiempo = 0;
                GameManager.evento = true;
                osc.GetComponent<Image>().enabled=false;
            }
            else if (GameManager.tiempo >= GameManager.tiempoEvento && GameManager.evento)
            {
                osc.GetComponent<Image>().enabled = true;
                yield return new WaitForSeconds(0.25f);
                go.transform.position = new Vector3(6.5f, 0.8f, 0.0f);
                yield return new WaitForSeconds(0.25f);
                GameManager.tiempo = 0;
                GameManager.evento = false;
                osc.GetComponent<Image>().enabled = false;
            }
        }
    }
}
