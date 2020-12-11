using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour {
    public GameObject winText;
    public GameObject Particle;

    SoundManager soundManager;

    void Start() {
        winText.SetActive(false);
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            winText.SetActive(true);
            Particle.SetActive(true);
            collision.gameObject.GetComponent<Player>().enabled = false;
            StartCoroutine("WinPause");
            soundManager.playSound(SoundManager.Sound.Victory);
            GameObject.Find("GameManager").SendMessage("VictoryReportCustomAnalytics");
        }
    }

    IEnumerator WinPause() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}