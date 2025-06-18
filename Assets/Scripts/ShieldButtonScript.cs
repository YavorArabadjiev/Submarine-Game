using UnityEngine;
using UnityEngine.EventSystems;

public class ShieldButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(true);
        PowerUpDescText.instance.powerUpDesc.text = "Increases amount of shields you can carry by one and ads 2 shields to your health bar. (Current shield capacity " + PlayerScript.instance.shieldCapacity + ")";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
