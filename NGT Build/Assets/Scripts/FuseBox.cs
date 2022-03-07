using System.Collections;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    [SerializeField]
    private Animator leverAnimator;
    [SerializeField]
    private Transform lightsParent;

    private bool powerOn;
    private bool canUse = true;

    private void Awake()
    {
        powerOn = false;

        foreach (Transform child in lightsParent)
        {
            child.GetComponent<Light>().enabled = false;
        }
    }

    public void TogglePower()
    {
        if (!canUse) { return; }

        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        if (!powerOn)
        {
            canUse = false;
            leverAnimator.Play("LeverUp");

            yield return new WaitForSeconds(1.5f);

            foreach (Transform child in lightsParent)
            {
                child.GetComponent<Light>().enabled = true;
            }

            powerOn = true;
            canUse = true;
        }
        else if (powerOn)
        {
            canUse = false;
            leverAnimator.Play("LeverDown");

            yield return new WaitForSeconds(1.5f);

            foreach (Transform child in lightsParent)
            {
                child.GetComponent<Light>().enabled = false;
            }

            powerOn = false;
            canUse = true;
        }
    }
}
