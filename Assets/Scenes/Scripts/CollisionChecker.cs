using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    private BoxCollider2D attackCollider;
    private CapsuleCollider2D moveCollider;

    private void Awake()
    {

        attackCollider = GetComponent<BoxCollider2D>();
        moveCollider = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Objects" && collision.otherCollider.GetInstanceID() == attackCollider.GetInstanceID())
        {
            attackCollider.attachedRigidbody.isKinematic = true;
            Destroy(collision.gameObject);
        } else
        {
            if (collision.gameObject.tag != "Objects")
            Physics2D.IgnoreCollision(attackCollider, collision.collider);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        attackCollider.attachedRigidbody.isKinematic = false;
    }
}
