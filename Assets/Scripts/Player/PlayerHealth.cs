using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Oyuncunun maksimum sa�l���
    public int currentHealth;  // Oyuncunun mevcut sa�l���
    public Image healthBarFront;  // Ekran�n sol �st�ndeki sa�l�k bar�
    public Image healthBarFrontInWorld;  // Karakterin �zerindeki sa�l�k bar�
    private float initialHealthBarWidth;  // Ekran�n sol �st�ndeki sa�l�k bar�n�n ba�lang�� geni�li�i
    private float initialHealthBarWidthInWorld;  // Karakterin �zerindeki sa�l�k bar�n�n ba�lang�� geni�li�i

    public GameManager gameManager;  // GameManager referans�

    void Start()
    {
        // Ba�lang��ta oyuncunun sa�l���n� maksimum de�ere ayarla
        currentHealth = maxHealth;

        // Sa�l�k barlar�n�n ba�lang�� geni�li�ini kaydet
        initialHealthBarWidth = healthBarFront.rectTransform.sizeDelta.x;
        initialHealthBarWidthInWorld = healthBarFrontInWorld.rectTransform.sizeDelta.x;

        // Sa�l�k barlar�n� g�ncelle
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        // Al�nan hasar� mevcut sa�l�ktan d��
        currentHealth -= amount;

        // Sa�l�k barlar�n� g�ncelle
        UpdateHealthBar();

        // Sa�l�k s�f�r�n alt�na d��erse, oyuncunun �ld���n� kontrol et
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // Sa�l�k barlar�n�n geni�li�ini g�ncelle
        float healthPercent = (currentHealth / (float)maxHealth);

        // Ekran�n sol �st�ndeki sa�l�k bar�n�n geni�li�ini g�ncelle
        float newWidth = initialHealthBarWidth * healthPercent;
        healthBarFront.rectTransform.sizeDelta = new Vector2(newWidth, healthBarFront.rectTransform.sizeDelta.y);

        // Karakterin �zerindeki sa�l�k bar�n�n geni�li�ini g�ncelle
        float newWidthInWorld = initialHealthBarWidthInWorld * healthPercent;
        healthBarFrontInWorld.rectTransform.sizeDelta = new Vector2(newWidthInWorld, healthBarFrontInWorld.rectTransform.sizeDelta.y);
    }

    void Die()
    {
        Debug.Log("Player died!");

        // GameManager'deki GameOver metodunu �a��r
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
