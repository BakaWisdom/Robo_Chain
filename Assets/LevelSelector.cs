using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void PlayLevel()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;

        int level = int.Parse(name[5].ToString());

        SceneManager.LoadScene(level);
    }

}
