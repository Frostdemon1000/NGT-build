using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _groundChecker;

    private CharacterController _charControl;

    [SerializeField]
    private float _playerSpeed = 5f;

    private float _gravity = -9.81f;

    [SerializeField]
    private LayerMask _groundMask;
    private Vector3 _velocity;

    private bool _isGrounded;

    void Start()
    {
        _charControl = GetComponent<CharacterController>();
    }


    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, 0.4f, _groundMask);

        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -1f;
        }

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _move = transform.right * _horizontal + transform.forward * _vertical;

        _charControl.Move(_move * _playerSpeed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _charControl.Move(_velocity * Time.deltaTime);
    }
}
