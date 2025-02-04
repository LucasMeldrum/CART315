using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    private float yPos;
    public float paddleSpeed = .05f;
    private Vector3 originalScale = new (1f,1f,1f); // Create object of original scale (store it)

    public KeyCode upKey, downKey;
    public float topWall, bottomWall;

    public ballScript ball;
    // Get the SpriteRenderer of the paddle
    private SpriteRenderer spriteRenderer; // Store SpriteRenderer
    private Color originalColor; // Store original color
    

    // Start is called before the first frame update
    void Start()
    {
            spriteRenderer = GetComponent<SpriteRenderer>(); // Initialize SpriteRenderer
            originalColor = spriteRenderer.color; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(downKey) && yPos > bottomWall)
        {
            yPos -= paddleSpeed;
        }

        if (Input.GetKey(upKey) && yPos < topWall)
        {
            yPos += paddleSpeed;
        }

        transform.localPosition =
            new Vector3(transform.position.x, yPos, 0);
    }

    private void OnTriggerEnter2D(Collider2D powerUp)
    {
        Debug.Log("Collided with: " + powerUp.gameObject.name);

        if (powerUp.gameObject.CompareTag("bigPaddle"))
        {
            Debug.Log("bigPaddle");
            StartCoroutine(TemporaryBigPaddle());
            Destroy(powerUp.gameObject); // Destroy powerup
        }
        else if (powerUp.gameObject.CompareTag("Freeze"))
        {
            Debug.Log("Freeze");
            StartCoroutine(TemporaryFreeze());
            Destroy(powerUp.gameObject); // Destroy powerup
        }
        else if (powerUp.gameObject.CompareTag("fastBall"))
        {
            Debug.Log("fastBall");
            StartCoroutine(TemporaryFastBall());
            Destroy(powerUp.gameObject); // Destroy powerup
        }
    }

    private IEnumerator TemporaryBigPaddle()
    {
        Vector3 newScale = transform.localScale; // Create object of new scale
        newScale.y += 1f; // Increase paddle height
        //newScale.x += 1f;  Increase paddle length
        transform.localScale = newScale; // Apply new scale
        
        spriteRenderer.color = Color.green;

        yield return new WaitForSeconds(10f);
        
        spriteRenderer.color = originalColor;

        transform.localScale = originalScale; // Revert to original scale
    }

    private IEnumerator TemporaryFreeze()
    {
        // Find the opposite paddle
        GameObject opponentPaddle;
        if (gameObject.name == "paddleLeft")
        {
            opponentPaddle = GameObject.Find("paddleRight");
        }
        else
        {
            opponentPaddle = GameObject.Find("paddleLeft");
        }

        PaddleScript opponentScript = opponentPaddle.GetComponent<PaddleScript>();
        opponentScript.paddleSpeed = 0f; // Freeze the paddle
        opponentScript.spriteRenderer.color = Color.cyan;
        Debug.Log(opponentPaddle.name + " is frozen!");

        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        
        opponentScript.spriteRenderer.color = originalColor;
        opponentScript.paddleSpeed = 0.05f; // Restore speed
        Debug.Log(opponentPaddle.name + " is unfrozen!");
    }

    private IEnumerator TemporaryFastBall()
    {
        ball.IncreaseSpeed(3f); // Method in ballScript speed up ball 

        spriteRenderer.color = Color.red;
        
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        
        spriteRenderer.color = originalColor;
        ball.IncreaseSpeed(1 / 3f); // Method in ballScript reduce speed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
    }
    
}


