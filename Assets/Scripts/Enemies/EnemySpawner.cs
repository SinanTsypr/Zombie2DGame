using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // D��man prefab'�
    public float spawnRate = 2f;  // D��man do�urma oran� (saniye cinsinden)
    public float spawnRadius = 5f;  // D��manlar�n oyuncu etraf�nda do�aca�� alan�n yar��ap�
    public float minSpawnDistance = 1f;  // D��manlar�n oyuncuya do�aca�� minimum mesafe
    public int maxEnemies = 10;  // Maksimum d��man say�s�

    private float nextSpawnTime;  // Bir sonraki do�um zaman�
    private Transform player;  // Oyuncunun konumuna referans

    void Start()
    {
        // �lk d��man do�urma zaman�n� belirler
        nextSpawnTime = Time.time + spawnRate;
        // Oyuncu nesnesini bulur ve referans al�r
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Mevcut d��man say�s�n� kontrol eder
        int currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // E�er mevcut d��man say�s� maksimumu ge�tiyse yeni d��man do�urmaz
        if (currentEnemyCount >= maxEnemies) return;

        // Zaman� kontrol eder ve bir sonraki d��man do�urma zaman� gelip gelmedi�ini kontrol eder
        if (Time.time >= nextSpawnTime)
        {
            // Oyuncunun etraf�nda rastgele bir pozisyon hesaplar
            Vector2 spawnPosition;
            do
            {
                spawnPosition = player.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            } while (Vector2.Distance(spawnPosition, player.position) < minSpawnDistance);

            // Yeni bir d��man instantiate eder
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            // Bir sonraki do�um zaman�n� ayarlar
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}