using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject keyCollectedNotification;
    [SerializeField]
    private GameObject exitDoor;

    private readonly int keyAmount = 3;
    private int currentKeys = 0;

    
    public void KeyFound()
    {
        currentKeys++;

        if (currentKeys >= keyAmount)
        {
            exitDoor.SetActive(true);
        }

        StartCoroutine(KeyNotification());
    }
    

    private IEnumerator KeyNotification()
    {
        keyCollectedNotification.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        keyCollectedNotification.SetActive(false);
    }

    public void EndGame()
    {
        Debug.Log("Game over");
    }
}
