using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] public GameObject thingToMove;
    bool isClear = false;
    VerticalPlatform vertPlat;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Boulder")
        {
            if(thingToMove != null)
            {
                if (!isClear)
                {
                    if (thingToMove.CompareTag("MovingPlatform"))
                    {
                        vertPlat = GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<VerticalPlatform>();
                        vertPlat.isMoving = true;
                        isClear = true;
                    }
                    else
                    {
                        isClear = true;
                        thingToMove.SetActive(false);
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Boulder")
        {
            if (isClear)
            {
                if (thingToMove.CompareTag("MovingPlatform"))
                {
                    vertPlat = GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<VerticalPlatform>();
                    vertPlat.isMoving = false;
                    isClear = false;
                }
                else
                {
                    isClear = false;
                    thingToMove.SetActive(true);
                }
            }
        }
    }
}
