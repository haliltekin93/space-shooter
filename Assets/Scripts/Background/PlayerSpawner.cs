using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] float minX = -3f; // Minimum X koordinatı
    [SerializeField] float maxX = 3f;
    [SerializeField] float dinamicY = 12f; // Dinamik Y koordinatı
    [SerializeField] float shoutTime = 5f; // Spawn Süresi

    [Header("Elements")]
    [SerializeField] GameObject[] planetPrefabs; // Planet Prefabları

    private void Start()
    {
        StartCoroutine(SpawnPlanet()); // Coroutine başlatma
    }

    IEnumerator SpawnPlanet()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX); // Rastgele X koordinatı
            Vector3 spawnPosition = new Vector3(randomX, dinamicY, 0); // Spawn pozisyonu

            int randomIndex = Random.Range(0, planetPrefabs.Length); // Rastgele bir prefab seçimi
            GameObject planetPrefab = Instantiate(planetPrefabs[randomIndex], spawnPosition, Quaternion.identity); // Prefabı spawn etme
            Destroy(planetPrefab, 40f); // 10 saniye sonra prefabı yok etme
            yield return new WaitForSeconds(shoutTime); // Belirli bir süre bekleme
        }
    }
}
