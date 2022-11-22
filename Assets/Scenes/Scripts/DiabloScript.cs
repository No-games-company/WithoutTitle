using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiabloScript : MonoBehaviour
{

    private const string DIABLO = "Diablo";

    private AIPath path;
    private Animator animator;

    private void Awake()
    {

        path = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        Debug.Log(path.desiredVelocity);

        switch (path.desiredVelocity) {

            case Vector3 vector when vector.y > -0.5 && vector.y < 0.5 && vector.x > 0:
                {

                    animator.Play(DIABLO + "WalkRight");
                    return;
                }

            case Vector3 vector when vector.y > -0.5 && vector.y < 0.5 && vector.x < 0:
                {

                    animator.Play(DIABLO + "WalkLeft");
                    return;
                }

            case Vector3 vector when vector.x > -0.5 && vector.x < 0.5 && vector.y > 0:
                {

                    animator.Play(DIABLO + "WalkUp");
                    return;
                }

            case Vector3 vector when vector.x > -0.5 && vector.x < 0.5 && vector.y < 0:
                {

                    animator.Play(DIABLO + "WalkDown");
                    return;
                }

            case Vector3 vector when vector.x > 0.5 && vector.y > 0.5:
                {

                    animator.Play(DIABLO + "WalkRightUp");
                    return;
                }

            case Vector3 vector when vector.x >= 0.5 && vector.y <= 0.5:
                {

                    animator.Play(DIABLO + "WalkRightDown");
                    return;
                }

            case Vector3 vector when vector.x <= 0.5 && vector.y >= 0.5:
                {

                    animator.Play(DIABLO + "WalkLeftUp");
                    return;
                }

            case Vector3 vector when vector.x <= 0.5 && vector.y <= 0.5:
                {

                    animator.Play(DIABLO + "WalkLeftDown");
                    return;
                }

            case Vector3 vector when vector == Vector3.zero:
                {

                    animator.Play(DIABLO + "Idle");
                    return;
                }
        }
    }
}
