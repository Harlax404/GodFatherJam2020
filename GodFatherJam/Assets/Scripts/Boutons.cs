using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boutons : MonoBehaviour
{
    public string SceneToLoad;

    public void LoadDaScene(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
