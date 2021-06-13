using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboWinLossState : MonoBehaviour
{
    public GameEvent lost;
    public GameEvent winCheck;
    private bool hasTheDead = false;
    internal bool inCake = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Celebrate()
    {
        //TODO activate dance animation
    }

    public void Lose()
    {
        if (hasTheDead)
        {
            //TODO activate death animation
        }
        else
        {
            //TODO sad animation
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpikePit")
        {
            hasTheDead = true;
            lost.Raise();
        }

        if (collision.tag == "Cake")
        {
            Debug.Log("Collided");
            inCake = true;
            winCheck.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cake")
        {
            inCake = false;
        }
    }
}
