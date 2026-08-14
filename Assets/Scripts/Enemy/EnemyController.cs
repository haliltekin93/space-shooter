using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] targets; // Enemy'nin hareket edeceği hedef noktaları
    public float speedMove = 5f; // Enemy'nin hareket hızı
    public int damageCount = 3; // Enemy'nin Player'a çarpması durumunda Player'ın alacağı hasar miktarı

    int currentTargetIndex = 0; // Enemy'nin hedefleri arasında geçiş yapmasını sağlayan değişken

    private void Update() // Update fonksiyonu her frame çalışır
    {
        if(targets.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, targets[currentTargetIndex].position, speedMove * Time.deltaTime);
    
        if(Vector3.Distance(transform.position, targets[currentTargetIndex].position) < 0.1f)
        {
            currentTargetIndex++;

            if(currentTargetIndex >= targets.Length)
            {
                currentTargetIndex = 0;
                transform.position = targets[currentTargetIndex].position;
            }
        }
    
    }

    private void OnCollisionEnter2D(Collision2D other) // Çarpışma olduğunda çalışacak fonksiyon
    {
        if(other.gameObject.CompareTag("PlayerBullet")) // PlayerBullet ile Enemy çarpıştığında
        {
            GameManager.instance.DestroyEnemy(this.gameObject); // Enemy nesnesi GameManager'dan yok ediliyor
            SoundManager.instance.EnemyExplosionSound(); // Enemy patlama sesi çalınıyor
            Destroy(other.gameObject); // PlayerBullet nesnesi yok ediliyor
            Destroy(this.gameObject); // Enemy nesnesi yok ediliyor
        }

        if(other.gameObject.CompareTag("Player")) // Player ile Enemy çarpıştığında
        {
            PlayerHealth.instance.TakeDamage(damageCount); // Player nesnesinin hasar aldığında Canı azalıyor
            Destroy(this.gameObject); // Enemy nesnesi yok ediliyor
        }
    }

}
