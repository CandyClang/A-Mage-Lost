using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SailBoat : MonoBehaviour {
    public GameObject Sail;
    public GameObject SailAired;

    public Rigidbody player;
    public Rigidbody rigid;

    public float strength = 1000;
    Vector3 vector = new Vector3(1, 0, 0);
    public bool onBoard = false;

    public AbilitySwitch aSwitch;
    public Animator boatAnim;

    private void Update() {
        if (onBoard) {
            print("OnBoard");
            if (player.GetComponent<Player>().isGrounded)
                player.velocity = rigid.velocity;
        }

        if (aSwitch.selectedAbility == 2) { //if air ability is active
            rigid.freezeRotation = true;
        } else rigid.freezeRotation = false;

        if (rigid.velocity.magnitude > .005) boatAnim.SetBool("Moving", true);
        else boatAnim.SetBool("Moving", false);
    }

    void GotAired() {
        rigid.AddForce(vector * strength);
    }

    void OnBoard() {
        onBoard = true;
    }

    void OffBoard() {
        onBoard = false;
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.collider.tag == "Player") {
            OnBoard();
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.tag == "Player") {
            OffBoard();
        }
    }

    bool Or(bool a, bool b) {
        if (a || b) return true;
        else return false;
    }
}