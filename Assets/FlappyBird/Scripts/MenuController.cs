using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject PauseMenu;
    int sceneIndex;
    GameController gameController;

    [Header("Sounds")]
    [SerializeField] AudioMixerGroup Mixer;
    [SerializeField] Toggle masterToggle;
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle soundToggle;

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

    public void ToggleMasterSound()
    {
        if (masterToggle.isOn)
            Mixer.audioMixer.SetFloat("MasterVolume", 0);
        else
            Mixer.audioMixer.SetFloat("MasterVolume", -80);
    }

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
        else
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
    }
    public void ToggleSounds()
    {
        if (soundToggle.isOn)
            Mixer.audioMixer.SetFloat("SoundsVolume", 0);
        else
            Mixer.audioMixer.SetFloat("SoundsVolume", -80);
    }

}
