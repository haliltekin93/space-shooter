using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject finishPanel;
    bool IsPaused = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPausedStatus();
        }
    }

    private void IsPausedStatus()
    {
        IsPaused = !IsPaused;

        if(IsPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame()
    {
        if(!IsPaused)
        {
            IsPausedStatus();
        }
    }

    public void ContinueGame()
    {
        if(IsPaused)
        {
            IsPausedStatus();
        }
    }

    public void gameOverPanelOpen()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AgainGame()
    {
        SoundManager.instance.MouseClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void finishPanelOpen()
    {
        finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReturnMainMenu()
    {
        SoundManager.instance.MouseClickSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
