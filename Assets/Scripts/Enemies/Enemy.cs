using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;  // Düþmanýn hareket hýzýný belirleyen deðiþken
    public int damage = 10;  // Düþmanýn oyuncuya vereceði hasar miktarý
    private Transform player;  // Oyuncunun konumuna referans
    private Rigidbody2D rb;  // Düþmanýn Rigidbody2D bileþeni

    void Start()
    {
        // Oyuncu nesnesini bulur ve referans alýr
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D bileþenine referans al
    }

    void Update()
    {
        // Oyuncuya doðru olan yönü hesaplar
        Vector3 direction = (player.position - transform.position).normalized;
        // Düþmanýn hareketini saðlar
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Eðer çarpýþan nesne oyuncuysa
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player");

            // PlayerHealth script'ini al ve hasar ver
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Rigidbody'lerin hýzlarýný sýfýrla
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;
                playerRb.angularVelocity = 0f;
            }
        }
    }
}
