using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float range = 3f;
    public float fireRate = 2f;
    public int damage = 10;

    private float fireCooldown = 0f;
    private int upgradeLevel = 1; // Starts at level 1

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        Enemy target = FindTarget();

        if (target != null && fireCooldown <= 0f)
        {
            Shoot(target);
            fireCooldown = fireRate; 
        }
    }

    Enemy FindTarget()
    {
        Enemy closestEnemy = null;
        float closestDistance = range;

        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        return closestEnemy;
    }

    void Shoot(Enemy target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetTarget(target.transform);
        projectileScript.damage = damage; // Apply tower's damage
    }

    public void UpgradeTower()
    {
        upgradeLevel++;
        fireRate *= 0.9f; // Faster shooting (10% decrease)
        damage += 5; // Increase damage
        range += 0.5f; // Slightly increase range
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f); // Make tower slightly bigger
        
        Debug.Log("Tower Upgraded! Level: " + upgradeLevel);
    }
}