using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    public float forceAmount = 10f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy bullet after a few seconds
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
        }
        Destroy(gameObject); // Destroy bullet on impact
    }
}