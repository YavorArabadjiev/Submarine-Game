using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject[] bullet;
   [HideInInspector] public int level = 1;
    public GameObject upgradeMenu;
    [SerializeField] GameObject bulletAmountButton;
    [SerializeField] GameObject reloadSpeedButton;
    int bulletsShot = 0;
    int bulletCount = 5;
    float timer = 0;
    float reloadTime = 2f;
    int bulletAmountLevel = 0;
    int reloadSpeedLevel = 0;
    [SerializeField] Sprite bulletAmountSprite;
    [SerializeField] Sprite reloadSprite;
    [SerializeField] Sprite biggerBulletSprite;
    bool isTaken = false;
    public static ShootingScript instance;
    int numberOfBulletsUI = 5;
    [SerializeField] GameObject[] bulletsUI;
    bool reload = false;
    [SerializeField] TextMeshProUGUI biggerBulletsText;
    [SerializeField] TextMeshProUGUI bulletAmountText;
    [SerializeField] TextMeshProUGUI reloadSpeedText;
    [SerializeField] GameObject biggerBulletButton;
    [SerializeField] GameObject biggerBulletIcon;
    [SerializeField] GameObject bulletAmountIcon;
    [SerializeField] GameObject reloadSpeedIcon;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

   

    // Update is called once per frame
    void Update()
    {
        //make bullets bigger
        if (Input.GetButtonDown("Fire1") && level == 1 && bulletsShot < bulletCount)
        {
            bulletsShot++;
            Instantiate(bullet[0], transform.position, Quaternion.identity);
        }
        if(level == 2)
        {
            if (Input.GetButtonDown("Fire1") && bulletsShot < bulletCount)
            {
                bulletsShot++;
                Instantiate(bullet[1], transform.position, Quaternion.identity);
            }
                
        }

        if (level >= 3)
        {
            if (Input.GetButtonDown("Fire1") && bulletsShot < bulletCount)
            {
                bulletsShot++;
                Instantiate(bullet[2], transform.position, Quaternion.identity);
            }

            TurnOffMenuScript.instance.TurnOffButton(biggerBulletButton, biggerBulletIcon);
            biggerBulletsText.text = "No More Levels";
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            numberOfBulletsUI--;
            if (numberOfBulletsUI == 4)
            {
                bulletsUI[0].SetActive(false);
            }
            if (numberOfBulletsUI == 3)
            {
                bulletsUI[1].SetActive(false);
            }

            if (numberOfBulletsUI == 2)
            {
                bulletsUI[2].SetActive(false);
            }

            if (numberOfBulletsUI == 1)
            {
                bulletsUI[3].SetActive(false);
            }

            if (numberOfBulletsUI == 0)
            {
                bulletsUI[4].SetActive(false);
            }
        }
        if (bulletsShot >= bulletCount || reload == true)
        {
            timer += Time.deltaTime;
            if(timer > reloadTime)
            {
                bulletsShot = 0;
                foreach(GameObject bullet in bulletsUI)
                {
                    bullet.SetActive(true);
                }
                numberOfBulletsUI = 5;
                timer = 0;
                reload = false;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            reload = true;
        }
        
    }

    public void BulletLevelUpgrade()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = biggerBulletSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = biggerBulletSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = biggerBulletSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {   PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = biggerBulletSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        
        level += 1;
        biggerBulletsText.text = "Make Bullets Bigger L" + (level + 1);
        PowerUpDescText.instance.descObject.SetActive(false);
        upgradeMenu.SetActive(false);
        Time.timeScale = 1.0f;
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
    }

    public void BulletAmountUpgrade()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = bulletAmountSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {   
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = bulletAmountSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {   
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = bulletAmountSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {   
            PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = bulletAmountSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        bulletAmountLevel += 1;
        bulletAmountText.text = "Make Bullets Bigger L" + (bulletAmountLevel + 1);
        if (bulletAmountLevel >= 9)
        {
            TurnOffMenuScript.instance.TurnOffButton(bulletAmountButton, bulletAmountIcon);
            bulletAmountText.text = "No More Levels";
        }
        upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1.0f;
        bulletCount += 1;
        numberOfBulletsUI += 1;
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
    }

    public void ReloadSpeed()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = reloadSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = reloadSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = reloadSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = reloadSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        reloadSpeedLevel += 1;
        reloadSpeedText.text = "Reload Speed" + (reloadSpeedLevel + 1);
        upgradeMenu.SetActive(false);
        if (reloadSpeedLevel >= 3)
        {
            TurnOffMenuScript.instance.TurnOffButton(reloadSpeedButton, reloadSpeedIcon);
            reloadSpeedText.text = "No More Levels";
        }
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1.0f;
        reloadTime -= 0.5f;
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
    }
}

    
