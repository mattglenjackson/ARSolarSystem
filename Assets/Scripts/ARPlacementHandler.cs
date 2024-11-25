using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementHandler : MonoBehaviour
{
    [SerializeField] private GameObject placedPrefab; // Prefab to place
    private GameObject spawnedObject; // Reference to the placed object
    private ARRaycastManager raycastManager; // Handles raycasting
    private ARPlaneManager planeManager; // Manages detected planes
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>(); // Stores raycast results

    void Start()
    {
        // Get ARRaycastManager and ARPlaneManager from the XR Origin
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();

        if (raycastManager == null)
        {
            Debug.LogError("ARRaycastManager is missing. Ensure it is added to the XR Origin (AR RIG).");
        }

        if (planeManager == null)
        {
            Debug.LogError("ARPlaneManager is missing. Ensure it is added to the XR Origin (AR RIG).");
        }
    }

    void Update()
    {
        // Check for a single touch and ensure no object is placed yet
        if (Input.touchCount > 0 && spawnedObject == null)
        {
            Touch touch = Input.GetTouch(0);

            // Only handle the touch when it begins
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log($"Touch detected at screen position: {touch.position}");
                PlaceObject(touch.position);
            }
        }
    }

    private void PlaceObject(Vector2 touchPosition)
    {
        Debug.Log($"Attempting raycast at screen position: {touchPosition}");

        // Validate touch position is within screen bounds
        if (touchPosition.x < 0 || touchPosition.x > Screen.width ||
            touchPosition.y < 0 || touchPosition.y > Screen.height)
        {
            Debug.LogError($"Touch position {touchPosition} is out of screen bounds.");
            return;
        }

        // Perform raycast to detect a plane (using broader raycast types)
        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon | TrackableType.PlaneWithinBounds | TrackableType.PlaneEstimated))
        {
            Pose hitPose = hits[0].pose;
            Debug.Log($"Raycast hit detected at world position: {hitPose.position}");

            // Instantiate the prefab at the raycast hit point
            spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            Debug.Log($"Object placed successfully at: {hitPose.position}");

            // Disable and hide planes after placement
            DisableAndHidePlanes();
        }
        else
        {
            Debug.Log($"Raycast failed at screen position: {touchPosition}");
        }
    }

    private void DisableAndHidePlanes()
    {
        if (planeManager != null)
        {
            planeManager.enabled = false; // Disable plane detection
            Debug.Log("Plane detection disabled.");

            foreach (var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false); // Hide existing planes
                Debug.Log($"Plane {plane.trackableId} hidden.");
            }
        }
    }
}
