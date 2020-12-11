using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEdgeVaneChild : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (transform.name == "Blue") {
            print("collide Blue");
            transform.parent.gameObject.GetComponent<WindMilDoubleEnd>().SendMessage("VaneTriggered", -1);
        } else if (transform.name == "Red") {
            print("collide Red");
            transform.parent.gameObject.GetComponent<WindMilDoubleEnd>().SendMessage("VaneTriggered", 1);
        }
    }
}