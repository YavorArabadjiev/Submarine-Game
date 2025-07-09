using UnityEngine;
using TMPro;
public class GameOverMenuScript : MonoBehaviour
{
    public TextMeshProUGUI scoreMenu;
    public TextMeshProUGUI score;
   [SerializeField] GameObject music;
    private void Awake()
    {
        scoreMenu.text = "Score: " + score.text;
        music.GetComponent<AudioSource>().enabled = false;
        gameObject.GetComponent<AudioSource>().Play();
    }
}