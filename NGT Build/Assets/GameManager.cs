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
    private GameObject pauseMenu;
    [SerializeField]
    private Color threeKeysColor;

    private readonly int keyAmount = 3;
    private int currentKeys = 0;

    private bool gamePaused = false;
    private bool playerCanWin = false;

    private readonly string[] phrases =
    {
        "GET OUT OF THERE",
        "THERE IS NO ESCAPE",
        "RUN",
        "IT'S COMING"
    };

    private void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerCamera playerCamera = FindObjectOfType<PlayerCamera>();

            if (!gamePaused)
            {
                gamePaused = true;
                Time.timeScale = 0f;

                Cursor.lockState = CursorLockMode.None;
                playerCamera.canRotate = false;

                pauseMenu.SetActive(true);
            }
            else
            {
                gamePaused = false;
                Time.timeScale = 1f;

                Cursor.lockState = CursorLockMode.Locked;
                playerCamera.canRotate = true;

                pauseMenu.SetActive(false);
            }
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

        enemyScript.ChangeEnemySpeed(6.5f);
        RenderSettings.ambientLight = threeKeysColor;
        playerCanWin = true;
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
        if (playerCanWin)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
