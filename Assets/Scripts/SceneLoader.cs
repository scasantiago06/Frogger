using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Variables

    // ...

    #endregion Variables

    #region Unity Functions

    // ...

    #endregion Unity Functions

    #region Class Functions

    public void LoadSameScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    // Load Scene by index
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    // Load Scene by name
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    #endregion Class Functions
}