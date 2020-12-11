using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanLvlPuzzle1: MonoBehaviour
{

    SoundManager soundManager;

    [SerializeField] public Lantern lantern1;
    [SerializeField] public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        openDoor();
    }

    void openDoor()
    {
        if (lantern1.isAlight)
        {
            
            door.SetActive(false);
            
        }
    }
}