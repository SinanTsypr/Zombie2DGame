using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;  // Merminin ya�am s�resi
    public int damage = 20; // Merminin verece�i hasar miktar�

    void Start()
    {
        // Merminin lifeTime s�resi sonunda yok olmas�n� sa�lar
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �arpan nesnenin "Enemy" tag'ine sahip olup olmad���n� kontrol eder
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
