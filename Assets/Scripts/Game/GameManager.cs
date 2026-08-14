using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public List<GameObject> enemies; // Enemy tag'ine sahip tüm nesneleri saklamak için bir liste

    private void Awake()
    {
        instance = this; // Singleton pattern
    }

    private void Start()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy"); // Enemy tag'ine sahip tüm nesneleri bul

        enemies = new List<GameObject>(enemyObjects); // Bulunan nesneleri listeye ekle
    }

    public void DestroyEnemy(GameObject enemy)
    {
        if(enemies.Count>0)
        {
            enemies.Remove(enemy); // Düşmanı listeden kaldır

            if(enemies.Count == 0)
            {
                UIManager.instance.finishPanelOpen();
            }
        }

    }
}
