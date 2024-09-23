using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpDescText : MonoBehaviour
{
    public GameObject descObject;
    [HideInInspector] public TextMeshProUGUI powerUpDesc;
    [HideInInspector] public static PowerUpDescText instance;
    // Start is called before the first frame update
    void Start()
    {
        
        powerUpDesc = descObject.GetComponent<TextMeshProUGUI>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
