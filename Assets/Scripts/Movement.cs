using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, mouseX);

        float newRotationX = transform.eulerAngles.x - mouseY;
        if (newRotationX > 180f)
        {
            newRotationX -= 360f;
        }
        newRotationX = Mathf.Clamp(newRotationX, -80f, 80f);
        transform.eulerAngles = new Vector3(newRotationX, transform.eulerAngles.y, 0f);
    }
}