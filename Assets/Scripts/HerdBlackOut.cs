using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HerdBlackOut : MonoBehaviour {
    public Image blackout;
    public Collider player;
    public Animator[] herds;

    private void Start() {
        Physics.IgnoreCollision(GetComponent<Collider>(), player);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag=="Bullet") {
            StopAllHerd();
            StartCoroutine(WaitSecsAndDo(1));
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(StartBlackOut());
        }
    }

    IEnumerator WaitSecsAndDo(int x) {
        yield return new WaitForSeconds(x);
        gameObject.SetActive(false);
    }

    IEnumerator StartBlackOut() {
        //linear fadein
        blackout.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        GameObject.Find("GameManager").SendMessage("Restart");
    }

    void StopAllHerd() {
        foreach(Animator animator in herds) {
            animator.SetTrigger("Stop");
        }
    }
}
