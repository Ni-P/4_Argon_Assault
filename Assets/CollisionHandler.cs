using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;

    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

    void OnTriggerEnter()
    {
        StartPlayerDeath();
        Invoke("ReloadScene", levelLoadDelay);
    }
    void OnCollisionEnter()
    {
        print("boom");
    }

    private void StartPlayerDeath()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

}
