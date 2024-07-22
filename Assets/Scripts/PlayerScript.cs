using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    float xInput;
    float yInput;
    [SerializeField] float moveSpeed = 4f;
    Vector3 moveVector;
    void Start()
    {
        
    }

    void Update()
    {
        
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
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }
    }
}
