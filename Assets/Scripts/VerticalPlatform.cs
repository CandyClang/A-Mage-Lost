using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public bool isMoving;
    public bool movingUp;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (movingUp)
                transform.Translate(0, speed * Time.deltaTime, 0);
            else
                transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "turn")
        {
            if (movingUp)
                movingUp = false;
            else
                movingUp = true;
        }
    }
}
