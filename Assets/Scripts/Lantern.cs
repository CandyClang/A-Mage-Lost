using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public GameObject offState;
    public GameObject onState;
    public bool movingRight;
    public float speed;
    public bool isAlight = false;
    public bool needsMove = false;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        onState.SetActive(false);
    }

    public void Ignite()
    {
        onState.SetActive(true);
        offState.SetActive(false);
        isAlight = true;
        timer = Time.time;
        Debug.Log(timer);
    }

    void Update()
    {
        if (needsMove) 
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

        if (isAlight) 
        {
            if (Input.GetKeyDown(KeyCode.L)) 
            {
                onState.SetActive(false);
                offState.SetActive(true);
                isAlight = false;
            }
        }

        if ((Time.time - timer) > 5f)
        {
            onState.SetActive(false);
            offState.SetActive(true);
            isAlight = false;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("turn")) 
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
    }

}
