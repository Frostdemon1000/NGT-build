using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorScript : MonoBehaviour
{
    // Does the door stuff

    private Animator _doorAnim;

    public bool doorOpen = false;
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
        if (!doorOpen && _doorUsable)
        {
            _doorUsable = false;
            _doorAnim.Play("DoorOpen", 0, 0f);
            doorOpen = true;
            yield return new WaitForSeconds(1.5f);
            _doorUsable = true;
        }
        else if (doorOpen && _doorUsable)
        {
            _doorUsable = false; 
            _doorAnim.Play("DoorClose", 0, 0f);
            doorOpen = false;
            yield return new WaitForSeconds(1.5f);
            _doorUsable = true;
        }
    }
}
