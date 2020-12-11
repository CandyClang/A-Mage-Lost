using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSizeTo3DCollider : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Vector3 vector2ToVector3 = GetComponent<SpriteRenderer>().size;
        //print(vector2ToVector3);
        vector2ToVector3.z = 1;
        GetComponent<BoxCollider>().size = vector2ToVector3;
        if (transform.childCount > 0) {
            Transform child = transform.GetChild(0);
            child.position = transform.position + new Vector3(0, vector2ToVector3.y / 2, 0);
            child.localScale = new Vector3(vector2ToVector3.x, 0.2f, 1);
        }
    }
}