using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PoisonAreaScript : MonoBehaviour
{
    bool canAttack = true;
    float timer = 0;
    float cooldown = 0.3f;
    int level = 0;
    bool isTaken;
    [SerializeField] Sprite poisonAreaSprite;
    int damage = 3;
    [SerializeField] TextMeshProUGUI poisonGasText;
    [SerializeField] GameObject poisonButton;
    [SerializeField] GameObject poisonIcon;


    
    // Start is called before the first frame update

    
    

    // Update is called once per frame
    void Update()
    {
        if (!canAttack)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                canAttack = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && canAttack)
        {
           collision.gameObject.GetComponent<EnemyScript>().healthPoints -= damage;
           canAttack = false;
        }
            
    }

    public void PoisonGasButton()
    {

        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {   
            PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {   PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        level++;
        poisonGasText.text = "Poison Gas L" + (level + 1);
        if(level == 2)
        {
            damage += 1;
            gameObject.transform.localScale = new Vector2(2.2f, 2.2f);
        }

        if (level >= 3)
        {
            damage += 1;
            gameObject.transform.localScale = new Vector2(2.6f, 2.6f);
            TurnOffMenuScript.instance.TurnOffButton(poisonButton, poisonIcon);
            poisonGasText.text = "No More Levels";
        }

        
        gameObject.SetActive(true);
        ShootingScript.instance.upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
    }
}
