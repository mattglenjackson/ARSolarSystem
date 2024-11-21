using UnityEngine;

public class ScalePlanetsGroup : MonoBehaviour
{
    public float scaleSpeed = 0.005f;
    public float minScale = 0.1f;
    public float maxScale = 5.0f;

    private Vector3 initialScale;

    // Array of text objects above the planets
    public GameObject[] planetTexts;

    // Reference to the AR/Scene Camera
    public Camera mainCamera;

    void Start()
    {
        initialScale = transform.localScale;

        // Ensure a camera is assigned
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

                float prevDistance = Vector2.Distance(touch0PrevPos, touch1PrevPos);
                float currentDistance = Vector2.Distance(touch0.position, touch1.position);

                float scaleFactor = (currentDistance - prevDistance) * scaleSpeed;

                // Calculate the new scale for the planets
                Vector3 newScale = transform.localScale + Vector3.one * scaleFactor;
                newScale = Vector3.Max(initialScale * minScale, newScale);
                newScale = Vector3.Min(initialScale * maxScale, newScale);

                // Apply scaling to the planets group
                transform.localScale = newScale;
            }
        }

        // Adjust text size dynamically based on camera distance
        AdjustTextSize();
    }

    void AdjustTextSize()
    {
        foreach (GameObject textObj in planetTexts)
        {
            if (textObj != null && mainCamera != null)
            {
                // Calculate the distance between the camera and the planet's text
                float distanceToCamera = Vector3.Distance(mainCamera.transform.position, textObj.transform.position);

                // Set a proportional scale based on distance (you can tweak the multiplier)
                float textScale = distanceToCamera * 0.01f;

                // Apply the scale while ensuring it stays within reasonable bounds
                textObj.transform.localScale = Vector3.one * Mathf.Clamp(textScale, 0.1f, 0.5f);
            }
        }
    }
}
