using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    [SerializeField] int scorePerHit = 12;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = $"{score}";
    }

    public void ScoreHit()
    {
        score += scorePerHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
