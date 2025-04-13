using UnityEngine;

public class GunScript : MonoBehaviour
{
    Vector3 camVector;
    [SerializeField] Camera cam;

    // Update is called once per frame
    void Update()
    {
        CameraCode();
        
    }


    void CameraCode()
    {
        camVector = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = camVector - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
