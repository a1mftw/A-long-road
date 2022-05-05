using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioClip hoverClip;
    public AudioClip pressClip;

    //Quit
    public void Playgame (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    //Pause Menu
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true; 
    }

    public void HoverSound()
    {
        GameObject.Find("SFX Source").GetComponent<AudioSource>().PlayOneShot(hoverClip);
    }

    public void ClickSound()
    {
        GameObject.Find("SFX Source").GetComponent<AudioSource>().PlayOneShot(pressClip);
    }

}
