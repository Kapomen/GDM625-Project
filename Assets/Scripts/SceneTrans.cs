﻿using UnityEngine;
//using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{

    public void ChangeToScene(string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    } //end ChangeToScene
} //end SceneTrans
