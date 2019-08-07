using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("LoadFirstScene", 2f);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
