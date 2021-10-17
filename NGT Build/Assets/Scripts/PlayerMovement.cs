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

    private Vector3 _playerLastPos;

    [SerializeField]
    private AudioClip[] _footSteps;

    private AudioSource _plrAudioSrc;

    private bool _isGrounded;
    private bool _footStepsPlaying = false;


    void Start()
    {
        _charControl = GetComponent<CharacterController>();
        _plrAudioSrc = GetComponent<AudioSource>();
        print(_footSteps.Length);
    }


    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, 0.4f, _groundMask);

        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -1f;
        }

        FootSteps();

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _move = transform.right * _horizontal + transform.forward * _vertical;

        _charControl.Move(_move * _playerSpeed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;

        _charControl.Move(_velocity * Time.deltaTime);
    }

    private void FootSteps()
    {
        if (_playerLastPos != gameObject.transform.position && _isGrounded)
        {
            int _randomClipNum = Mathf.RoundToInt(Random.Range(0f, 3f));
            print(_randomClipNum);
            print("player moving");

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
