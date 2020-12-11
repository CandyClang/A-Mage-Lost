using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePuzzle2 : MonoBehaviour
{
    [SerializeField] public Lantern lanternA;
    [SerializeField] public Lantern lanternB;
    [SerializeField] public Lantern lanternC;
    [SerializeField] public Lantern lanternD;
    [SerializeField] public Lantern lanternE;
    [SerializeField] public Lantern lanternF;
    [SerializeField] public Lantern lanternG;
    [SerializeField] public Lantern lanternH;
    [SerializeField] public GameObject door;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame ACDG
    void Update()
    {
        if (lanternA.isAlight && lanternC.isAlight && lanternD.isAlight && lanternG.isAlight) 
        {
            Debug.Log("won");
            door.SetActive(false);
        }
    }
}
