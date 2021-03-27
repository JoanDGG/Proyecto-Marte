using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAsteroid : MonoBehaviour
{
    public float gravity = 1f; //Fuerza de gravedad

    Rigidbody2D[] arrayRigid; //Lista de rigidbodys dentro de la orbita

    // Start is called before the first frame update
    void Start()
    {
        arrayRigid = new Rigidbody2D[1]; // Solo sera uno, en este caso el cohete
    }

    // Update is called once per frame
    void Update()
    {
		MakeForce();
    }

    void MakeForce() {
	foreach (Rigidbody2D rigid in arrayRigid) {
		    if(rigid != null) { //Si el objeto está en orbita

		    	Vector3 gravityForce = gameObject.transform.position - rigid.transform.position; //La dirección desde el objeto al asteroide 
				
		    	gravityForce.Normalize();
	    		rigid.AddForce(((Vector2)gravityForce * 9.81f) * gravity); //Se le aplica fuerza 
			}
		}
	}

	void OnTriggerEnter2D(Collider2D orbit) { //Cuando entra en orbita añade fuerza y atrae el objeto
		Rigidbody2D changeRigid = orbit.transform.gameObject.GetComponent<Rigidbody2D> ();

	    if (changeRigid == true) {

	    	bool aplicar = false;
	    	int count = 0;

	    	foreach (Rigidbody2D i in arrayRigid) {

		    	if (!aplicar && i == null) {
		    		arrayRigid [count] = changeRigid;
		    		aplicar = true;
		    	}
		    	count += 1;
    		}
    	}

    }

	void OnTriggerExit2D(Collider2D orbit) { // Cuando sale de orbita quita la fuerza y ya no atrae
		Rigidbody2D changeRigid = orbit.transform.gameObject.GetComponent<Rigidbody2D> ();

    	if (changeRigid == true) {

    		bool quitar = false;
    		int count = 0;

    		foreach (Rigidbody2D i in arrayRigid) {

	    		if (!quitar && i == arrayRigid [count]) {
	    			arrayRigid [count] = null;
		    		quitar = true;
		    	}
	    		count += 1;
	    	}
	    }

    }
}
