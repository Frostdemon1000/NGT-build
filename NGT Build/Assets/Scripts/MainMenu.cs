using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject creditsButton;
    [SerializeField]
    private GameObject quitButton;
    [SerializeField]
    private GameObject creditsScreen;
    [SerializeField]
    private GameObject mainScreen;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void ToggleCredits()
    {
        creditsButton.SetActive(!creditsButton.activeInHierarchy);
        creditsScreen.SetActive(!creditsScreen.activeInHierarchy);
        mainScreen.SetActive(!mainScreen.activeInHierarchy);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
