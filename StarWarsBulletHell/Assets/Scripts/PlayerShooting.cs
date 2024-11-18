using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Estas variables deben ser p�blicas para que aparezcan en el Inspector
    public GameObject bulletPrefab;   // Prefab de la bala
    public Transform firePoint;       // Punto desde donde se disparan las balas
    public float bulletSpeed = 40f;   // Velocidad de las balas
    public float fireRate = 1f;     // Tiempo entre disparos

    private float nextFire = 0f;      // Controla el tiempo para el pr�ximo disparo

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)  // Usa el bot�n primario de disparo
        {
            //nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;  // Disparar la bala hacia adelante

        // Destruir la bala despu�s de un tiempo para evitar que siga volando indefinidamente
        Destroy(bullet, 5f);
    }
}
