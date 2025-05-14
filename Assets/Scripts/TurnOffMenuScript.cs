using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnOffMenuScript : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject pauseMenu;
    public void TurnOffMenu()
    {
        upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void GameOverMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

}