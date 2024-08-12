using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public static ScoreScript instance;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainPoints(int pointsGained)
    {
        score += pointsGained;
        scoreText.text = score.ToString();
    }
}
