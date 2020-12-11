using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMilDoubleEnd : MonoBehaviour {
    public Transform player;
    public Animator[] grounds;
    bool triggered = false;
    Vector3 vect = new Vector3(7, 7, 0);

    private void Update() {
        if (triggered) {
            transform.position = player.position + vect;
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        triggered = true;
    }

    void VaneTriggered(int val) {
        foreach (Animator animator in grounds) {
            print(animator.name);
            animator.SetFloat("Value", setToRightNumber(animator.GetFloat("Value"), val));
        }
    }

    float setToRightNumber(float original, int scale) {
        switch (original) {
            case 1:
                if (scale < 0) return 0;
                return -1;
                break;
            case 0:
                if (scale < 0) return -1;
                return 1;
                break;
            case -1:
                if (scale < 0) return 1;
                return 0;
                break;
            default:
                return 0;
        }
    }
}