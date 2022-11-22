using UnityEngine;

public class CollisionChecker : MonoBehaviour
{

    private BoxCollider2D attackCollider;

    private void Awake()
    {

        attackCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Objects" && collision.otherCollider.GetInstanceID() == attackCollider.GetInstanceID())
        {
            attackCollider.attachedRigidbody.isKinematic = true;
            collision.gameObject.SendMessage("OnSendDestroy");
            attackCollider.attachedRigidbody.isKinematic = false;
        } else
        {
            if (collision.gameObject.tag != "Objects")
            Physics2D.IgnoreCollision(attackCollider, collision.collider);
        }
    }
}
