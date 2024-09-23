using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSpeedUpButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(true);
        PowerUpDescText.instance.powerUpDesc.text = "Movement speed of the player increases.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
