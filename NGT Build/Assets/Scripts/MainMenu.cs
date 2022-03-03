using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject creditsButton;
    [SerializeField]
    private GameObject helpButton;
    [SerializeField]
    private GameObject helpScreen;
    [SerializeField]
    private GameObject creditsScreen;
    [SerializeField]
    private GameObject mainScreen;

    [Header("Camera stuff")]

    [SerializeField]
    private Transform plrCamera;

    [SerializeField] [Min(1f)]
    private float speed = 7.5f;

    private void Awake()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;

        if (speed < 1f)
        {
            speed = 7.5f;
        }
    }

    private void Update()
    {
        Vector3 rotation = speed * Time.deltaTime * new Vector3(0f, 1f, 0f);
        plrCamera.Rotate(rotation);
    }

    public void ToggleCredits()
    {
        creditsButton.SetActive(!creditsButton.activeInHierarchy);
        creditsScreen.SetActive(!creditsScreen.activeInHierarchy);
        mainScreen.SetActive(!mainScreen.activeInHierarchy);
        helpButton.SetActive(!helpButton.activeInHierarchy);
    }

    public void ToggleHelp()
    {
        creditsButton.SetActive(!creditsButton.activeInHierarchy);
        mainScreen.SetActive(!mainScreen.activeInHierarchy);
        helpButton.SetActive(!helpButton.activeInHierarchy);
        helpScreen.SetActive(!helpScreen.activeInHierarchy);
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
