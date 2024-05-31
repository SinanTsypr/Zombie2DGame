using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Düþman prefab'ý
    public float spawnRate = 2f;  // Düþman doðurma oraný (saniye cinsinden)
    public float spawnRadius = 5f;  // Düþmanlarýn oyuncu etrafýnda doðacaðý alanýn yarýçapý
    public float minSpawnDistance = 1f;  // Düþmanlarýn oyuncuya doðacaðý minimum mesafe
    public int maxEnemies = 10;  // Maksimum düþman sayýsý

    private float nextSpawnTime;  // Bir sonraki doðum zamaný
    private Transform player;  // Oyuncunun konumuna referans

    void Start()
    {
        // Ýlk düþman doðurma zamanýný belirler
        nextSpawnTime = Time.time + spawnRate;
        // Oyuncu nesnesini bulur ve referans alýr
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Mevcut düþman sayýsýný kontrol eder
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Eðer mevcut düþman sayýsý maksimumu geçtiyse yeni düþman doðurmaz
        if (currentEnemyCount >= maxEnemies) return;

        // Zamaný kontrol eder ve bir sonraki düþman doðurma zamaný gelip gelmediðini kontrol eder
        if (Time.time >= nextSpawnTime)
        {
            // Oyuncunun etrafýnda rastgele bir pozisyon hesaplar
            Vector2 spawnPosition;
            do
            {
                spawnPosition = player.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            } while (Vector2.Distance(spawnPosition, player.position) < minSpawnDistance);

            // Yeni bir düþman instantiate eder
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            // Bir sonraki doðum zamanýný ayarlar
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}