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

    private readonly float _gravity = -9.81f;

    [SerializeField]
    private LayerMask _groundMask;
    private Vector3 _velocity;

    private Vector3 _playerLastPos;

    [SerializeField]
    private AudioClip[] _footSteps;

    private AudioSource _plrAudioSrc;

    private bool _isGrounded;
    private bool _footStepsPlaying = false;
    // Variables n' stuff

    private void Start()
    {
        _charControl = GetComponent<CharacterController>(); // Declares component for variable
        _plrAudioSrc = GetComponent<AudioSource>();
    }


    private void Update()
    {
        Sprint();
        PlayerMove();
    }

    private void PlayerMove()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, 0.2f, _groundMask); // Bool for if physics sphere is touching ground

        if (_isGrounded && _velocity.y < 0f) // Sets velocity to -1 if player grounded and velocity is less than 0
        {
            _velocity.y = -1f;
        }

        FootSteps(); // Calls footstep function

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _move = transform.right * _horizontal + transform.forward * _vertical;

        _charControl.Move(_move * _playerSpeed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _charControl.Move(_velocity * Time.deltaTime);
    }

    private void Sprint() 
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            _playerSpeed = 7f;
        }
        else 
        {
            _playerSpeed = 5f;
        }
    }

    private void FootSteps()
    {
        if (_playerLastPos != gameObject.transform.position && _isGrounded)
        {
            int _randomClipNum = Mathf.RoundToInt(Random.Range(0f, 3f));

            AudioClip clip = _footSteps[_randomClipNum];
            if (!_footStepsPlaying)
            {
                _footStepsPlaying = true;
                StartCoroutine(PlayFootStep(clip));
            }
        }

        _playerLastPos = gameObject.transform.position;
    }

    private IEnumerator PlayFootStep(AudioClip clip)
    {
        float _randomPitch = Random.Range(0.9f, 1.1f);

        _plrAudioSrc.clip = clip;
        _plrAudioSrc.pitch = _randomPitch;
        _plrAudioSrc.Play();

        yield return new WaitForSeconds(0.4f);

        _footStepsPlaying = false;
    }
}
