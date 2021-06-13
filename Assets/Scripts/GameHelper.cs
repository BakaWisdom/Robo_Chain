using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviour
{
    public GameEvent ActivateLevel;
    public GameEvent StopLevel;
    public GameEvent YouWon;
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

    public void CakeCheck()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");

        foreach (GameObject robot in robots)
        {
            RoboWinLossState state = robot.GetComponent("RoboWinLossState") as RoboWinLossState;

            if (!state.inCake)
            {
                return;
            }
        }

        YouWon.Raise();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
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
