using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPhysics : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rbBoulder = this.gameObject.GetComponent<Rigidbody>();
            rbBoulder.isKinematic = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rbBoulder = this.gameObject.GetComponent<Rigidbody>();
            rbBoulder.isKinematic = false;
        }
    }
}
