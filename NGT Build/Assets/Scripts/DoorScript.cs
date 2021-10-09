using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorScript : MonoBehaviour
{
    // Does the door stuff

    private Animator _doorAnim;

    private bool _doorOpen = false;
    private bool _doorUsable = true;
    // Variables n stuff


    private void Awake()
    {
        _doorAnim = GetComponent<Animator>(); // Declares animator
    }

    public void PlayAnimation()
    {
        StartCoroutine(PlayAnim()); // Plays coroutine (PlayAnim) once called
    }

    private IEnumerator PlayAnim() // Does the thing
    {
        if (!_doorOpen && _doorUsable)
        {
            _doorUsable = false;
            _doorAnim.Play("DoorOpen", 0, 0f);
            _doorOpen = true;
            yield return new WaitForSeconds(1.5f);
            _doorUsable = true;
        }
        else if (_doorOpen && _doorUsable)
        {
            _doorUsable = false; 
            _doorAnim.Play("DoorClose", 0, 0f);
            _doorOpen = false;
            yield return new WaitForSeconds(1.5f);
            _doorUsable = true;
        }
    }
}
