using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Mermi prefab'�
    public float fireRate = 0.5f;  // Ate� etme h�z� (saniye ba��na)
    public float bulletSpeed = 10f;  // Merminin h�z�

    private float nextFireTime;  // Bir sonraki ate� etme zaman�

    void Update()
    {
        // Zaman� kontrol eder ve ate� etme zaman�n�n gelip gelmedi�ini kontrol eder
        if (Time.time > nextFireTime)
        {
            // En yak�n d��mana ate� eder
            ShootAtClosestEnemy();
            // Bir sonraki ate� etme zaman�n� ayarlar
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootAtClosestEnemy()
    {
        // T�m d��manlar� bulur
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // E�er d��man yoksa ��k�� yapar
        if (enemies.Length == 0) return;

        GameObject closestEnemy = null;  // En yak�n d��man i�in de�i�ken
        float closestDistance = Mathf.Infinity;  // En yak�n mesafe i�in de�i�ken

        // T�m d��manlar aras�nda d�ner ve en yak�n� bulur
        foreach (GameObject enemy in enemies)
        {
            // Mevcut d��man ile oyuncu aras�ndaki mesafeyi hesaplar
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            // E�er bu mesafe daha �nce bulunandan k���kse, en yak�n d��man olarak ayarlar
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        // E�er en yak�n d��man bulunduysa
        if (closestEnemy != null)
        {
            // D��mana do�ru olan y�n� hesaplar
            Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
            // Mermi prefab'�n� instantiate eder ve ba�lang�� konumunu belirler
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // Merminin Rigidbody2D bile�enine y�n ve h�z atar
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            // Konsolda ate� edilen d��man hakk�nda bilgi verir
            Debug.Log("Shot fired at: " + closestEnemy.name);
        }
    }
}
