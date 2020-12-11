using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveAbilityIcons : MonoBehaviour {
    public Sprite FireIcon;
    public Sprite WaterIcon;
    public Sprite AirIcon;
    public Sprite EarthIcon;
    public Image image;

    private void Start() {
        image.sprite = FireIcon;
    }

    void ChangeIcon (int abilityIndex) {
        switch (abilityIndex) {
            case 0:
                //image.sprite = FireIcon;
                image.overrideSprite = FireIcon;
                break;
            case 1:
                //image.sprite = WaterIcon;
                image.overrideSprite = WaterIcon;
                break;
            case 2:
                //image.sprite = AirIcon;
                image.overrideSprite = AirIcon;
                break;
            case 3:
                //image.sprite = EarthIcon;
                image.overrideSprite = EarthIcon;
                break;
        }
    }
}
