using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Oyuncunun maksimum saðlýðý
    public int currentHealth;  // Oyuncunun mevcut saðlýðý
    public Image healthBarFront;  // Yeþil saðlýk barý Image componenti

    void Start()
    {
        // Baþlangýçta oyuncunun saðlýðýný maksimum deðere ayarla
        currentHealth = maxHealth;
        // Saðlýk barýný güncelle
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Saðlýk barýnýn geniþliðini güncelle
        healthBarFront.rectTransform.sizeDelta = new Vector2((currentHealth / (float)maxHealth) * 100f, healthBarFront.rectTransform.sizeDelta.y);
    }

    public void TakeDamage(int amount)
    {
        // Alýnan hasarý mevcut saðlýktan düþ
        currentHealth -= amount;
        // Saðlýk barýný güncelle
        UpdateHealthBar();

        // Saðlýk sýfýrýn altýna düþerse, oyuncunun öldüðünü kontrol et
        if (currentHealth < 0) {
            Die();
        }
    }

    void Die()
    {
        // Oyuncunun öldüðünde yapýlacak iþlemler (örneðin, oyunu bitir)
        Debug.Log("Player died!");
        // Oyunu durdur
        Time.timeScale = 0f;
    }
}
