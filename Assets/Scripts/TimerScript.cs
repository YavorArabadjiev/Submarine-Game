using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerMinutes;
    [SerializeField] TextMeshProUGUI timerSeconds;
    [SerializeField] float currentTime;
    [SerializeField] bool countDown;
    [HideInInspector] public static TimerScript instance;
    [SerializeField] GameObject gameOverMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
         currentTime += Time.deltaTime;
        timerSeconds.text = currentTime.ToString("0");
    }


}
    