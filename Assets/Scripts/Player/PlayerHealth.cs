using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Oyuncunun maksimum saðlýðý
    public int currentHealth;  // Oyuncunun mevcut saðlýðý
    public Image healthBarFront;  // Ekranýn sol üstündeki saðlýk barý
    public Image healthBarFrontInWorld;  // Karakterin üzerindeki saðlýk barý
    private float initialHealthBarWidth;  // Ekranýn sol üstündeki saðlýk barýnýn baþlangýç geniþliði
    private float initialHealthBarWidthInWorld;  // Karakterin üzerindeki saðlýk barýnýn baþlangýç geniþliði

    public GameManager gameManager;  // GameManager referansý

    void Start()
    {
        // Baþlangýçta oyuncunun saðlýðýný maksimum deðere ayarla
        currentHealth = maxHealth;

        // Saðlýk barlarýnýn baþlangýç geniþliðini kaydet
        initialHealthBarWidth = healthBarFront.rectTransform.sizeDelta.x;
        initialHealthBarWidthInWorld = healthBarFrontInWorld.rectTransform.sizeDelta.x;

        // Saðlýk barlarýný güncelle
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        // Alýnan hasarý mevcut saðlýktan düþ
        currentHealth -= amount;

        // Saðlýk barlarýný güncelle
        UpdateHealthBar();

        // Saðlýk sýfýrýn altýna düþerse, oyuncunun öldüðünü kontrol et
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // Saðlýk barlarýnýn geniþliðini güncelle
        float healthPercent = (currentHealth / (float)maxHealth);

        // Ekranýn sol üstündeki saðlýk barýnýn geniþliðini güncelle
        float newWidth = initialHealthBarWidth * healthPercent;
        healthBarFront.rectTransform.sizeDelta = new Vector2(newWidth, healthBarFront.rectTransform.sizeDelta.y);

        // Karakterin üzerindeki saðlýk barýnýn geniþliðini güncelle
        float newWidthInWorld = initialHealthBarWidthInWorld * healthPercent;
        healthBarFrontInWorld.rectTransform.sizeDelta = new Vector2(newWidthInWorld, healthBarFrontInWorld.rectTransform.sizeDelta.y);
    }

    void Die()
    {
        Debug.Log("Player died!");

        // GameManager'deki GameOver metodunu çaðýr
        if (gameManager != null)
        {
            Debug.Log("Calling GameOver method on GameManager.");
            gameManager.GameOver();
        }
        else
        {
            Debug.LogError("GameManager is not assigned in PlayerHealth script.");
        }
    }
}
