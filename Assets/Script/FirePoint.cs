using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;     // arrastra aquí el prefab de la bala
    public Transform firePoint;         // arrastra aquí el FirePoint
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // click izquierdo o Ctrl
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // instanciamos la bala
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // le damos velocidad hacia adelante (eje X del FirePoint)
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }
}