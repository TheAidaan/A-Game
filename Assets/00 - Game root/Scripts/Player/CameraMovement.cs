using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float _mouseSensitiviy = 150;
    Transform _playerBody;

    float yAxisClamp;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerBody = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
       
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") *_mouseSensitiviy * Time.deltaTime ;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitiviy * Time.deltaTime;

        yAxisClamp += mouseY;

        if (yAxisClamp > 90f)
        {
            yAxisClamp = 90f;
            mouseY = 0f;

            ClampAxisRotationToValue(270f);

        }
        else if (yAxisClamp < -90f)
        {
            yAxisClamp = -90f;
            mouseY = 0f;

            ClampAxisRotationToValue(90);
        }


        transform.Rotate(Vector3.left * mouseY);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

    void ClampAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;

        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
