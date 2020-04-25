using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl controller = other.GetComponent<PlayerControl>();

        if (controller != null)
        {
            controller.GarbageCheck();
            gameObject.SetActive(false);
        }
    }
}
