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
        
    }

    public void StartLevel()
    {
        Debug.Log("HELLO");
        ActivateLevel.Raise();
    }

    public void FreezeLevel()
    {
        StopLevel.Raise();
    }
}
