using System.Collections;
using UnityEngine;

public class AutoBulletMove1 : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyBullet());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -bulletSpeed * Time.deltaTime, 0);
    }

    public IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}