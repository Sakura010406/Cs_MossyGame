using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        LoadByDeserialization();
    }
    private void LoadByDeserialization()
    {
        GameManager.isLoad = true;
        SceneManager.LoadScene("Scene1");
    }
}
