using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl controller = other.GetComponent<PlayerControl>();

        if (controller != null)
        {
            controller.EndCheck();
        }
    }
}
