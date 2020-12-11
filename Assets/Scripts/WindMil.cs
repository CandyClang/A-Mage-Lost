using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMil : MonoBehaviour {
    public Transform player;
    public Animator Ground;
    public LineRenderer selfLR;
    public float distanceLimit = 27;
    string triggername = "Triggered";

    private void Update() {
        if ((player.position - transform.position).magnitude < distanceLimit) {
            selfLR.SetPosition(0, player.transform.position);
            selfLR.SetPosition(1, transform.position);
            selfLR.enabled = true;
        } else {
            selfLR.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "AirTrail") {
            GetComponent<Animator>().SetTrigger(triggername);
            Ground.SetTrigger(triggername);
        }
    }
}