using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject keyCollectedNotification;

    private readonly int keyAmount = 3;
    private int currentKeys = 0;

    private bool playerCanLeave = false;

    
    public void KeyFound()
    {
        currentKeys++;

        if (currentKeys >= keyAmount)
        {
            playerCanLeave = true;
        }

        StartCoroutine(KeyNotification());
    }
    

    private IEnumerator KeyNotification()
    {
        keyCollectedNotification.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        keyCollectedNotification.SetActive(false);
    }
}
