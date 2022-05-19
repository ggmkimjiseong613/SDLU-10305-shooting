using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesButton : MonoBehaviour
{

    public void ReStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("ReStart");
    }
}
