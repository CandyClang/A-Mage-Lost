using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public float currManaAmount;
    public float manaRegen = 10f;
    public GameObject manaBar;

    private float maxMana = 100f;
    private float minMana = 0f;
    private Image totalMana;

    void Start()
    {
        currManaAmount = maxMana;

        totalMana = manaBar.transform.Find("TotalMana").GetComponent<Image>();
    }

    void Update()
    {
        //MANA REGEN
        currManaAmount += manaRegen * Time.deltaTime;
        currManaAmount = Mathf.Clamp(currManaAmount, minMana, maxMana);
        //Debug.Log(currManaAmount);

        //UI MANA BAR
        totalMana.fillAmount = currManaAmount / maxMana;

        //MAGIC USE
        UseMagic();
    }

    //MAGIC USE METHODS
    public void UseMagic()
    {
        GameObject abilitySystem = GameObject.Find("AbilitySystem");

        GameObject fire = abilitySystem.transform.Find("FireAbility").gameObject;
        FireAbility fireAbility = fire.GetComponent<FireAbility>();

        GameObject water = abilitySystem.transform.Find("WaterAbility").gameObject;
        Water waterAbility = water.GetComponent<Water>();

        GameObject air = abilitySystem.transform.Find("AirAbility").gameObject;
        AirAbility airAbility = air.GetComponent<AirAbility>();

        GameObject earth = abilitySystem.transform.Find("EarthAbility").gameObject;
        EarthAbility earthAbility = earth.GetComponent<EarthAbility>();

        if (currManaAmount <= 20f)
        {
            if (fireAbility != null)
                fireAbility.enabled = false;
            if (waterAbility != null)
                waterAbility.enabled = false;
            if (airAbility != null)
                airAbility.enabled = false;
            if (earthAbility != null)
                earthAbility.enabled = false;
        }
        else if (currManaAmount >= 20f)
        {
            if (fireAbility != null)
                fireAbility.enabled = true;
            if (waterAbility != null)
                waterAbility.enabled = true;
            if (airAbility != null)
                airAbility.enabled = true;
            if (earthAbility != null)
                earthAbility.enabled = true;
        }
    }
}
