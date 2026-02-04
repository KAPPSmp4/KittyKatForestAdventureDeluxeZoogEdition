using UnityEngine;

public class AudioListenerRotation : MonoBehaviour
{
    [Tooltip("Camera to take rotation from")]
    public GameObject Camera;

    private void Update()
    {
        transform.rotation = Camera.transform.rotation;
    }
}
