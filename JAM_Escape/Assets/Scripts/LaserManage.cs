using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManage : MonoBehaviour
{
    public float forwardSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardSpeed *= (float)1.0001;
        transform.Translate(0f, forwardSpeed * Time.deltaTime, 0f, null);
        if (transform.position.y >= 15)
            forwardSpeed = 0;
    }
}
