using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject keyCollectedNotification;
    [SerializeField]
    private GameObject exitDoor;
    [SerializeField]
    private Color threeKeysColor;

    private readonly int keyAmount = 3;
    private int currentKeys = 0;

    private readonly string[] phrases =
    {
        "GET OUT OF THERE",
        "THERE IS NO ESCAPE",
        "RUN",
        "IT'S COMING"
    };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void KeyFound()
    {
        currentKeys++;

        if (currentKeys >= keyAmount)
        {
            ThreeKeysSequence();
        }

        StartCoroutine(KeyNotification());
    }
    
    private void ThreeKeysSequence()
    {
        EnemyScript enemyScript = FindObjectOfType<EnemyScript>();

        enemyScript.ChangeEnemySpeed(4.5f);
        RenderSettings.ambientLight = threeKeysColor;
        exitDoor.SetActive(true);
    }

    private IEnumerator KeyNotification()
    {
        if (currentKeys >= keyAmount)
        {
            keyCollectedNotification.GetComponent<TextMeshProUGUI>().text = phrases[Mathf.RoundToInt(Random.Range(0f, 3f))];
            keyCollectedNotification.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            keyCollectedNotification.SetActive(false);
        }
        else
        {
            keyCollectedNotification.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            keyCollectedNotification.SetActive(false);
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene(2);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }
}
