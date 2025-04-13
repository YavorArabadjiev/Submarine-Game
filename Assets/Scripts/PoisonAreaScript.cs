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
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        {   PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {   PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = poisonAreaSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        level++;
        poisonGasText.text = "Poison Gas L" + level;
        if(level == 2)
        {
            gameObject.transform.localScale = new Vector2(3.8f, 3.8f);
        }

        if (level == 3)
        {
            gameObject.transform.localScale = new Vector2(5f, 5f);
        }
        gameObject.SetActive(true);
        ShootingScript.instance.upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
    }
}
