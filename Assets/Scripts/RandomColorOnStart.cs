using UnityEngine;

public class RandomColorOnStart : MonoBehaviour
{
    private void Start()
    {
        // Get a reference to the object's renderer
        Renderer rend = GetComponent<Renderer>();

        // Generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Set the object's color to the random color
        rend.material.color = randomColor;
    }
}
