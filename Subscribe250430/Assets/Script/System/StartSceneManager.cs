using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
 
    public void IntoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

}
