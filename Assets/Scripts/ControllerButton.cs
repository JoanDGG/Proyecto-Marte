using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerButton : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftArrow()
    {
        Debug.Log("Moving Left");
        player.moveleft = true;
        player.moveright = false;
    }

    public void RightArrow()
    {
        Debug.Log("Moving Right");
        player.moveright = true;
        player.moveleft = false;
    }

    public void ReleaseArrow()
    {
        player.moveright = false;
        player.moveleft = false;
    }
}