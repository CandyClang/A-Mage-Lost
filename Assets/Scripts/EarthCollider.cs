using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCollider : MonoBehaviour
{
    public GameObject earthAbility;

    // void OnTriggerEnter(Collider other)
    // {
    //    if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Flammable" || other.gameObject.tag == "Boulder")
    //     {
    //        //Debug.Log(other.gameObject.tag);
    //        EarthAbility earthScript = earthAbility.GetComponent<EarthAbility>();
    //        earthScript.canSpawn = false;
    //    }
    // }

    void OnTriggerStay(Collider other)
    {
        EarthAbility earthScript = earthAbility.GetComponent<EarthAbility>();

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Flammable" || other.gameObject.tag == "Boulder")
        {
            //Debug.Log(other.gameObject.tag);
            earthScript.canSpawn = false;
        }
        else
            earthScript.canSpawn = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Flammable" || other.gameObject.tag == "Boulder")
        {
            //Debug.Log(other.gameObject.tag);
            EarthAbility earthScript = earthAbility.GetComponent<EarthAbility>();
            earthScript.canSpawn = true;
        }
    }
}

