using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float Speed = 13f;
    [SerializeField] GameObject effect;

    private void Update()
    {
        transform.Translate(Vector3.up*Speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            SoundManager.instance.MeteorExplosionSound();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
