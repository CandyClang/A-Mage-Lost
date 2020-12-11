using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public float regenTimer = 0f;
    public float maxRegenTime = 15f;

    private bool allowAbsorb;

    Player player;
    ManaManager manaManager;
    SoundManager soundManager;
    SpriteRenderer potionRenderer;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        manaManager = GameObject.Find("ManaSystem").GetComponent<ManaManager>();
        potionRenderer = gameObject.GetComponent<SpriteRenderer>();
        allowAbsorb = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != null)
        {
            if (!allowAbsorb)
            {
                regenTimer += Time.deltaTime;
                if (regenTimer > maxRegenTime)
                {
                    regenTimer = 0f;
                    potionRenderer.enabled = true;
                    allowAbsorb = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (allowAbsorb && manaManager.currManaAmount < 100f)
            {
                Absorb();
                soundManager.playSound(SoundManager.Sound.Mana);
                allowAbsorb = false;
            }
        }
    }

    void Absorb()
    {
        manaManager.currManaAmount += 20f;
        potionRenderer.enabled = false;
    }
}
