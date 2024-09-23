using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BiggerBulletsButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(true);
        PowerUpDescText.instance.powerUpDesc.text = "Bullets become bigger in size with each upgrade.";
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