using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    // Referencja do tekstu
    // Referencja do PlayerHealth
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;

    }

    // Update is called once per frame
    public void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
    }
}
