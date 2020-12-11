using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour {
    SoundManager soundManager;
    public int numberLevel;

    // Start is called before the first frame update
    private void Awake() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    private void Start() {
        soundManager.playSound(SoundManager.Sound.BGM);
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void VictoryReportCustomAnalytics() {
        Analytics.CustomEvent("CmpLvl" + numberLevel);
    }
}