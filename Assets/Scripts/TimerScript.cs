using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerMinutes;
    [SerializeField] TextMeshProUGUI timerSeconds;
    [SerializeField] float currentTime;
    [SerializeField] bool countDown;
    [HideInInspector] public static TimerScript instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= 10)
        {
            
        }
        timerSeconds.text = currentTime.ToString("0");

        
    }

//    IEnumerator minutesCounter()
//    {
//        while (true)
//        {
//           yield return new WaitForSeconds(10f);
//           currentMinutes += 1f;
//           timerMinutes.text += currentMinutes.ToString();
//        }
//    }
}
