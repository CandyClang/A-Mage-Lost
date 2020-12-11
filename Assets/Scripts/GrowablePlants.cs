using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowablePlants : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;

            child.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void Grow()
    {
        Animator anim = gameObject.GetComponentInChildren<Animator>();

        anim.SetTrigger("Grow");

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        foreach (Transform child in gameObject.transform)
        {

            child.GetComponent<BoxCollider>().enabled = true;
            child.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
