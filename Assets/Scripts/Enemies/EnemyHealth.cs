using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Düþmanýn maksimum saðlýðý
    public int currentHealth;  // Düþmanýn mevcut saðlýðý
    public Image healthBarFront;  // Yeþil saðlýk barý Image componenti

    void Start()
    {
        // Baþlangýçta düþmanýn saðlýðýný maksimum deðere ayarla
        currentHealth = maxHealth;
        // Saðlýk barýný güncelle
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        // Alýnan hasarý mevcut saðlýktan düþ
        currentHealth -= amount;
        // Saðlýk barýný güncelle
        UpdateHealthBar();

        // Saðlýk sýfýrýn altýna düþerse, düþmanýn öldüðünü kontrol et
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // Saðlýk barýnýn geniþliðini güncelle
        healthBarFront.rectTransform.sizeDelta = new Vector2((currentHealth / (float)maxHealth) * 100f, healthBarFront.rectTransform.sizeDelta.y);
    }

    void Die()
    {
        // Düþman öldüðünde yapýlacak iþlemler
        Debug.Log("Enemy died!");
        // Düþmaný yok et
        Destroy(gameObject);
    }
}
