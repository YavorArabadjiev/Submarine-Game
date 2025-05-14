using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticFireWeapon : MonoBehaviour
{
    [SerializeField] float shootTime = 2.5f;
    [SerializeField] GameObject[] autoPellets;
    GameObject player;
    float level = 0;
    [HideInInspector] public static AutomaticFireWeapon instance;
    public int autoWeaponShootPower = 25;
    [SerializeField] GameObject autoBulletsButton;
    [SerializeField] Sprite autoSpikesSprite;
    bool isTaken;
    [SerializeField] TextMeshProUGUI automaticFireWeaponText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(autoShoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator autoShoot() 
    { 
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            
            if(player != null)
            {
                Instantiate(autoPellets[0], new Vector2(player.transform.position.x, player.transform.position.y + 1), Quaternion.identity);
                Instantiate(autoPellets[1], new Vector2(player.transform.position.x, player.transform.position.y - 1), Quaternion.identity);
                Instantiate(autoPellets[2], new Vector2(player.transform.position.x + 1, player.transform.position.y), Quaternion.identity);
                Instantiate(autoPellets[3], new Vector2(player.transform.position.x - 1, player.transform.position.y), Quaternion.identity);
            }
                

            yield return new WaitForSeconds(1f);

            
        }
    }

    public void AutoBulletsButton()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = autoSpikesSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = autoSpikesSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }

        else if (PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = autoSpikesSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }

        else if (PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = autoSpikesSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        level++;
        automaticFireWeaponText.text = "Auto Spikes L" + level;
        if(level == 1)
        {
            StartCoroutine(autoShoot());
        }
        ExperienceBar.instance.upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        PowerUpDescText.instance.descObject.SetActive(false);
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
        if (level == 2)
        {
            shootTime = 3f;
        }

        if (level == 3)
        {
            shootTime = 1f;
        }
        if(level == 4)
        {
            autoWeaponShootPower = 50;
            autoBulletsButton.SetActive(false);
        }
    }

    

    
}
