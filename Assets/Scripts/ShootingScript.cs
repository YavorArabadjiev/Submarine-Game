using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }    
    }

    
}
