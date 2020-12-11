using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbility : MonoBehaviour
{
    private CameraManager cam;
    private GameObject player;

    public GameObject firePrefab;

    public float fireSpeed = 60f;

    SoundManager soundManager;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        cam = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        player = GameObject.Find("Player");
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        anim = GameObject.Find("character").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject mana = GameObject.Find("ManaSystem");
        ManaManager manaManager = mana.GetComponent<ManaManager>();


        Vector3 difference = cam.target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float distance = difference.magnitude;
        Vector2 direction = (difference / distance).normalized;


        if (Input.GetMouseButtonDown(0) && !Pause.isPaused) //if any issue remove pause thing
        {
            anim.SetTrigger("Cast");
            StartCoroutine(ReleaseAnimator());

            fireBall(direction, rotationZ);

            manaManager.currManaAmount -= 20f;

            soundManager.playSound(SoundManager.Sound.Fire);
        }
    }

    void fireBall(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(firePrefab) as GameObject;
        b.transform.position = GameObject.Find("FirePoint").transform.position;
        b.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        b.GetComponent<Rigidbody>().velocity = direction * fireSpeed;
    }

    IEnumerator ReleaseAnimator() {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Release");
    }
}
