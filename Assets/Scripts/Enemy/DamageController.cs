using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int damageCount = 2;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(damageCount);
            Destroy(gameObject);
        }
    }
}
