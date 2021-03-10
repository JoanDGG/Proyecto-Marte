using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public float xMargin = 1.0f;
    public float yMargin = 1.0f;

    public float xSmooth = 10.0f;
    public float ySmooth = 10.0f;

    public Vector2 maxYandX;
    public Vector2 minYandX;

    public GameObject target;

    private Transform CameraTarget;

    void Awake()
    {
        CameraTarget = target.transform;
    }

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - CameraTarget.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - CameraTarget.position.y) > yMargin;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if(CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, CameraTarget.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, CameraTarget.position.y, ySmooth * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minYandX.x, maxYandX.x);
        targetY = Mathf.Clamp(targetY, minYandX.y, maxYandX.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
