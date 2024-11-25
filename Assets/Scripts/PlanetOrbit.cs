using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [SerializeField] private Transform sun; // Reference to the Sun's position
    [SerializeField] private float orbitSpeed = 10f; // Speed of the orbit (degrees per second)

    void Update()
    {
        // Rotate the planet around the Sun
        if (sun != null)
        {
            transform.RotateAround(sun.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}
