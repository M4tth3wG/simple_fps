using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = -9.8f;
    public float rotationSpeed;

    private CharacterController characterController;
    private AudioSource audioSource;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        speed = GameController.instance.configuration.playerSpeed;
        rotationSpeed = GameController.instance.configuration.playerRotationSpeed;
    }

    void Update()
    {
        if (!GameController.instance.IsPaused)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;

            transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);

            characterController.Move(movement);
        }
    }

    public void OnDamage()
    {
        audioSource.Play();
    }
}
