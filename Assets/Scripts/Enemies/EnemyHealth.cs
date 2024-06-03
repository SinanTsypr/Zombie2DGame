using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Düþmanýn maksimum saðlýðý
    public int currentHealth;  // Düþmanýn mevcut saðlýðý
    public Image healthBarFront;  // Düþmanýn üzerindeki saðlýk barý
    private float initialHealthBarWidth;  // Saðlýk barýnýn baþlangýç geniþliði
    public RectTransform healthBarCanvas;  // Saðlýk barýnýn bulunduðu canvas
    private Vector3 initialHealthBarPosition;  // Saðlýk barýnýn baþlangýç pozisyonu
    private GameManager gameManager;  // GameManager referansý

    void Start()
    {
        // Baþlangýçta düþmanýn saðlýðýný maksimum deðere ayarla
        currentHealth = maxHealth;

        // Saðlýk barýnýn baþlangýç geniþliðini kaydet
        initialHealthBarWidth = healthBarFront.rectTransform.sizeDelta.x;

        // Saðlýk barýnýn baþlangýç pozisyonunu kaydet
        initialHealthBarPosition = healthBarCanvas.localPosition;

        // Saðlýk barýný güncelle
        UpdateHealthBar();

        // GameManager referansýný bul
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Saðlýk barýnýn pozisyonunu sabitle
        healthBarCanvas.localPosition = initialHealthBarPosition;
        healthBarCanvas.localRotation = Quaternion.identity;
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
        float healthPercent = (currentHealth / (float)maxHealth);
        float newWidth = initialHealthBarWidth * healthPercent;
        healthBarFront.rectTransform.sizeDelta = new Vector2(newWidth, healthBarFront.rectTransform.sizeDelta.y);
    }

    void Die()
    {
        // GameManager'deki AddScore metodunu çaðýr
        if (gameManager != null)
        {
            gameManager.AddScore(1);  // 1 puan ekle
        }
        else
        {
            Debug.LogError("GameManager is not assigned in EnemyHealth script.");
        }

        // Düþmaný yok et
        Destroy(gameObject);
    }
}
