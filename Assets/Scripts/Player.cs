using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpPower;
    public bool isGrounded;
    public bool discharge;
    public float jumpCharge;
    public GameObject jumpChargeBar;
    public Text jumpText;

    private float moveX;
    private Image jumpProgressBar;
    private bool canJump;

    AbilitySwitch abilityManager;
    ManaManager manaManager;
    AirAbility airAbility;
    Animator anim;

    bool boulderGrounded;

    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        anim = GameObject.Find("character").GetComponent<Animator>();
        abilityManager = GameObject.Find("AbilitySystem").GetComponent<AbilitySwitch>();
        airAbility = abilityManager.transform.Find("AirAbility").GetComponent<AirAbility>();
        manaManager = GameObject.Find("ManaSystem").GetComponent<ManaManager>();
        jumpProgressBar = jumpChargeBar.transform.Find("Progress").GetComponent<Image>();
        jumpChargeBar.SetActive(false);
        jumpText.enabled = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (boulderGrounded)
        //{
        //    if(isGrounded)
        //    gameObject.GetComponent<Rigidbody>().velocity = new Vector3(
        //        gameObject.GetComponent<Rigidbody>().velocity.x,
        //        0,
        //        gameObject.GetComponent<Rigidbody>().velocity.z);
        //}

        PlayerMove();

        anim.SetFloat("Speed", Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.x));

        if (abilityManager.selectedAbility == 2 && manaManager.currManaAmount > 0f)
        {
            if (canJump)
                ChargeJump();
            else
            {
                if (Input.GetMouseButtonDown(1))
                    canJump = true;
            }

            if (discharge && isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * (jumpPower + jumpCharge));
                isGrounded = false;
                anim.SetTrigger("Jump");

                discharge = false;
                jumpCharge = 0f;
            }
        }
        else
        {
            jumpPower = 1100f;
            gameObject.GetComponent<Rigidbody>().drag = 0;
            gameObject.GetComponent<Rigidbody>().mass = 3;

            if (gameObject.GetComponent<Rigidbody>().velocity.y < 0)
                gameObject.GetComponent<Rigidbody>().velocity += Vector3.up * Physics2D.gravity.y * 1.5f * Time.deltaTime;
        }
    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                soundManager.playSound(SoundManager.Sound.Jump);
                gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * jumpPower);
                isGrounded = false;
                anim.SetTrigger("Jump");
            }
        }

        //TEMP UNTIL PROPER MODEL IS IMPLEMENTED
        //Orientation
        if (moveX < 0.0f)
        {
            // transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            GameObject.Find("character").GetComponent<Transform>().localScale = new Vector3(-.4f, .4f, .4f);
        }
        else if (moveX > 0.0f)
        {
            //transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            GameObject.Find("character").gameObject.GetComponent<Transform>().localScale = new Vector3(.4f, .4f, .4f);
        }

        //Move
        gameObject.GetComponent<Rigidbody>().velocity = new Vector2(moveX * playerSpeed,
            gameObject.GetComponent<Rigidbody>().velocity.y);

    }

    void ChargeJump()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        AbilitySwitch abilitySwitch = GameObject.Find("AbilitySystem").GetComponent<AbilitySwitch>();

        if (isGrounded)
        {
            if (Input.GetMouseButtonDown(1))
                canJump = true;

            if (Input.GetMouseButton(1))
            {
                abilitySwitch.enabled = false;
                airAbility.enabled = false;
                rb.velocity = Vector3.zero;

                if (jumpCharge < 1200f)
                {
                    jumpText.enabled = true;
                    jumpChargeBar.SetActive(true);
                    jumpCharge += Time.deltaTime * 800f;
                    jumpProgressBar.fillAmount = jumpCharge / 1200f;
                }
            }

            if (Input.GetMouseButtonDown(0) && canJump)
            {
                canJump = !canJump;
                jumpCharge = 0f;
                jumpText.enabled = false;
                jumpChargeBar.SetActive(false);
                abilitySwitch.enabled = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                airAbility.enabled = true;
                discharge = true;
                jumpText.enabled = false;
                jumpChargeBar.SetActive(false);
                abilitySwitch.enabled = true;

                manaManager.currManaAmount -= 20f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" ||
            collision.gameObject.name == "Boulder" ||
            collision.gameObject.name == "SquareBoulder(Clone)")
        {
            isGrounded = true;
        }
        if (
            collision.gameObject.name == "Boulder" ||
            collision.gameObject.name == "SquareBoulder(Clone)")
        {
            boulderGrounded = true;
        }

        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            gameObject.transform.SetParent(collision.transform);
            GameObject cam = GameObject.Find("Main Camera");
            cam.transform.SetParent(gameObject.transform);
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            GameObject cam = GameObject.Find("Main Camera");
            cam.transform.SetParent(gameObject.transform);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.SetParent(null);
            GameObject cam = GameObject.Find("Main Camera");
            cam.transform.SetParent(null);
        }

        if (
            collision.gameObject.name == "Boulder" ||
            collision.gameObject.name == "SquareBoulder(Clone)")
        {
            boulderGrounded = false;
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            GameObject cam = GameObject.Find("Main Camera");
            cam.transform.SetParent(null);
        }
    }
}


