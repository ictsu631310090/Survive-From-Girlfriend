using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walking_code : MonoBehaviour
{
    public Animator MainAnimator;
    public float walkingSpeed = 7.5f;
    bool isRunning = false;
    public float runningSpeed = 15f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public Slider StaminaSlider;
    public static int Maxstamina = 1000;
    public int useStamina = 3;
    public int forceStamina = 1;
    public float DebutDogTime = 5.0f;
    bool hitDog = false;
    public GameObject DebutIcon;
    public GameObject runningIcon;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "boss")
        {
            Time.timeScale = 0;
        }
        if (collider.gameObject.tag == "Dog")
        {
            hitDog = true;
        }
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StaminaSlider.maxValue = Maxstamina;
        StaminaSlider.value = Maxstamina;
        DebutIcon.SetActive(false);
        runningIcon.SetActive(false);
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        if (Input.GetKey(KeyCode.LeftShift) && StaminaSlider.value > 10)
        {
            isRunning = true;
            StaminaSlider.value -= useStamina;
        }
        else
        {
            isRunning = false;
        }
        if (StaminaSlider.value == 0 || StaminaSlider.value < 50)
        {
            isRunning = false;
        }
        if (isRunning == true)
        {
            runningIcon.SetActive(true);
            runningSpeed = 15f;
        }
        else if (isRunning == false)
        {
            runningIcon.SetActive(false);
            runningSpeed = 7.5f;
        }
        if (StaminaSlider.value + 5 < StaminaSlider.maxValue && Time.timeScale == 1)
        {
            StaminaSlider.value += forceStamina;
        }
        if (hitDog == true)
        {
            if (DebutDogTime >= 0)
            {
                DebutDogTime -= Time.deltaTime;
                DebutIcon.SetActive(true);
                useStamina = 10;
            }
        }
        if (DebutDogTime == 0 || DebutDogTime <= 0)
        {
            useStamina = 3;
            DebutDogTime = 5.0f;
            hitDog = false;
            DebutIcon.SetActive(false);
        }
        else if (hitDog == false)
        {
            useStamina = 3;
        }

        if (Input.GetKey(KeyCode.E) && StaminaSlider.value < StaminaSlider.maxValue/2)
        {
            if (itemmanager.haveWater == true)
            {
                if (itemmanager.haveWater2 == true)
                {
                    StaminaSlider.value = Maxstamina;
                    itemmanager.haveWater2 = false;
                }
                else
                {
                    StaminaSlider.value = Maxstamina;
                    itemmanager.haveWater = false;
                }
            }
        }

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            MainAnimator.SetBool("jumpUp", true);
            MainAnimator.SetBool("jumpDown", false);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove && Time.timeScale == 1)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (isRunning == true)
        {
            MainAnimator.SetBool("running", true);
        }
        else if (isRunning == false)
        {
            MainAnimator.SetBool("running", false);
        }

        float dirx;
        float diry;
        dirx = Input.GetAxis("Horizontal");
        diry = Input.GetAxis("Vertical");
        MainAnimator.SetFloat("WalkH", Mathf.Abs(dirx) + Mathf.Abs(diry));

        if (characterController.isGrounded)
        {
            MainAnimator.SetBool("isGrounded", true);
        }
        else if (characterController.isGrounded == false)
        {
            MainAnimator.SetBool("isGrounded", false);
        }
        if (Input.GetButton("Jump"))
        {
            MainAnimator.SetBool("Jumpping", true);
        }
        if (Input.GetButton("Jump") == false)
        {
            MainAnimator.SetBool("Jumpping", false);
        }
    }
}