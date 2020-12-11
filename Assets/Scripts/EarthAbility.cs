using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthAbility : MonoBehaviour
{
    public Transform earthPoint;
    public GameObject earthBullet;
    public float maxSize = 5f;
    public float maxMass = 20f;
    public float growSizeSpeed = 1f;
    public float growMassSpeed = 2f;
    public Text boulderText;
    public bool canSpawn;
    public bool canCancel;

    private GameObject currentEarth;

    Animator anim;
    Player playerScript;
    GameObject player;
    GameObject abilitySystem;
    Rigidbody rb;
    ManaManager manaManager;
    SoundManager soundManager;

    private void Awake()
    {
        boulderText.enabled = false;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        anim = GameObject.Find("character").GetComponent<Animator>();
        abilitySystem = GameObject.Find("AbilitySystem");
        manaManager = GameObject.Find("ManaSystem").GetComponent<ManaManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        canSpawn = true;
        canCancel = false;

        if (currentEarth != null)
            rb = currentEarth.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.isPaused) { //if any issue delete this line
            if (canSpawn && playerScript.isGrounded)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    canCancel = true;
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    anim.SetTrigger("Cast");
                    Generate();
                    boulderText.enabled = true;
                }

                if (Input.GetMouseButton(0))
                {
                    GrowBoulder();
                }

                if (Input.GetMouseButtonDown(1) && canCancel)
                {
                    CancelGenerate();
                    canCancel = false;
                    boulderText.enabled = false;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    if (canCancel)
                    {
                        ReleaseBoulder();
                        rb.constraints = RigidbodyConstraints.FreezePositionZ;
                        canCancel = false;
                        boulderText.enabled = false;
                    }
                    else
                    {
                        anim.SetTrigger("Release");
                        abilitySystem.GetComponent<AimAngle>().enabled = true;
                        abilitySystem.GetComponent<AbilitySwitch>().enabled = true;
                        player.GetComponent<Player>().enabled = true;
                    }
                }
            }
            else
            {
                anim.SetTrigger("Release");
                abilitySystem.GetComponent<AimAngle>().enabled = true;
                abilitySystem.GetComponent<AbilitySwitch>().enabled = true;
                player.GetComponent<Player>().enabled = true;
                boulderText.enabled = false;
            }
        } //if any issue delete this line
    }

    void Generate()
    {
        currentEarth = Instantiate(earthBullet, earthPoint.position, earthPoint.rotation);
        rb = currentEarth.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void GrowBoulder()
    {
        abilitySystem.GetComponent<AimAngle>().enabled = false;
        abilitySystem.GetComponent<AbilitySwitch>().enabled = false;
        player.GetComponent<Player>().enabled = false;

        if (currentEarth != null)
        {
            if (currentEarth.transform.localScale.x < maxSize && currentEarth.transform.localScale.y < maxSize && currentEarth.transform.localScale.z < maxSize)
                currentEarth.transform.localScale += earthBullet.transform.localScale * (Time.deltaTime * growSizeSpeed);
            if (rb.mass < maxMass)
                rb.mass += earthBullet.GetComponent<Rigidbody>().mass * (Time.deltaTime * growMassSpeed);
        }
    }

    void CancelGenerate()
    {
        Destroy(currentEarth);

        anim.SetTrigger("Release");
        abilitySystem.GetComponent<AimAngle>().enabled = true;
        abilitySystem.GetComponent<AbilitySwitch>().enabled = true;
        player.GetComponent<Player>().enabled = true;
    }

    void ReleaseBoulder()
    {
        anim.SetTrigger("Release");
        abilitySystem.GetComponent<AimAngle>().enabled = true;
        abilitySystem.GetComponent<AbilitySwitch>().enabled = true;
        player.GetComponent<Player>().enabled = true;
        currentEarth.tag = "Boulder";

        manaManager.currManaAmount -= 20f;

        soundManager.playSound(SoundManager.Sound.Rock);
    }
}

