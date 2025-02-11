using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeMovimento : MonoBehaviour
{

    public float speed = 5f;
    public float mouseSensitivity = 2f;
    private CharacterController controller;
    private float verticalRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState =CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //movimentação
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * movX + transform.forward * movZ;
        controller.Move(move * speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
