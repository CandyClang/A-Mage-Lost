using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    DoorScript door;
    SoundManager soundManager;


    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void OnTriggerEnter(Collider other) //LINKED TO DOOR SCRIPTs
    {
        if (other.gameObject.tag == "Player")
        {
            door = GameObject.Find("castledoors").GetComponent<DoorScript>();
            door.isUnlocked = true;
            gameObject.SetActive(false);
            soundManager.playSound(SoundManager.Sound.Key);
        }
    }
}
