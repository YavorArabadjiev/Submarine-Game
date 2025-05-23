using System.Collections;
using UnityEngine;

public class AutoBulletMove3 : MonoBehaviour
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
        transform.Translate(-bulletSpeed * Time.deltaTime, 0, 0);

    }

    public IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
