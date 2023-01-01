using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void Jouer(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quitter()
    {
        Application.Quit();
    }
}
