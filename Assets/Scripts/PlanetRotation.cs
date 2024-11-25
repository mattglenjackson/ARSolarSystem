using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 10, 0); // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the planet around its own axis
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
