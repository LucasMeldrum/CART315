using UnityEngine;

public class Platform : MonoBehaviour
{
    public float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            Destroy(other.gameObject);
            score -= 1;
        }
    }
}
