using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanLvlPuzzle3 : MonoBehaviour
{
    [SerializeField] public Lantern lantern4;
    [SerializeField] public Lantern lantern5;
    [SerializeField] public Lantern lantern6;
    [SerializeField] public Lantern lantern7;
    [SerializeField] public Lantern lantern8;
    [SerializeField] public Lantern lantern9;
    [SerializeField] public Lantern lantern10;
    [SerializeField] public Lantern lantern11;
    [SerializeField] public GameObject door;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lantern4.isAlight && !lantern5.isAlight && !lantern6.isAlight && !lantern7.isAlight && lantern8.isAlight && lantern9.isAlight && !lantern10.isAlight && lantern11.isAlight)
        { door.SetActive(false); }
    }
}