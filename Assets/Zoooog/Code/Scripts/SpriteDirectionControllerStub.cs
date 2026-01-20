using UnityEngine;

public class SpriteDirectionControllerStub : MonoBehaviour
{
    [SerializeField] float backAngle = 36f;
    [SerializeField] float backLAngle = 72f;
    [SerializeField] float sideAngle = 108f;
    [SerializeField] float frontLAngle = 144f;
    [SerializeField] Transform mainTransform;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Sprites")]
    [SerializeField] Sprite front;
    [SerializeField] Sprite frontL;
    [SerializeField] Sprite sideL;
    [SerializeField] Sprite backL;
    [SerializeField] Sprite back;


    private void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        Debug.DrawRay(Camera.main.transform.position, camForwardVector * 5f, Color.magenta);
        Debug.DrawRay(mainTransform.position, mainTransform.forward * 5f, Color.red);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        float angle = Mathf.Abs(signedAngle);


        if (angle < backAngle)
        {
            // Back animation
            spriteRenderer.sprite = back;
        }
        else if (angle < backLAngle)
        {
            // Side animation, in this case the right animation
            spriteRenderer.sprite = backL;

            // This changes the side animation based on what side 
            // the camera is viewing the slime from
            if (signedAngle < 0f)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (angle < sideAngle)
        {
            // Side animation, in this case the right animation
            spriteRenderer.sprite = sideL;

            // This changes the side animation based on what side 
            // the camera is viewing the slime from
            if (signedAngle < 0f)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (angle < frontLAngle)
        {
            // Side animation, in this case the right animation
            spriteRenderer.sprite = frontL;

            // This changes the side animation based on what side 
            // the camera is viewing the slime from
            if (signedAngle < 0f)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            //Front animation
            spriteRenderer.sprite = front;
        }
    }
}
