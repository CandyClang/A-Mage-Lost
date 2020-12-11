using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySwitch : MonoBehaviour {
    public int selectedAbility = 0;
    public ActiveAbilityIcons icons;
    public GameObject arrow;

    GameObject[] waterSources;

    //Ability currAbility;

    Color[] AbilityColors = {
        new Color(1f,       .357f,      0f),
        new Color(0f,       1f,         .824f),
        new Color(0f,       .682f,      .937f),
        new Color(.824f,    .235f,      .4f)
    };

    // Start is called before the first frame update
    void Start() {
        SelectAbility();

        waterSources = GameObject.FindGameObjectsWithTag("WaterSource");
    }

    // Update is called once per frame
    void Update() {
        int prevSelectedAbility = selectedAbility;

        //SCROLLWHEEL SELECT
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && !Pause.isPaused) {
            if (selectedAbility >= transform.childCount - 2)
                selectedAbility = 0;
            else
                selectedAbility++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && !Pause.isPaused) {
            if (selectedAbility <= 0)
                selectedAbility = transform.childCount - 2;
            else
                selectedAbility--;
        }

        //BUTTON SELECT
        if (Input.GetKeyDown(KeyCode.Alpha1) && !Pause.isPaused) //FIRE
        {
            selectedAbility = 0;
            //currAbility = Ability.Fire;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && !Pause.isPaused) //WATER
        {
            selectedAbility = 1;
            //currAbility = Ability.Water;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && !Pause.isPaused) //AIR
        {
            selectedAbility = 2;
            //currAbility = Ability.Air;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4 && !Pause.isPaused) //EARTH
        {
            selectedAbility = 3;
            //currAbility = Ability.Earth;
        }

        if (prevSelectedAbility != selectedAbility) {
            SelectAbility();
        }

        if (selectedAbility != 1) {
            foreach (GameObject waterSource in waterSources)
                if (waterSource.GetComponent<ParticleSystem>() != null)
                    waterSource.GetComponent<ParticleSystem>().Play();
        }
        arrow.SetActive(true);
    }

    void SelectAbility() {
        int i = 0;
        int match = 0;
        foreach (Transform ability in transform) {
            if (i == selectedAbility) {
                match = i;
                ability.gameObject.SetActive(true);
            } else
                ability.gameObject.SetActive(false);
            i++;
            setParticles(GameObject.Find("AbilityParticles").transform, match);
            setParticles(arrow.transform, match);
        }
        setArrowActive(arrow, match);
        icons.SendMessage("ChangeIcon", selectedAbility);
    }

    void setParticles(Transform target, int ability) {
        foreach (Transform child in target) 
            child.gameObject.SetActive(false);
        target.GetChild(ability).gameObject.SetActive(true);
    }

    void setArrowActive(GameObject target, int ability) {
        target.SetActive(true);
        target.GetComponent<SpriteRenderer>().color = AbilityColors[ability];
    }
}