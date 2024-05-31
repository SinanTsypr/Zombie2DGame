using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Oyuncunun hareket h�z�n� belirleyen de�i�ken
    public Rigidbody2D rb;  // Oyuncunun Rigidbody2D bile�enine referans
    private Vector2 movement;  // Oyuncunun hareket y�n�n� ve b�y�kl���n� tutan vekt�r

    void Update()
    {
        // Yatay (Horizontal) ve dikey (Vertical) eksenlerden girdi al�r
        // Bu girdiler klavye veya gamepad'den gelir (�rne�in, W-A-S-D tu�lar� veya ok tu�lar�)
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Hareketi fiziksel olarak ger�ekle�tirmek i�in Rigidbody2D bile�enini kullan�r
        // rb.position: Oyuncunun �u anki pozisyonu
        // movement * moveSpeed: Hareket vekt�r�n�n b�y�kl���n� belirleyen h�z fakt�r�
        // Time.fixedDeltaTime: Sabit zaman aral��� (fizik g�ncellemeleri i�in)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu ba�ka bir nesneyle �arp��t���nda �al���r
        // �arp���lan nesnenin ad�n� konsola yazd�r�r
        Debug.Log("Player collided with: " + collision.gameObject.name);
    }
}
