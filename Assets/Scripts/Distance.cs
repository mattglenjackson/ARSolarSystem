using UnityEngine;
using TMPro;

public class DisplayFixedDistance : MonoBehaviour
{
    public TextMeshProUGUI DistanceText; // UI text to display distance

    void Start()
    {
        // Set a fixed distance value to display
        float fixedDistance = 0.5f; // You can set any value you want

        if (DistanceText != null)
        {
            DistanceText.text = $"Fixed Distance: {fixedDistance} AU"; // Display fixed distance
            DistanceText.gameObject.SetActive(true); // Ensure the text is visible
        }
    }
}
