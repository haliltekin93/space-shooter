using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] Image healthFill;

    [SerializeField] int maxHealth = 10;
    int currentHealth;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;

         HealthBarUpdate();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        HealthBarUpdate();

        if(currentHealth <= 0)
        {
            UIManager.instance.gameOverPanelOpen();
            SoundManager.instance.PlayerExplosionSound();
            gameObject.SetActive(false);
        }
    }

    void HealthBarUpdate()
    {
        float healthPercent = (float)currentHealth / maxHealth;
        healthFill.fillAmount = healthPercent;
    }


}
