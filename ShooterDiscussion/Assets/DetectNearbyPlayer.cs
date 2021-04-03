using UnityEngine;
using UnityEngine.UI;

public class DetectNearbyPlayer : MonoBehaviour
{
    public Image panelImage = null;

    public float transitionSpeed = 5;

    public float nearbyAlpha;
    public float notNearbyAlpha;

    bool isNearby = false;

    bool transitioning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            transitioning = true;
            isNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            transitioning = true;
            isNearby = false;
        }

    }

    public void SetNearby(bool set)
    {
        isNearby = set;
        transitioning = true;
    }

    void Update()
    {
        if (!transitioning) return;

        Color newColor = panelImage.color;
        if (isNearby)
        {
            newColor.a = Mathf.Lerp(newColor.a, nearbyAlpha, Time.deltaTime * transitionSpeed);
            if (Mathf.Abs(nearbyAlpha - newColor.a) < 0.01f) transitioning = false;
        }
        else
        {
            newColor.a = Mathf.Lerp(newColor.a, notNearbyAlpha, Time.deltaTime * transitionSpeed);
            if (Mathf.Abs(notNearbyAlpha - newColor.a) < 0.01f) transitioning = false;
        }
        panelImage.color = newColor;
    }
}
