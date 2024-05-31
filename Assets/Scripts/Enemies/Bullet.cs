using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;  // Merminin yaþam süresi
    public int damage = 20; // Merminin vereceði hasar miktarý

    void Start()
    {
        // Merminin lifeTime süresi sonunda yok olmasýný saðlar
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpan nesnenin "Enemy" tag'ine sahip olup olmadýðýný kontrol eder
        if (collision.CompareTag("Enemy"))
        {
            // EnemyHealth script'ini al ve hasar ver
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyHealth.TakeDamage(damage);
            }

            // Mermiyi yok eder
            Destroy(gameObject);
        }
    }
}
