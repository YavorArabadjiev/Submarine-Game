using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GemScript : MonoBehaviour
{
    GameObject player;
    [SerializeField] float moveSpeed = 15f;
    public int xpPoints = 0;
    [SerializeField] float distanceBetweenPlayer = 2f;
    [SerializeField] ExperienceBar experienceBar;
  

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        experienceBar = GameObject.FindGameObjectWithTag("Bar").GetComponent<ExperienceBar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(player.transform.position, gameObject.transform.position) <= distanceBetweenPlayer)
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            experienceBar.currentXp += 20;
            Destroy(gameObject);
        }
    }

}
