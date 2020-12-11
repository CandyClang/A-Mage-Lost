using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        rb.mass = 100f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "AirTrail")
            Destroy(this.gameObject);
    }

}
