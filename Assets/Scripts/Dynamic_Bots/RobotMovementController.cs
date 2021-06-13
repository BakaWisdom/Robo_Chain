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
    private bool isMovingXFirst = false;
    private bool shouldMoveSecondCoordinate = false;

    private bool shouldMove = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = GameObject.Find("MovePoints").transform;
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
        vectorDirection = new Vector3(initialDirection.x, initialDirection.y);
    }

    public void UpdateVector()
    {
        vectorDirection = new Vector3(initialDirection.x, initialDirection.y);
        foreach (RobotMovementController roboMovement in tetherController.tetheredRobots.Values)
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

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (!isMoving)
                {
                    isMoving = true;
                    shouldMoveSecondCoordinate = true;
                    if (vectorDirection.x - vectorDirection.y >= 0)
                    {
                        isMovingXFirst = true;
                    }

                    if (isMovingXFirst)
                    {
                        if (!Physics2D.OverlapCircle(movePoint.position + (new Vector3(vectorDirection.x, 0)), .2f, whatStopsMovement))
                        {
                            movePoint.position += new Vector3(vectorDirection.x, 0f, 0f);
                            anim.SetFloat("AnimMoveX", vectorDirection.x);
                            anim.SetFloat("AnimMoveY", 0f);
                        }
                    }
                    else
                    {
                        if (!Physics2D.OverlapCircle(movePoint.position + (new Vector3(0, vectorDirection.y)), .2f, whatStopsMovement))
                        {
                            movePoint.position += new Vector3(0f, vectorDirection.y, 0f);
                            anim.SetFloat("AnimMoveX", 0f);
                            anim.SetFloat("AnimMoveY", vectorDirection.y);
                        }
                    }
                }
                else
                {
                    if(shouldMoveSecondCoordinate)
                    {
                        shouldMoveSecondCoordinate = false;
                        isMoving = false;
                        if (isMovingXFirst)
                        {
                            if (!Physics2D.OverlapCircle(movePoint.position + (new Vector3(0, vectorDirection.y)), .2f, whatStopsMovement))
                            {
                                movePoint.position += new Vector3(0f, vectorDirection.y, 0f);
                                anim.SetFloat("AnimMoveX", 0f);
                                anim.SetFloat("AnimMoveY", vectorDirection.y);
                            }
                        }
                        else
                        {
                            if (!Physics2D.OverlapCircle(movePoint.position + (new Vector3(vectorDirection.x, 0)), .2f, whatStopsMovement))
                            {
                                movePoint.position += new Vector3(vectorDirection.x, 0f, 0f);
                                anim.SetFloat("AnimMoveX", vectorDirection.x);
                                anim.SetFloat("AnimMoveY", 0f);
                            }
                        }
                    }
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
