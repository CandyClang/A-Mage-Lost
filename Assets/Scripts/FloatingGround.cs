using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingGround : MonoBehaviour
{
    public bool movingRight;
    public bool isHorizontal;
    public bool movingUp;   
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHorizontal)
        {
            if (movingRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            }
        }
        else 
        {
            if (movingUp)
            {
                transform.Translate(0, 2 * Time.deltaTime * speed, 0);
            }
            else
            {
                transform.Translate(0, -2 * Time.deltaTime * speed, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("turn"))
        {
            if (isHorizontal)
            {
                if (movingRight)
                {
                    movingRight = false;
                }
                else
                {
                    movingRight = true;
                }
            }

            else 
            {
                if (movingUp)
                {
                    movingUp = false;
                }

                else 
                {
                    movingUp = true;
                }
            }
            
        }

        
    }
}
