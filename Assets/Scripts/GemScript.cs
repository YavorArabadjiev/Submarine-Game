using UnityEngine;

public class GemScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] float moveSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
