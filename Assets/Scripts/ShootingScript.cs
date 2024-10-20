using System;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject[] bullet;
    int level = 1;
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject bulletAmountButton;
    [SerializeField] GameObject reloadSpeedButton;
    int bulletsShot = 0;
    int bulletCount = 4;
    float timer = 0;
    float reloadTime = 2f;
    int bulletAmountLevel = 0;
    int reloadSpeedLevel = 0;
    [SerializeField] Sprite bulletAmountSprite;
    [SerializeField] Sprite reloadSprite;
    [SerializeField] Sprite biggerBulletSprite;
    bool isTaken = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //upgradeMenu = GameObject.FindGameObjectWithTag("UpgradeMenu");
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && level == 1 && bulletsShot < bulletCount)
        {
            bulletsShot++;
            Instantiate(bullet[0], transform.position, Quaternion.identity);
        }
        if(level >= 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(bullet[1], transform.position, Quaternion.identity);
            }
                
        }

        if(bulletsShot >= bulletCount)
        {
            timer += Time.deltaTime;
            if(timer > reloadTime)
            {
                bulletsShot = 0;
                timer = 0;
            }
        }
        
    }

    public void BulletLevelUpgrade()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = biggerBulletSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = biggerBulletSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        level += 1;
        PowerUpDescText.instance.descObject.SetActive(false);
        upgradeMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BulletAmountUpgrade()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = bulletAmountSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            //PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().color = Color.red;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = bulletAmountSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        bulletAmountLevel += 1;
        if (bulletAmountLevel == 9)
        {
            bulletAmountButton.SetActive(false);
        }
        upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1.0f;
        bulletCount += 1;
    }

    public void ReloadSpeed()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = reloadSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = reloadSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        reloadSpeedLevel += 1;
        upgradeMenu.SetActive(false);
        if (reloadSpeedLevel == 3)
        {
            reloadSpeedButton.SetActive(false);
        }
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1.0f;
        reloadTime -= 0.5f;
    }
}

    
