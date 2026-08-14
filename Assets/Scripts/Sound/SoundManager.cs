using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource mouseClick;
    [SerializeField] AudioSource enemyExplosionClip;
    [SerializeField] AudioSource meteorExplosionClip;
    [SerializeField] AudioSource playerExplosionClip;

    private void Awake()
    {
        instance = this;
    }

    public void MouseClickSound()
    {
        mouseClick.Play();
    }

    public void EnemyExplosionSound()
    {
        enemyExplosionClip.Play();
    }

    public void MeteorExplosionSound()
    {
        meteorExplosionClip.Play();
    }

    public void PlayerExplosionSound()
    {
        playerExplosionClip.Play();
    }
    
}
