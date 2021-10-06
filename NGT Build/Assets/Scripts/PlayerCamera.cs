using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // pls don't touch unless you know what you're doing


    // Variables n' stuff
    [Tooltip("Camera sensitivity")]
    public float mouseSensitivity = 100f; // Mouse sensitivity (public for future precaution if customizing in settings)

    public bool cameraInverted = false;

    [SerializeField]
    private Transform _playerBody;

    [SerializeField]
    private Transform _mainCam;

    private float _xRotation = 0f;


    void Start()
    {
        if (_playerBody == null || _mainCam == null)
        {
            _playerBody = this.transform;
            _mainCam = transform.GetChild(0);
            Debug.LogWarning("'_playerBody' and '_mainCam' not found, reassinging!"); // If you clicked this in the console ignore, it fixes itself
        }

        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to center of screen
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // Declares mouseX variable via Input Manager axis
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; // Declares mouseY variable via Input Manager axis

        if (!cameraInverted) // Inverts camera controls (mouse up is down & mouse down is up, etc.)
        {
            _xRotation -= mouseY;
        }
        else
        {
            _xRotation += mouseY;
        }

        _xRotation =  Mathf.Clamp(_xRotation, -75f, 75f);

        _mainCam.localRotation = Quaternion.Euler(_xRotation, 0f, 0f); // Rotates cam up & down based off "xRotation" variable
        _playerBody.Rotate(Vector3.up * mouseX); // Rotates entire player body left & right
    }
}
