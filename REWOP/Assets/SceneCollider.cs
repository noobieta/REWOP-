using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollider : MonoBehaviour {
    public int ScenetoLoad;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(ScenetoLoad, LoadSceneMode.Single);
    }
}
