using System.Collections;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    int randomposX;
    int randomposY;
    float creaturePosX, creaturePosY;
   [HideInInspector] public static CreatureScript instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine(MoveAround());
    }

    // Update is called once per frame
    

    public IEnumerator MoveAround()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            randomposX = Random.Range(-5, 5);
            randomposY = Random.Range(-3, 3);
            transform.Translate(randomposX, randomposY, 0);
            ClampCreature();
        }


        
    }

    private void ClampCreature()
    {
        creaturePosX = Mathf.Clamp(transform.position.x, -12, 12);
        creaturePosY = Mathf.Clamp(transform.position.y, -10, 10);
        transform.position = new Vector2(creaturePosX, creaturePosY);
    }
}
