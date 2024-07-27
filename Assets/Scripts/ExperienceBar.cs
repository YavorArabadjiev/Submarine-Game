using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{

   public float currentXp = 0f;
   [SerializeField] private float maxXp = 100f;
   [SerializeField] private int level = 0;
   [SerializeField] private Image XpBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       ExperienceGain();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentXp += 20;
        }
    }

    

    private void ExperienceGain()
    {
        XpBar.fillAmount = currentXp / maxXp;

        if (currentXp >= maxXp) 
        { 
            level = level + 1;
            currentXp = currentXp - maxXp;
            maxXp = maxXp * 2;
        }
    }
}
