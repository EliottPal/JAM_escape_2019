using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteriesCollector : MonoBehaviour
{
    public AudioSource Collect;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl controller = other.GetComponent<PlayerControl>();

        if (controller != null)
        {
            controller.RechargeJump();
            Collect.Play();
            gameObject.SetActive(false);
        }
    }
}
