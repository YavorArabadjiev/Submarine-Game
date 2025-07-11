using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceBar : MonoBehaviour
{

   public float currentXp = 0f;
   [SerializeField] private float maxXp = 100f;
   public int level = 0;
   [SerializeField] private Image XpBar;
   [SerializeField] TextMeshProUGUI levelText;
   [SerializeField] public GameObject upgradeMenu;
   [HideInInspector] public static ExperienceBar instance;


    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       ExperienceGain();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    currentXp += 20;
        //}
    }

    

    private void ExperienceGain()
    {
        XpBar.fillAmount = currentXp / maxXp;
        levelText.text = "Level: " + level.ToString();
        if (currentXp >= maxXp) 
        { 
            level = level + 1;
            currentXp = currentXp - maxXp;
            maxXp = maxXp * 2;
            Time.timeScale = 0f;
            upgradeMenu.SetActive(true);
        }
    }
}
