using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;  // Merminin yaþam süresi

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
            // Konsolda vurulan düþman hakkýnda bilgi verir
            Debug.Log("Bullet hit: " + collision.gameObject.name);
            // Çarpan düþman nesnesini yok eder
            Destroy(collision.gameObject);
            // Mermiyi yok eder
            Destroy(gameObject);
        }
    }
}
