using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Vector3 mousePosition;
    new Camera camera;
    Rigidbody2D rb;
    [SerializeField] float bulletSpeed;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDir = mousePosition - transform.position;
        Vector3 shootRotation = transform.position - mousePosition;
        rb.velocity = new Vector2(shootDir.x, shootDir.y).normalized * bulletSpeed;
        float rotation = Mathf.Atan2(shootRotation.y, shootRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 90f);
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }


    }
}
