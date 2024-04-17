using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private float speed = 2f;
    private float rotationSpeed = 2f;
    private float verticalRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limitar la rotación vertical para evitar voltear la cámara
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0f);

    }
}
