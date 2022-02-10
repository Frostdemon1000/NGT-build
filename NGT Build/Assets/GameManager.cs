using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void WinGame()
    {
        SceneManager.LoadScene(2);
    }
}
