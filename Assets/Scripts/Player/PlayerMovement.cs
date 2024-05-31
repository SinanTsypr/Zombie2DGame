using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Oyuncunun hareket hýzýný belirleyen deðiþken
    public Rigidbody2D rb;  // Oyuncunun Rigidbody2D bileþenine referans
    private Vector2 movement;  // Oyuncunun hareket yönünü ve büyüklüðünü tutan vektör

    void Update()
    {
        // Yatay (Horizontal) ve dikey (Vertical) eksenlerden girdi alýr
        // Bu girdiler klavye veya gamepad'den gelir (örneðin, W-A-S-D tuþlarý veya ok tuþlarý)
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Hareketi fiziksel olarak gerçekleþtirmek için Rigidbody2D bileþenini kullanýr
        // rb.position: Oyuncunun þu anki pozisyonu
        // movement * moveSpeed: Hareket vektörünün büyüklüðünü belirleyen hýz faktörü
        // Time.fixedDeltaTime: Sabit zaman aralýðý (fizik güncellemeleri için)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu baþka bir nesneyle çarpýþtýðýnda çalýþýr
        // Çarpýþýlan nesnenin adýný konsola yazdýrýr
        Debug.Log("Player collided with: " + collision.gameObject.name);
    }
}
