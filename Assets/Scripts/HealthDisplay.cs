using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text healthText;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        healthText = FindObjectOfType<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // healthText.text = player.GetHealth().ToString() + "/" + "300";
        healthText.text = player.currentHealth.ToString() + "/" + player.maxHealth;
    }
}
