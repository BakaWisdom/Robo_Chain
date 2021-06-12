using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovementController : MonoBehaviour
{
    public MovementDirection direction;
    private Vector3 vectorDirection;
    // Start is called before the first frame update
    public float moveSpeed = 1f;
    public float followSpeed = 1f;

    public Transform movePoint;
    public LayerMask whatStopsMovement;

    private bool isMoving = false;

    private bool shouldMove = false;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        if (direction == MovementDirection.Up)
        {
            vectorDirection = new Vector3(0f, 1f);
        } 
        else if (direction == MovementDirection.Down)
        {
            vectorDirection = new Vector3(0f, -1f);
        }
        else if (direction == MovementDirection.Right)
        {
            vectorDirection = new Vector3(1f, 0f);
        }
        else
        {
            vectorDirection = new Vector3(-1f, 0f);
        }
    }

    public void ActivateMovement()
    {
        shouldMove = true;
    }

    public void DeactivateMovement()
    {
        shouldMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f && !isMoving)
            {
                isMoving = true;
                if (!Physics2D.OverlapCircle(movePoint.position + vectorDirection, .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(vectorDirection.x, vectorDirection.y, 0f);
                }
            }
        }
    }
}

public enum MovementDirection
{
    Up,
    Down,
    Right,
    Left
}
