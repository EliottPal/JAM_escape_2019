﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCamera : MonoBehaviour
{
    public float forwardSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, forwardSpeed * Time.deltaTime, 0f, null);
        if (transform.position.y <= 36.4)
            forwardSpeed = 0;
    }
}

