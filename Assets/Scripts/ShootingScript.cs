using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject[] bullet;
    [SerializeField] int level = 1;
    [SerializeField] GameObject upgradeMenu;
    int bulletsShot = 0;
    int bulletCount = 4;
    bool canshoot = true;
    float timer = 0;
    float reloadTime = 2f;
    int bulletAmountLevel = 0;
    
    
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
        level += 1;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BulletAmountUpgrade()
    {
        bulletAmountLevel += 1;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1.0f;
        if(bulletAmountLevel == 1)
        bulletCount += 1;
    }
}

    
