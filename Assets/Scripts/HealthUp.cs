using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] int healthUpValue = 100;
    private Player player;
    private GameSession gameSession;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.currentHealth < player.maxHealth)
            {
                player.currentHealth += healthUpValue;
                if (player.currentHealth > player.maxHealth)
                {
                    player.currentHealth = 300;
                    gameSession.AddToScore(player.maxHealth);
                }
            }
            Destroy(gameObject);
        }
    }
}
