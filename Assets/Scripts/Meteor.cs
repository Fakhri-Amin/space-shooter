using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] int health = 600;
    [SerializeField] GameObject explotionParticle;
    [SerializeField] float durationOfExplotion = 2f;

    [SerializeField] AudioClip explodeSound;
    [SerializeField] [Range(0, 1)] float explodeSoundVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        health -= damageDealer.GetDamage();

        if (!other.gameObject.CompareTag("Player"))
        {
            damageDealer.Hit();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explodeSound, Camera.main.transform.position, explodeSoundVolume);
            GameObject explotion = Instantiate(explotionParticle, transform.position, transform.rotation);
            Destroy(explotion, 2f);
        }


    }
}
