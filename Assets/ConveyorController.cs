using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    public MovementDirection direction = MovementDirection.Down;
    public float pushAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        float turn;

        switch (direction)
        {
            case MovementDirection.Up:
                turn = 180;
                break;
            case MovementDirection.Right:
                turn = 90;
                break;
            case MovementDirection.Left:
                turn = -90;
                break;
            case MovementDirection.Down:
            default:
                turn = 0;
                break;
        }

        gameObject.transform.Rotate(new Vector3(0, 0, turn));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum MovementDirection
    {
        Up,
        Down,
        Right,
        Left
    }
}
