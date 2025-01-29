using System.Collections;
using UnityEngine;

public class Dropper : MonoBehaviour {
    public GameObject circle; // Prefab to spawn
    private bool isDropping = true; // Flag to control the coroutine
    public Color[] colors = new Color[] {
    Color.red,      // Red
    Color.green,    // Green
    Color.blue,     // Blue
    Color.yellow,   // Yellow
    Color.magenta,  // Magenta
    Color.black,    // Black
};


    void Start() {
        StartCoroutine(Drop());
    }

    private IEnumerator Drop() {
        while (isDropping) {
            Debug.Log("Drop");
            float rX = Random.Range(-8f, 8f);
            Vector3 loc = new Vector3(rX, 6, 0);
            if (circle != null) { 
                Instantiate(circle, loc, transform.rotation);
				// Change the color of the spawned circle
                ChangeCircleColor(circle);

            }

            float next = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(next);
        }
    }
    public void StopDropping() {
        isDropping = false; // Stop the coroutine loop
    }

    private void ChangeCircleColor(GameObject circle) {
        // Get the SpriteRenderer of the circle
        SpriteRenderer sr = circle.GetComponent<SpriteRenderer>();

        if (sr != null && colors.Length > 0) {
            // Pick a random color from the array
            Color randomColor = colors[Random.Range(0, colors.Length)];
            sr.color = randomColor;
        }
    }
}