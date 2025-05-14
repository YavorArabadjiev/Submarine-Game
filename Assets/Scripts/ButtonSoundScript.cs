using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundScript : MonoBehaviour
{
   [HideInInspector] public static ButtonSoundScript instance;
   [HideInInspector] public AudioSource pickUpPowerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        pickUpPowerUpSound = GetComponent<AudioSource>();
    }

   
}
