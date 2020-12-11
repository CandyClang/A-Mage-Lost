using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualDistance : MonoBehaviour {
    public Camera camera;
    Vector3 distanceAndDirection = new Vector3();
    // Start is called before the first frame update
    void Start() {
        Vector3 temp = camera.transform.position;
        temp.y = -6.2f;
        transform.position = temp;
        distanceAndDirection = transform.position - camera.transform.position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = camera.transform.position + distanceAndDirection;
    }
}