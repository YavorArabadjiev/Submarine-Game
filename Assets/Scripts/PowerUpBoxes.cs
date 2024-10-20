using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBoxes : MonoBehaviour
{
    public GameObject[] powerUpBoxes;
    [HideInInspector] public static PowerUpBoxes instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
