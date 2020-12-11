using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class MainMenuButtons : MonoBehaviour
{
    public AudioClip buttonpress;
    AudioSource audioSource;
    public GameObject selectStagePanel;
    public GameObject tutorialPanel;
    public GameObject stagePanel;
    public GameObject mainPanel;

    private void Start()
    {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        Cursor.visible = true;
    }

    public void LevelSelect(string scene) {
        audioSource.PlayOneShot(buttonpress);
        mainPanel.SetActive(false);
        selectStagePanel.SetActive(true);
    }

    public void MainMenu(string scene) {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("MainMenu");
    }

    public void newGame(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("FireLevel");
    }

    public void returntoMain(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        selectStagePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void returntoSelectStagefromTut(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        selectStagePanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    public void returntoSelectStagefromStage(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        selectStagePanel.SetActive(true);
        stagePanel.SetActive(false) ;
    }

    public void tutorialLevel(string scene) 
    {
        audioSource.PlayOneShot(buttonpress);
        selectStagePanel.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void stageLevel(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        selectStagePanel.SetActive(false);
        stagePanel.SetActive(true);

    }

    public void Level1(string scene) {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Level1");
        Analytics.CustomEvent("EntLvl1");
    }
    public void Level2(string scene) {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Level2");
        Analytics.CustomEvent("EntLvl2");
    }
    public void Level3(string scene) {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Level3");
        Analytics.CustomEvent("EntLvl3");
    }
    public void Level4(string scene) {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Level4");
        Analytics.CustomEvent("EntLvl4");
    }

    public void Level5(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Level5");
    }

    public void Level6(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Level6");
    }

    public void Level7(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Level7");
    }

    public void fireLevel(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("FireLevel");
    }

    public void waterLevel(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("WaterLevel");
    }

    public void earthLevel(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("EarthLevel");
    }

    public void airLevel(string scene)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("AirLevel");
    }


    public void SettingsButton(string Settings)
    {
        audioSource.PlayOneShot(buttonpress);
        SceneManager.LoadScene("Settings");
    }

    public void QuitButton() {
        audioSource.PlayOneShot(buttonpress);
        Application.Quit();
    }
}
