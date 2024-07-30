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
    [SerializeField] GameObject[] enemy;
    [SerializeField] float playerSaveTimeSeconds = 1.5f;
    [SerializeField] GameObject gameOverMenu;
    //[SerializeField] GameObject[] healthUI;
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
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
    }

    public void GameOverMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        MovePlayer();
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
}
