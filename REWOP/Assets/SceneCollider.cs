using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollider : MonoBehaviour {
    private SceneControl sc;
    public string sceneToLoad;
    public string sceneToUnload;
    private void Start()
    {

        sc = SceneControl.instance;
    }
    void LoadScenes()
    {

        sc.UnloadScene(sceneToUnload);
        sc.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadScenes();
    }

}
