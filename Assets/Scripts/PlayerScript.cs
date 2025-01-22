using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    float xInput;
    float yInput;
    [SerializeField] float moveSpeed = 4f;
    Vector3 moveVector;
    int healthPoints = 3;
    Rigidbody2D rb;
    [SerializeField] GameObject[] enemy;
    [SerializeField] float playerSaveTimeSeconds = 1.5f;
    [SerializeField] GameObject gameOverMenu;
    private float playerpositionX;
    private float playerpositionY;
    [SerializeField] float maxposX;
    [SerializeField] float maxposY;
    [SerializeField] GameObject[] healthUI;
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject speedButton;
    [SerializeField] Sprite speedSprite;
    [SerializeField] Sprite shieldSprite;
    float speedLevel = 0;
    bool isTaken = false;
    bool shieldPowerTaken = false;
    [SerializeField] GameObject[] shieldUI;
    int shieldHealth = 0;
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (healthPoints == 2)
        {
            healthUI[2].SetActive(false);
        }

        if (healthPoints == 1)
        {
            healthUI[1].SetActive(false);
        }

        if (healthPoints <= 0)
        {
            healthUI[0].SetActive(false);
            gameObject.transform.DetachChildren();
            gameOverMenu.SetActive(true);
            Destroy(gameObject);
        }

        ClampPlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void ClampPlayer()
    {
        playerpositionX = Mathf.Clamp(transform.position.x, -maxposX, maxposX);
        playerpositionY = Mathf.Clamp(transform.position.y, -maxposY, maxposY);
        transform.position = new Vector2(playerpositionX, playerpositionY);
    }

    void MovePlayer()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        moveVector = new Vector3(xInput, yInput, 0).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (shieldHealth != 0)
            {
                shieldHealth--;
                
            }
            else
            {
                healthPoints -= 1;
            }
            

            if(shieldHealth == 1)
            {
                shieldUI[0].SetActive(false);
            }

            if (shieldHealth == 0)
            {
                shieldUI[1].SetActive(false);
            }
            else
            {
                shieldUI[1].SetActive(true);
            }

            Destroy(collision.gameObject);
            StartCoroutine(safeTime());

            IEnumerator safeTime()
            {

                if (collision.gameObject.tag == "Enemy")
                {
                    healthPoints -= 0;
                }
                yield return new WaitForSeconds(playerSaveTimeSeconds);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
                if (healthPoints < 3)
                {
                    healthPoints++;
                }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Shield")
        {
            if (shieldHealth < 2)
            {
                shieldHealth++;
                if (shieldHealth == 1)
                {
                    if (shieldUI[1].activeSelf)
                        shieldUI[1].SetActive(false);
                }
                else
                {
                    shieldUI[1].SetActive(true);
                }
                if (shieldHealth == 2)
                {
                    if (shieldUI[2].activeSelf)
                        shieldUI[1].SetActive(false);
                }
                else
                {
                    shieldUI[1].SetActive(true);
                }
            }
            
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void SpeedUpButton()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = speedSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = speedSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = speedSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }

        else if (PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !isTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = speedSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            isTaken = true;
        }
        speedLevel++;
        if(speedLevel == 1)
        {
            moveSpeed += 1;
        }
        if(speedLevel == 2)
        {
            moveSpeed += 2;
            speedButton.SetActive(false);
        }
        upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShieldPower()
    {
        if (!PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !shieldPowerTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<Image>().sprite = shieldSprite;
            PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed = true;
            shieldPowerTaken = true;
        }
        else if (PowerUpBoxes.instance.powerUpBoxes[0].GetComponent<PowerUpBox>().isUsed & !shieldPowerTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<Image>().sprite = shieldSprite;
            PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed = true;
            shieldPowerTaken = true;
        }

        else if (PowerUpBoxes.instance.powerUpBoxes[1].GetComponent<PowerUpBox>().isUsed & !shieldPowerTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<Image>().sprite = shieldSprite;
            PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed = true;
            shieldPowerTaken = true;
        }

        else if (PowerUpBoxes.instance.powerUpBoxes[2].GetComponent<PowerUpBox>().isUsed & !shieldPowerTaken)
        {
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<Image>().sprite = shieldSprite;
            PowerUpBoxes.instance.powerUpBoxes[3].GetComponent<PowerUpBox>().isUsed = true;
            shieldPowerTaken = true;
        }
        shieldHealth = 2;
        shieldUI[0].SetActive(true);
        shieldUI[1].SetActive(true);
        upgradeMenu.SetActive(false);
        PowerUpDescText.instance.descObject.SetActive(false);
        Time.timeScale = 1;
    }
}
