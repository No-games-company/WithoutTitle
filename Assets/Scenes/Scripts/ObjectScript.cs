using UnityEngine;

public class ObjectScript : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();
    }

    public void OnSendDestroy()
    {

        GetComponent<BoxCollider2D>().enabled = false;
        animator.Play("BarrelDeath");
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
