using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject PauseMenu;
    int sceneIndex;
    GameController gameController;
    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        gameController = FindObjectOfType<GameController>();

        GameOverMenu.SetActive(false);
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (FindObjectOfType<BirdFlap>() == null)
        {
            GameOverMenu.SetActive(true);
            PauseButton.SetActive(false);
            gameController.GameOver();
        }
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPauseButton()
    {
        Time.timeScale = 0.0f;
        PauseMenu.SetActive(true);
    }

    public void OnPlayButton()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

}
