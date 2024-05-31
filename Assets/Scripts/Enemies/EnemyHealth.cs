using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // D��man�n maksimum sa�l���
    public int currentHealth;  // D��man�n mevcut sa�l���
    public Image healthBarFront;  // Ye�il sa�l�k bar� Image componenti

    void Start()
    {
        // Ba�lang��ta d��man�n sa�l���n� maksimum de�ere ayarla
        currentHealth = maxHealth;
        // Sa�l�k bar�n� g�ncelle
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        // Al�nan hasar� mevcut sa�l�ktan d��
        currentHealth -= amount;
        // Sa�l�k bar�n� g�ncelle
        UpdateHealthBar();

        // Sa�l�k s�f�r�n alt�na d��erse, d��man�n �ld���n� kontrol et
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // Sa�l�k bar�n�n geni�li�ini g�ncelle
        healthBarFront.rectTransform.sizeDelta = new Vector2((currentHealth / (float)maxHealth) * 100f, healthBarFront.rectTransform.sizeDelta.y);
    }

    void Die()
    {
        // D��man �ld���nde yap�lacak i�lemler
        Debug.Log("Enemy died!");
        // D��man� yok et
        Destroy(gameObject);
    }
}
