using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GemUpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isTaken;
    [SerializeField] Sprite gemSprite;
    int level = 0;
    [SerializeField] TextMeshProUGUI gemButtonText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(true);
        PowerUpDescText.instance.powerUpDesc.text = "The amount of experience that gems give you increases.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PowerUpDescText.instance.descObject.SetActive(false);
    }
    // Start is called before the first frame update
    public void ShowPowerUp()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = gemSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = gemSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }

        else if (PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = gemSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }

        else if (PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = gemSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        level += 1;
        gemButtonText.text = "Gem Upgrade L " + (level + 1);
    }
}
