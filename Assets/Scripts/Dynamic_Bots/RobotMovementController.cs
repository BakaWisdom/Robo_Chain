using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovementController : MonoBehaviour
{
    public MovementDirection directionX;
    public MovementDirection directionY;
    public float distanceX = 1f;
    public float distanceY = 1f;
    public Vector3 initialDirection;
    public Vector3 vectorDirection;
    // Start is called before the first frame update
    public float moveSpeed = 1f;
    public float followSpeed = 1f;

    public Transform movePoint;
    public LayerMask whatStopsMovement;

    public TetherRopeController tetherController;

    private bool isMoving = false;

    private bool shouldMove = false;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        initialDirection = new Vector3();
        if (directionY == MovementDirection.Up)
        {
            initialDirection += new Vector3(0f, distanceY);
        } 
        if (directionY == MovementDirection.Down)
        {
            initialDirection += new Vector3(0f, -distanceY);
        }
        if (directionX == MovementDirection.Right)
        {
            initialDirection += new Vector3(distanceX, 0f);
        }
        if (directionX == MovementDirection.Left)
        {
            initialDirection += new Vector3(-distanceX, 0f);
        }
        vectorDirection = initialDirection;
    }

    public void UpdateVector()
    {
        foreach(RobotMovementController roboMovement in tetherController.tetheredRobots)
        {
            vectorDirection += roboMovement.initialDirection;
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
