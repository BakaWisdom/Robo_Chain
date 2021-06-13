using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    public GameEvent ActivateLevel;
    public GameEvent StopLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var robots = GameObject.FindGameObjectsWithTag("Robot");
            var tethers = GameObject.FindGameObjectsWithTag("Tether");
            foreach (var robot in robots)
            {
                robot.GetComponent<TetherRopeController>().ResetTethers();
            }
            foreach (var line in tethers)
            {
                Destroy(line);
            }
        }
    }

    public void StartLevel()
    {
        ActivateLevel.Raise();
    }

    public void FreezeLevel()
    {
        StopLevel.Raise();
    }
}
