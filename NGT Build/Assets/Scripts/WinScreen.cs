using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI winText;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(TextColor());
    }

    private IEnumerator TextColor()
    {
        while (true)
        {
            Color newColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
            winText.color = newColor;
            yield return new WaitForSeconds(0.8f);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
