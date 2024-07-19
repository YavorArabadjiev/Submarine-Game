using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed = 5f;
    [SerializeField] float minimumPos = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, player.transform.position) > minimumPos)
        Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
