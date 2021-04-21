using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaApuntar : MonoBehaviour
{
    public Transform[] puertillas = new Transform[7];
    public Transform player;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 posicionA = MasCercano(puertillas);
        Vector3 posicionDe = Camera.main.transform.position;
        posicionDe.z = 0;
        Vector3 dir = posicionA - posicionDe;
        float angle = Vector3.Angle(dir, transform.forward);
        gameObject.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, angle);
    }

    Vector3 MasCercano(Transform[] puertas)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = player.position;
        foreach (Transform t in puertas)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin.position;
    }
}
