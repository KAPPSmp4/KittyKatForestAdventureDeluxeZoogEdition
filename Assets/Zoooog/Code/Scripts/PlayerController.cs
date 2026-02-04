using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public CharacterController controller;
    [SerializeField] public Transform cam;
    [SerializeField] public Animator animator;

    [Header("Movement Settings")]
    [SerializeField] public float speed = 6;
    private float gravity = -9.81f;
    private Vector3 velocity;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    private PlayerLocomotionInput _playerLocomotionInput;

    private void Awake()
    {
        _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        Vector3 direction = new Vector3(_playerLocomotionInput.MovementInput.x, 0f, _playerLocomotionInput.MovementInput.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //animations
        if (direction.magnitude == 0f)
        {
            animator.SetFloat("speed", 0.0f);
            AudioManager.Instance.sfxSource.Pause();
        }
        else
        {
            animator.SetFloat("speed", 0.5f);
            AudioManager.Instance.sfxSource.UnPause();
        }
        

    }
}