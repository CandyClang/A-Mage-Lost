using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailCollider : MonoBehaviour {
    public SailBoat sendMessageTarget;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "AirTrail") {
            sendMessageTarget.SendMessage("GotAired");
        }
    }
}