using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeMenuButtons : MonoBehaviour
{
    AudioSource buttonSound;

    private void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        buttonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
