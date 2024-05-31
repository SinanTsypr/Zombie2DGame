using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;  // Düþmanýn hareket hýzýný belirleyen deðiþken
    private Transform player;  // Oyuncunun konumuna referans

    void Start()
    {
        // Oyuncu nesnesini bulur ve referans alýr
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Oyuncuya doðru olan yönü hesaplar
        Vector3 direction = (player.position - transform.position).normalized;
        // Düþmanýn hareketini saðlar
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
