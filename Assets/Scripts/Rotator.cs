using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float speed = 10f;

    // Axes to rotate around
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ = true;

    // Update is called once per frame
    void Update()
    {
        // Calculate rotation based on speed and delta time
        float rotationAmount = speed * Time.deltaTime;

        // Create rotation vector based on selected axes
        Vector3 rotationVector = new Vector3(
            rotateX ? rotationAmount : 0f,
            rotateY ? rotationAmount : 0f,
            rotateZ ? rotationAmount : 0f);

        // Apply rotation to game object
        transform.Rotate(rotationVector);
    }
}