using TMPro;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] float moveSpeed = 15f;
    public float xpPoints = 20f;
    [SerializeField] float distanceBetweenPlayer = 2f;
    ExperienceBar experienceBar;
    int gemUpgradeLevel = 0;
    [SerializeField] Sprite gemSprite;
    //[SerializeField] TextMeshProUGUI gemUpgradeText;
    //bool isTaken = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        experienceBar = GameObject.FindGameObjectWithTag("Bar").GetComponent<ExperienceBar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null)
        {
            if (Vector2.Distance(player.transform.position, gameObject.transform.position) <= distanceBetweenPlayer)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            experienceBar.currentXp += xpPoints;
            Destroy(gameObject);
        }
    }

    public void GemUpgradeButton()
    {
        gemUpgradeLevel++;
        //gemUpgradeText.text = "Gem Upgrade L" + gemUpgradeLevel;
        //if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        //{
        //    PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = gemSprite;
        //    PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
        //    isTaken = true;
        //}
        //else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        //{
        //    PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = gemSprite;
        //    PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
        //    isTaken = true;
        //}
        //else if (PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        //{
        //    PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = gemSprite;
        //    PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
        //    isTaken = true;
        //}
        

        if (gemUpgradeLevel <= 3)
        {
            xpPoints = xpPoints * 1.2f;
        }
        
    }

}
