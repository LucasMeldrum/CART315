using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;  // Assign your bullet prefab here
    public Transform firePoint;      // Empty object where bullets spawn
    public float bulletSpeed = 20f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}