using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridMovement
{
    public static float yMultiplier = 2.5f;

    public static float xMultiplier = 4f;

    public static Vector3 MoveUp(Transform mover)
    {
        Vector3 pos = mover.position;
        pos += Vector3.up * yMultiplier;

        return pos;
    }
    public static Vector3 MoveDown(Transform mover)
    {
        Vector3 pos = mover.position;
        pos += Vector3.down * yMultiplier;

        return pos;
    }
    public static Vector3 MoveRight(Transform mover)
    {
        Vector3 pos = mover.position;
        pos += Vector3.right * xMultiplier;

        return pos;

    }
    public static Vector3 MoveLeft(Transform mover)
    {
        Vector3 pos = mover.position;
        pos += Vector3.left * xMultiplier;
        return pos;
    }
}
