using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnOffMenuScript : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject pauseMenu;
    public static TurnOffMenuScript instance;

    private void Awake()
    {
        instance = this;
    }

    public void TurnOffMenu()
    {
        upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
    }

    public void TurnOffButton(GameObject powerupButton, GameObject powerupIcon)
    {
        powerupButton.GetComponent<Button>().interactable = false;
        powerupButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        powerupIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
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