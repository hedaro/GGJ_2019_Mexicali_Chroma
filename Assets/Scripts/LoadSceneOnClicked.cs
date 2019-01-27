using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnClicked : MonoBehaviour
{
   
    public void loadScene(int scene = 1)
    {
        SceneManager.LoadScene(scene);
    }




}
