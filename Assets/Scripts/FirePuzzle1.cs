using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePuzzle1 : MonoBehaviour
{
    [SerializeField] public Lantern lantern1;
    [SerializeField] public Lantern lantern2;
    [SerializeField] public Lantern lantern3;
    [SerializeField] public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lantern1.isAlight && lantern2.isAlight && lantern3.isAlight)
        { door.SetActive(false); }
    }
}
