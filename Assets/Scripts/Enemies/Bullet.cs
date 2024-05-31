using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;  // Merminin ya�am s�resi

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
            // Konsolda vurulan d��man hakk�nda bilgi verir
            Debug.Log("Bullet hit: " + collision.gameObject.name);
            // �arpan d��man nesnesini yok eder
            Destroy(collision.gameObject);
            // Mermiyi yok eder
            Destroy(gameObject);
        }
    }
}
