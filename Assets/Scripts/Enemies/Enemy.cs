using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;  // D��man�n hareket h�z�n� belirleyen de�i�ken
    public int damage = 10;  // D��man�n oyuncuya verece�i hasar miktar�
    private Transform player;  // Oyuncunun konumuna referans
    private Rigidbody2D rb;  // D��man�n Rigidbody2D bile�eni

    void Start()
    {
        // Oyuncu nesnesini bulur ve referans al�r
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D bile�enine referans al
    }

    void Update()
    {
        // Oyuncuya do�ru olan y�n� hesaplar
        Vector3 direction = (player.position - transform.position).normalized;
        // D��man�n hareketini sa�lar
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // E�er �arp��an nesne oyuncuysa
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player");

            // PlayerHealth script'ini al ve hasar ver
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Rigidbody'lerin h�zlar�n� s�f�rla
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
