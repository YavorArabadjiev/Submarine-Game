using System.Collections;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class CreatureScript : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    [SerializeField] GameObject[] locations;   
    float creaturePosX, creaturePosY;
    int randomPos;
   [SerializeField] float speed;
   [HideInInspector] public static CreatureScript instance;
    bool canMove = false;
    bool isTaken = false;
    [SerializeField] Sprite creatureSprite;
    int level = 0;
    [SerializeField] GameObject creatureButton;
    [SerializeField] GameObject creatureIcon;
    [SerializeField] GameObject creature1;
    //[SerializeField] GameObject creature2;
    [SerializeField] TextMeshProUGUI creatureButtonText;
    [SerializeField] GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(MoveAround());
    }

    // Update is called once per frame
    

    public IEnumerator MoveAround()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            randomPos = Random.Range(0, locations.Length);
            canMove = true;
            yield return new WaitForSeconds(waitTime);
            canMove = false;
            ClampCreature();


        }


        
    }

    public void ActivateCreature()
    {
        
        ButtonSoundScript.instance.pickUpPowerUpSound.Play();
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = creatureSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = creatureSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = creatureSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        if (!PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[3].SetActive(true);
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = creatureSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        creature1.SetActive(true);
        gameObject.transform.position = new Vector2(player.transform.position.x + 2, player.transform.position.y - 1.5f);
        level++;
        TurnOffMenuScript.instance.TurnOffMenu();


        if (level == 2)
        {
            gameObject.transform.localScale = new Vector2 (2.5f, 2.5f);
        }

        if (level == 3)
        {
            gameObject.transform.localScale = new Vector2(3f, 3f);
            
        }

        if (level == 4)
        {
            gameObject.transform.localScale = new Vector2(3.3f, 3.3f);
            TurnOffMenuScript.instance.TurnOffButton(creatureButton, creatureIcon);
            creatureButtonText.text = "No More Levels";
        }
    }

    private void ClampCreature()
    {
        creaturePosX = Mathf.Clamp(transform.position.x, -24, 21);
        creaturePosY = Mathf.Clamp(transform.position.y, -12, 11);
        transform.position = new Vector2(creaturePosX, creaturePosY);
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
           gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, locations[randomPos].transform.position, speed * Time.deltaTime);
        }
        else
        {
            return;
        }
    }
}


