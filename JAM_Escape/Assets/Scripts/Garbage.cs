using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameObject player;
    GameObject copy;
    // Start is called before the first frame update

    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-3.95f, 3.95f), 15.9f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
    }   

    void CheckPosition()
    {
        Vector3 pos = transform.position;

        if (pos.y < -4.39)
            Restart();
    }

    public void Stop()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl controller = other.GetComponent<PlayerControl>();

        if (controller != null)
        {
            controller.GarbageCheck();
            gameObject.SetActive(false);
            controller.LaserCheck();
        }
    }

    public void Restart()
    {
        transform.position = new Vector3(Random.Range(-3.95f, 3.95f), 15.9f, 0f);
        rigidbody2d.velocity = new Vector2(0, 0);
    }
}
