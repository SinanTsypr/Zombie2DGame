using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Mermi prefab'ý
    public float fireRate = 0.5f;  // Ateþ etme hýzý (saniye baþýna)
    public float bulletSpeed = 10f;  // Merminin hýzý

    private float nextFireTime;  // Bir sonraki ateþ etme zamaný

    void Update()
    {
        // Zamaný kontrol eder ve ateþ etme zamanýnýn gelip gelmediðini kontrol eder
        if (Time.time > nextFireTime)
        {
            // En yakýn düþmana ateþ eder
            ShootAtClosestEnemy();
            // Bir sonraki ateþ etme zamanýný ayarlar
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootAtClosestEnemy()
    {
        // Tüm düþmanlarý bulur
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Eðer düþman yoksa çýkýþ yapar
        if (enemies.Length == 0) return;

        GameObject closestEnemy = null;  // En yakýn düþman için deðiþken
        float closestDistance = Mathf.Infinity;  // En yakýn mesafe için deðiþken

        // Tüm düþmanlar arasýnda döner ve en yakýný bulur
        foreach (GameObject enemy in enemies)
        {
            // Mevcut düþman ile oyuncu arasýndaki mesafeyi hesaplar
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            // Eðer bu mesafe daha önce bulunandan küçükse, en yakýn düþman olarak ayarlar
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        // Eðer en yakýn düþman bulunduysa
        if (closestEnemy != null)
        {
            // Düþmana doðru olan yönü hesaplar
            Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
            // Mermi prefab'ýný instantiate eder ve baþlangýç konumunu belirler
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // Merminin Rigidbody2D bileþenine yön ve hýz atar
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            // Konsolda ateþ edilen düþman hakkýnda bilgi verir
            Debug.Log("Shot fired at: " + closestEnemy.name);
        }
    }
}
