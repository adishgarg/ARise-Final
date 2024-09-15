using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class ImageScanner : MonoBehaviour
{
    // Reference to ARTrackedImageManager
    [SerializeField]
    private ARTrackedImageManager trackedImageManager;
    public static string vidname;
    // Event to notify when a new image is scanned
    public static Action<string> OnImageScanned;

    // Store the currently tracked image
    private ARTrackedImage currentTrackedImage;

    private void OnEnable()
    {
        // Subscribe to ARTrackedImageManager's events
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe from events when the object is disabled
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Called when tracked images are added, updated, or removed
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Handle newly tracked images
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            ExportImageName(trackedImage);
        }

        // Handle updated tracked images
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking && currentTrackedImage != trackedImage)
            {
                ExportImageName(trackedImage);
            }
        }

        // Handle removed tracked images (optional)
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            ResetTrackedImage();
        }
    }

    // Method to export the name of the scanned image
    private void ExportImageName(ARTrackedImage trackedImage)
    {
        // Set the current tracked image
        currentTrackedImage = trackedImage;

        // Get the reference image's name
        string imageName = trackedImage.referenceImage.name;

        // Trigger the event or update variable when the image is scanned
        OnImageScanned?.Invoke(imageName);

        // You can also directly print or log the image name
        Debug.Log("Scanned image: " + imageName);

        vidname = imageName;
        Debug.Log(imageName);
    }

    // Reset the currently tracked image (optional)
    private void ResetTrackedImage()
    {
        currentTrackedImage = null;
        Debug.Log("Tracked image lost.");
    }
}
