using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameeraSizeController : MonoBehaviour
{
    [SerializeField]
    private float pixelsToUnits = 100f;

    public void ChangeCameraSize()
    {
        Camera mainCamera = GetComponent<Camera>();

        float screenHeightInUnits = Screen.height / pixelsToUnits;
        mainCamera.orthographicSize = screenHeightInUnits / 2f;
    }


}
