using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 5f;
    public int healthPoints = 50;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");            
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
