using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Oyuncunun maksimum sa�l���
    public int currentHealth;  // Oyuncunun mevcut sa�l���
    public Image healthBarFront;  // Ye�il sa�l�k bar� Image componenti

    void Start()
    {
        // Ba�lang��ta oyuncunun sa�l���n� maksimum de�ere ayarla
        currentHealth = maxHealth;
        // Sa�l�k bar�n� g�ncelle
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Sa�l�k bar�n�n geni�li�ini g�ncelle
        healthBarFront.rectTransform.sizeDelta = new Vector2((currentHealth / (float)maxHealth) * 100f, healthBarFront.rectTransform.sizeDelta.y);
    }

    public void TakeDamage(int amount)
    {
        // Al�nan hasar� mevcut sa�l�ktan d��
        currentHealth -= amount;
        // Sa�l�k bar�n� g�ncelle
        UpdateHealthBar();

        // Sa�l�k s�f�r�n alt�na d��erse, oyuncunun �ld���n� kontrol et
        if (currentHealth < 0) {
            Die();
        }
    }

    void Die()
    {
        // Oyuncunun �ld���nde yap�lacak i�lemler (�rne�in, oyunu bitir)
        Debug.Log("Player died!");
        // Oyunu durdur
        Time.timeScale = 0f;
    }
}
