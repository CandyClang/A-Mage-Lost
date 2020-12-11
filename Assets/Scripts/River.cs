using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class River : MonoBehaviour {
    public Image blackout;
    public Collider player;

    private void Start() {
        if (player != null) Physics.IgnoreCollision(GetComponent<Collider>(), player);
        if (blackout != null) blackout.canvasRenderer.SetAlpha(0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(StartBlackOut());
        }
    }

    IEnumerator StartBlackOut() {
        //linear fadein
        blackout.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        GameObject.Find("GameManager").SendMessage("Restart");
    }
}
