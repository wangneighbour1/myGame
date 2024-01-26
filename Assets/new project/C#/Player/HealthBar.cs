using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public static int healthCourrent;
    public static int healthMax;
    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        healthCourrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)healthCourrent / (float)healthMax;
        healthText.text = healthCourrent.ToString() + "/" + healthMax.ToString();
    }
}
