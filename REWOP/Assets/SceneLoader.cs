using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {
    SceneControl sc;
    public List<string> scenesToLoad;
    private void Start()
    {
        sc = SceneControl.instance;
        foreach (string scene in scenesToLoad)
        {
            sc.LoadScene(scene);
        }
    }
}
