using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoBulletButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(true);
        PowerUpDescText.instance.powerUpDesc.text = "A weapon that shoots automatically, one spike on each four sides of the player.";
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
