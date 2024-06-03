using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;  // D��man�n maksimum sa�l���
    public int currentHealth;  // D��man�n mevcut sa�l���
    public Image healthBarFront;  // D��man�n �zerindeki sa�l�k bar�
    private float initialHealthBarWidth;  // Sa�l�k bar�n�n ba�lang�� geni�li�i
    public RectTransform healthBarCanvas;  // Sa�l�k bar�n�n bulundu�u canvas
    private Vector3 initialHealthBarPosition;  // Sa�l�k bar�n�n ba�lang�� pozisyonu
    private GameManager gameManager;  // GameManager referans�

    void Start()
    {
        // Ba�lang��ta d��man�n sa�l���n� maksimum de�ere ayarla
        currentHealth = maxHealth;

        // Sa�l�k bar�n�n ba�lang�� geni�li�ini kaydet
        initialHealthBarWidth = healthBarFront.rectTransform.sizeDelta.x;

        // Sa�l�k bar�n�n ba�lang�� pozisyonunu kaydet
        initialHealthBarPosition = healthBarCanvas.localPosition;

        // Sa�l�k bar�n� g�ncelle
        UpdateHealthBar();

        // GameManager referans�n� bul
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Sa�l�k bar�n�n pozisyonunu sabitle
        healthBarCanvas.localPosition = initialHealthBarPosition;
        healthBarCanvas.localRotation = Quaternion.identity;
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
        float healthPercent = (currentHealth / (float)maxHealth);
        float newWidth = initialHealthBarWidth * healthPercent;
        healthBarFront.rectTransform.sizeDelta = new Vector2(newWidth, healthBarFront.rectTransform.sizeDelta.y);
    }

    void Die()
    {
        // GameManager'deki AddScore metodunu �a��r
        if (gameManager != null)
        {
            gameManager.AddScore(1);  // 1 puan ekle
        }
        else
        {
            Debug.LogError("GameManager is not assigned in EnemyHealth script.");
        }

        // D��man� yok et
        Destroy(gameObject);
    }
}
