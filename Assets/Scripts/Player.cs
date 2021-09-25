using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float padding = 1f;
    public int currentHealth = 300;
    public int maxHealth;
    [SerializeField] GameObject explotionParticle;
    [SerializeField] float durationOfExplotion = 2f;

    [Header("Laser")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] float LaserFiringPeriod = 0.1f;

    [Header("Sound")]
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.75f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    public SpriteRenderer spriteRenderer;

    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
        maxHealth = currentHealth;
        SetUpMoveBoundaries();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuosusly());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuosusly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(LaserFiringPeriod);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
        // Destroy(other.gameObject);

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        currentHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        // Destroy(damageDealer.gameObject);

        if (currentHealth <= 0)
        {
            Die();
            currentHealth = 0;
        }
    }

    private void Die()
    {
        // Untuk menghapus diri
        Destroy(gameObject);

        // Efek suara
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);

        // Efek meledak
        GameObject explotion = Instantiate(explotionParticle, transform.position, transform.rotation);

        // Hancurkan dalam durasi waktu
        Destroy(explotion, durationOfExplotion);

        // Karena player mati, maka pindah ke scene game over
        FindObjectOfType<Level>().LoadGameOver();
    }

}
