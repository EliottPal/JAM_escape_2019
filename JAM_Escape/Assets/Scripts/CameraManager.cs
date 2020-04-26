using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float forwardSpeed;
    public PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.haveHDD == true)
        {
            transform.Translate(0f, forwardSpeed * Time.deltaTime, 0f, null);
            if (transform.position.y >= 20)
               forwardSpeed = 0;
        }
    }
}
