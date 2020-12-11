using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderCharacteristics : MonoBehaviour
{
    public float boulderTimer;
    public float maxBoulderTime = 30f;

    void Start()
    {
        boulderTimer = maxBoulderTime;

        Destroy(gameObject, maxBoulderTime);
    }

    void Update()
    {
        
        boulderTimer -= Time.deltaTime;

        if (boulderTimer < 3f)
        {
            StartCoroutine("BoulderFlash");

        }
    }

    IEnumerator BoulderFlash()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();

        for (int i = 0; i < 3; i++)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
