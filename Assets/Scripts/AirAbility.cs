using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAbility : MonoBehaviour
{
    public Transform airPoint;
    public GameObject airBullet;

    Animator anim;

    SoundManager soundManager;

    private void Start()
    {
        anim = GameObject.Find("character").GetComponent<Animator>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject mana = GameObject.Find("ManaSystem");
        ManaManager manaManager = mana.GetComponent<ManaManager>();

        if (Input.GetMouseButtonDown(0) && !Pause.isPaused) //if any issue remove pause thing
        {
            anim.SetTrigger("Cast");
            StartCoroutine(ReleaseAnimator());

            Shoot();

            manaManager.currManaAmount -= 20f;

            soundManager.playSound(SoundManager.Sound.Wind);
        }
    }

    void Shoot()
    {
        Instantiate(airBullet, airPoint.position, airPoint.rotation);
    }

    IEnumerator ReleaseAnimator() {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Release");
    }
}
