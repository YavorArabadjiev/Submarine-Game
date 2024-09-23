using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{

    float xInput;
    float yInput;
    [SerializeField] float moveSpeed = 4f;
    Vector3 moveVector;
    //[SerializeField] int healthPoints = 3;
    Rigidbody2D rb;
    [SerializeField] GameObject[] enemy;
    [SerializeField] float playerSaveTimeSeconds = 1.5f;
    [SerializeField] GameObject gameOverMenu;
    private float playerpositionX;
    private float playerpositionY;
    [SerializeField] float maxposX;
    [SerializeField] float maxposY;
    //[SerializeField] GameObject[] healthUI'
    [SerializeField] GameObject upgradeMenu;
    [SerializeField] GameObject speedButton;
    float speedLevel = 0;
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if(healthPoints == 2) 
        //{
        //    healthUI[2].SetActive(false);
        //}

        //if (healthPoints == 1)
        //{
        //    healthUI[1].SetActive(false);
        //}

        //if (healthPoints <= 0)
        //{
        //    healthUI[0].SetActive(false);
        //    gameObject.transform.DetachChildren();
        //    gameOverMenu.SetActive(true);
        //    Destroy(gameObject);
        //}

        ClampPlayer();
    }

    public void GameOverMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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


            //healthPoints -= 1;
            Destroy(collision.gameObject);
            StartCoroutine(safeTime());

            IEnumerator safeTime()
            {

                if (collision.gameObject.tag == "Enemy")
                {
                    //healthPoints -= 0;
                }
                yield return new WaitForSeconds(playerSaveTimeSeconds);
            }
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
}
