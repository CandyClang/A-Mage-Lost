using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFog : MonoBehaviour {
    public ParticleSystem particle;

    private void Start() {
       if (particle==null) {
            particle = GetComponent<ParticleSystem>();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag=="Bullet") {
            particle.emissionRate = 0;
            gameObject.SetActive(false);
        }
    }
}