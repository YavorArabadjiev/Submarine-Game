using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMenuScript : MonoBehaviour
{
    [SerializeField] GameObject upgradeMenu;
    public void TurnOffMenu()
    {
        upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
    }
}
