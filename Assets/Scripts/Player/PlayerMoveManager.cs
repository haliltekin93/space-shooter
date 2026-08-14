using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    [Header("Elementler")]
    [SerializeField] GameObject bulletPrefab; // Mermi Prefabı
    [SerializeField] Transform bulletSpawn; // Mermi Spawn Noktası

    [Header("Ayarlar")]
    [SerializeField] float minX = -4f; // Minimum X koordinatı
    [SerializeField] float maxX = 4f; // Maximum X koordinatı
    [SerializeField] float minY = 2f; // Minimum Y koordinatı
    [SerializeField] float maxY = -7f; // Maximum Y koordinatı
    [SerializeField] float moveSpeed = 5f; // Hareket Hızı

    private void Update()
    {
        MoveFunction(); // Hareket Fonksiyonu çağrısı

        if(Input.GetMouseButtonDown(0)) // Eğer sol fare tuşuna basılırsa
        {
            FireBullet(); // Mermi Atma Fonksiyonu çağrısı
        }
    }

    private void MoveFunction() // Hareket Fonksiyonu
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h, v, 0);
        moveDirection = moveDirection.normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        Vector3 clampPos = transform.position;
        clampPos.x = Mathf.Clamp(clampPos.x, minX, maxX);
        clampPos.y = Mathf.Clamp(clampPos.y, maxY, minY);

        transform.position = clampPos;
    }

    void FireBullet() // Mermi Atma Fonksiyonu
    {
        Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
    }
}
