using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public static int healthCurrent;
    public static int healthMax;
    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = 1 - (float)((float)healthCurrent / (float)healthMax);
        Debug.Log((float)(healthCurrent / healthMax));
        healthText.text = healthCurrent.ToString() + "/" + healthMax.ToString();
    }
}
