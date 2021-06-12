using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure_8_Movement : MonoBehaviour
{
    public float moveSpeed = 1f; //TODO place holder shouldn't be static.
    public float turnRadius = 2; //This is half the straight portions length TODO place holder can be static

    private float timeUntilMoveChange;

    public float turnDelay; //how long bot moves straight.
    public float turnTime; //how long its turning

    private bool isTurning;

    private bool isTurningLeft; //unnecesary but keeping for readability

    private float turnAngle;



    // Start is called before the first frame update
    void Start()
    {
        //TODO set initial facing angle to 45 deg or pi/2 rad

        //below code may not form perfect loop if timing is off
        //will be close enough for tether calculations though
        turnDelay = 2 * turnRadius / moveSpeed;
        turnTime = (3 * Mathf.PI * turnRadius) / (2 * moveSpeed);

        //below is place holder for math
        turnAngle = 270 / turnTime;

        if (isTurningLeft)
        {
            turnAngle = -turnAngle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
