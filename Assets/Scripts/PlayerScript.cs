using System.Collections;
using UnityEngine;
using TMPro;
public class PlayerScript : MonoBehaviour
{

    float xInput;
    float yInput;
    [SerializeField] float moveSpeed = 4f;
    Vector3 moveVector;
    [SerializeField] int healthPoints = 3;
    [SerializeField] GameObject[] enemy;
    [SerializeField] float playerSaveTimeSeconds = 1.5f;
    [SerializeField] TextMeshProUGUI playerHealthText;
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        playerHealthText.text = healthPoints.ToString();

        if(healthPoints <= 0)
        {
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }
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
            //gameObject.transform.DetachChildren();
            //Destroy(gameObject);

            healthPoints -= 1;
            StartCoroutine(safeTime());

            IEnumerator safeTime()
            {
                //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemy[0].GetComponent<Collider2D>());
                //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemy[1].GetComponent<Collider2D>());
                if(collision.gameObject.tag == "Enemy")
                {
                    healthPoints -= 0;
                }
                yield return new WaitForSeconds(playerSaveTimeSeconds);
                //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemy[0].GetComponent<Collider2D>(), false);
                //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), enemy[1].GetComponent<Collider2D>(), false);
            }

            
        }
    }

}
