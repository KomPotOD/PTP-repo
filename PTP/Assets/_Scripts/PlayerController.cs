using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float speed;

    private CharacterController controller;
    private Transform cam;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.gameObject.GetComponent<Transform>();
    }

    private void Update()   // ABSTRACTION
    {
        Look();
        Move();
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        cam.Rotate(Vector3.left * mouseY);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float scaledSpeed = speed * Time.deltaTime;

        controller.Move(transform.right * horizontalInput * scaledSpeed);
        controller.Move(transform.forward * verticalInput * scaledSpeed);
    }
}
