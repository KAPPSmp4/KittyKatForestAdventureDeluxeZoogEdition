using UnityEngine;

public class SpriteDirectionController : MonoBehaviour
{
    [SerializeField] float backAngle = 36f;
    [SerializeField] float backLAngle = 72f;
    [SerializeField] float sideAngle = 108f;
    [SerializeField] float frontLAngle = 144f;
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void LateUpdate()
    {
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0.1f, -1f);

        float angle = Mathf.Abs(signedAngle);
        
        if (angle < backAngle)
        {
            // Back animation
            animationDirection = new Vector2(0.1f, -1f);
        }
        else if (angle < backLAngle)
        {
            // Side animation, in this case the right animation
            animationDirection = new Vector2(1f, -1f);

            // This changes the side animation based on what side 
            // the camera is viewing the slime from
            if (signedAngle < 0f)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (angle < sideAngle)
        {
            // Side animation, in this case the right animation
            animationDirection = new Vector2(1f, 0f);

            // This changes the side animation based on what side 
            // the camera is viewing the slime from
            if (signedAngle < 0f)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (angle < frontLAngle)
        {
            // Side animation, in this case the right animation
            animationDirection = new Vector2(1f, 1f);

            // This changes the side animation based on what side 
            // the camera is viewing the slime from
            if (signedAngle < 0f)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            //Front animation
            animationDirection = new Vector2(0f, 1f);
        }
        

        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY", animationDirection.y);

    }
}
