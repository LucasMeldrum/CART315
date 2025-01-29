using UnityEngine;

public class Collector : MonoBehaviour
{
    public float xLoc, yLoc = 0;
    public float speed = 0.1f;
    public float score;
    public float explosionForce = 500f; // Force of the explosion
    public float explosionRadius = 5f; // Radius of the explosion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xLoc = 0;
        yLoc = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Left
        if (Input.GetKey(KeyCode.A) && xLoc > -12f)
        {
            Debug.Log("Left");
            xLoc -= speed;
        }

        // Move Right
        if (Input.GetKey(KeyCode.D) && xLoc < 12f)
        {
            Debug.Log("Right");
            xLoc += speed;
        }
        
        // Move Up
        if (Input.GetKey(KeyCode.W) && yLoc < 6f)
        {
            Debug.Log("Up");
            yLoc += speed;
        }

        // Move Down
        if (Input.GetKey(KeyCode.S) && yLoc > -6f)
        {
            Debug.Log("Down");
            yLoc -= speed;
        }

        // Trigger Explosion on Space press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            Explode();
        } 
        
        this.transform.position = new Vector3(xLoc, yLoc, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            score += 1;
        }
    }

    private void Explode()
    {
        Debug.Log("Platform exploded");

        // Find all circles in the scene
        GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
        foreach (GameObject circle in circles)
        {
            // Get the Rigidbody2D of the circle
            Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Ensure the Rigidbody is set to Dynamic
                if (rb.bodyType != RigidbodyType2D.Dynamic)
                {
                    rb.bodyType = RigidbodyType2D.Dynamic;
                }

                // Calculate the direction from the platform to the circle
                Vector2 direction = (circle.transform.position - transform.position).normalized;

                // Apply an explosion force to the circle
                rb.AddForce(direction * explosionForce);

                // Optionally, add some randomness to make it look more dynamic
                float randomTorque = UnityEngine.Random.Range(-100f, 100f);  // Use UnityEngine.Random here
                rb.AddTorque(randomTorque);
            }
        }
    }
}
