using UnityEngine;

public class ScalePlanetsGroupWithText : MonoBehaviour
{
    public float scaleSpeed = 0.005f; // Sensitivity for pinch scaling
    public float minScale = 0.1f; // Minimum scale factor
    public float maxScale = 5.0f; // Maximum scale factor

    private Vector3 initialScale;

    // Array of text objects associated with the planets
    public GameObject[] planetTexts;

    // Array of planet objects that the text corresponds to
    public GameObject[] planets;

    void Start()
    {
        // Store the initial scale of the planets group
        initialScale = transform.localScale;

        // Ensure the arrays are correctly set up
        if (planetTexts.Length != planets.Length)
        {
            Debug.LogError("The number of planet texts and planets must match!");
        }
    }

    void Update()
    {
        HandlePinchToScale();
        AdjustTextSizeRelativeToPlanets();
    }

    void HandlePinchToScale()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                // Calculate the previous and current distances between the two touches
                Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

                float prevDistance = Vector2.Distance(touch0PrevPos, touch1PrevPos);
                float currentDistance = Vector2.Distance(touch0.position, touch1.position);

                // Determine the scale factor based on the distance difference
                float scaleFactor = (currentDistance - prevDistance) * scaleSpeed;

                // Calculate the new scale for the planets group
                Vector3 newScale = transform.localScale + Vector3.one * scaleFactor;

                // Clamp the scale within defined limits
                newScale = Vector3.Max(initialScale * minScale, newScale);
                newScale = Vector3.Min(initialScale * maxScale, newScale);

                // Apply the new scale to the planets group
                transform.localScale = newScale;
            }
        }
    }

    void AdjustTextSizeRelativeToPlanets()
    {
        // Adjust the scale of each text object relative to its planet
        for (int i = 0; i < planetTexts.Length; i++)
        {
            GameObject textObj = planetTexts[i];
            GameObject planetObj = planets[i];

            if (textObj != null && planetObj != null)
            {
                // Set the text scale proportional to the planet's scale
                textObj.transform.localScale = planetObj.transform.localScale * 0.5f; // Adjust multiplier as needed
            }
        }
    }
}
