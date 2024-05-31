using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;  // D��man�n hareket h�z�n� belirleyen de�i�ken
    private Transform player;  // Oyuncunun konumuna referans

    void Start()
    {
        // Oyuncu nesnesini bulur ve referans al�r
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Oyuncuya do�ru olan y�n� hesaplar
        Vector3 direction = (player.position - transform.position).normalized;
        // D��man�n hareketini sa�lar
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
