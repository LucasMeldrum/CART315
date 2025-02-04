using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ballScript : MonoBehaviour
{
    public float ballSpeed = 20f;
    private int[] directions = {-1,1};
    private int hDir, yDir;

    public int score1, score2;
    public AudioSource ballSound;
    
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseSpeed(float speedMultiplier)
    {
        ballSpeed *= speedMultiplier;
        Debug.Log("IncreaseSpeed by " + speedMultiplier);
        rb.AddForce(transform.right * ballSpeed *hDir);
        rb.AddForce(transform.up * ballSpeed *yDir);
    }   
    private IEnumerator Launch()
    {
        // Choose Random X dir
        hDir = directions[Random.Range(0, directions.Length)];
        // Choose Random Y dir
        yDir = directions[Random.Range(0, directions.Length)];
        // Wait for X seconds
        yield return new WaitForSeconds(1.5f);
        
        // Apply force
        
        // Horizontal
        rb.AddForce(transform.right * ballSpeed *hDir);
        //Vertical
        rb.AddForce(transform.up * ballSpeed *yDir);
    }
    
    void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        // Reset to 0/0
        this.transform.localPosition = new Vector3(0, 0, 0);
        //Launch
        StartCoroutine(Launch());
    }

    private void OnCollisionEnter2D(Collision2D wall)
    {
        if (wall.gameObject.name == "leftWall")
        {
            // Give points to Player 2
            score2++;
            Reset();
        }
        else if (wall.gameObject.name == "rightWall")
        {
            // Give points to Player 1
            score1++;
            Reset();
        }

        else if (wall.gameObject.name == "topWall" ||
            wall.gameObject.name == "bottomWall")
        {
            ballSound.pitch = 0.5f;
            ballSound.Play();
        }
        else
        {   
            ballSound.pitch = 1f;
            ballSound.Play();
        }
    }
}
