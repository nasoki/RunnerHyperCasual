using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 direction;
    private int desiredLane = 1;
    public float laneDistance = 4; //distance between two lanes
    public float forwardSpeed;
    public float jumpForce;
    public float gravity = -20;
    public CharacterController characterController;
    Animator animator;
    private bool isSliding = false;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        TrailRenderer trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.UpArrow) &&!isJumping || characterController.isGrounded && SwipeManager.swipeUp)
        {
            isJumping = true;
            Jump();
            animator.SetBool("isJumping", true);
        }

        else
        {
            animator.SetBool("isJumping", false);
            direction.y += gravity * Time.deltaTime;
            isJumping = false;
        }

        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.DownArrow) && !isSliding || (characterController.isGrounded && SwipeManager.swipeDown && !isSliding))
        {
            StartCoroutine(Slide());
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 100);

        characterController.center = characterController.center;
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        characterController.center = new Vector3(0, 0.45f, 0.09f);
        characterController.height = 0.82f;
        yield return new WaitForSeconds(1.43f);

        characterController.center = new Vector3(0, 0.69f, 0.09f);
        characterController.height = 1.39f;
        animator.SetBool("isSliding", false);
        isSliding = false;
    }

    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<TrailRenderer>().endColor = other.GetComponent<MeshRenderer>().material.color;
    }
}