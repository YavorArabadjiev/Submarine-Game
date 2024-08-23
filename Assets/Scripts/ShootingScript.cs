using System;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject[] bullet;
    [SerializeField] int level = 1;
    GameObject upgradeMenu;
    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu = GameObject.FindGameObjectWithTag("UpgradeMenu");  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && level == 1)
        {
            Instantiate(bullet[0], transform.position, Quaternion.identity);
            
        }
        if(level >= 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(bullet[1], transform.position, Quaternion.identity);
            }
                
        }

        
    }

    public void BulletLevelUpgrade()
    {
        level = level + 1;
        upgradeMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

    
