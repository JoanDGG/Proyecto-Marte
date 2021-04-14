using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rocket : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Rigidbody2D baseStation; //Lo que lo mantiene atado
    private bool isPressed = false;

    public float launchTime = .15f; //El tiempo mínimo para reconocer que se ha lanzado el cohete

    public GameObject nextRocket;

    void Update()
    {

        if (isPressed){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, baseStation.position) > 2f){
                rigidbody.position = baseStation.position + (mousePos - baseStation.position).normalized * 2f;

            }
            else {
                rigidbody.position = mousePos;

            }
                

        }

    }
    void OnMouseDown()  //Cuando presionan y arrastran el cohete
    {
        isPressed = true;
        rigidbody.isKinematic = true;
        
    }

    void OnMouseUp() //Cuando sueltan el mouse
    {
        isPressed = false;
        rigidbody.isKinematic = false;

        StartCoroutine(Launch());

    }

    IEnumerator Launch() //Cuando se lanza el cohete
    {
        yield return new WaitForSeconds(launchTime);

        GetComponent<SpringJoint2D>().enabled = false;

        rigidbody.freezeRotation = false;

        yield return new WaitForSeconds(2f);

        if (nextRocket != null) {
            nextRocket.SetActive(true); 
            RocketLifes.instance.vidas--;
            HUDMisionCohete.instance.UpdateLifes();
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
