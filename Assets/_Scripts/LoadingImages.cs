using UnityEngine;
using UnityEngine.UI;

public class LoadingImages : MonoBehaviour
{
    public Image galleryImage; 
    public Sprite[] galleryImages; 
    private int currentImageIndex = 0; 

    private void Start()
    {
        // Start the gallery image changing process
        InvokeRepeating("ChangeGalleryImage", 0f, 5f);
    }

    private void ChangeGalleryImage()
    {
        // Change the gallery image every 5 seconds
        if (galleryImages.Length > 0)
        {
            galleryImage.sprite = galleryImages[currentImageIndex];
            currentImageIndex = (currentImageIndex + 1) % galleryImages.Length;
        }
    }
}
