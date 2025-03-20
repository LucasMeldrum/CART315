using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float range = 3f;
    public float fireRate = 0.5f;
    public int damage = 10;
    public int stackHeight = 1; // Track which level of the stack the tower is

    private float fireCooldown = 0f;

    void Update()
    {
        if (stackHeight < 5) return; // Only the 5th tower can shoot

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
        projectileScript.damage = damage;
    }

    public void UpgradeTower()
    {
        stackHeight++; // Increase stack height on upgrade
        fireRate *= 0.9f;
        damage += 5;
        range += 0.5f;
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        Debug.Log("Tower Upgraded! Level: " + stackHeight);
    }
}