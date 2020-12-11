using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanLvlPuzzle2 : MonoBehaviour
{
    [SerializeField] public Lantern lantern2;
    [SerializeField] public Lantern lantern3;
    [SerializeField] public Lantern lantern33;
    [SerializeField] public GameObject door;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lantern3.isAlight && !lantern2.isAlight && !lantern33.isAlight)
        { door.SetActive(false); }
    }
}