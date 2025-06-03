using UnityEngine;
using TMPro;
public class GameOverMenuScript : MonoBehaviour
{
    public TextMeshProUGUI scoreMenu;
    public TextMeshProUGUI score;
    private void Awake()
    {
        scoreMenu.text = "Score: " + score.text;
    }
}