using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBulletMove2 : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
    }
}
