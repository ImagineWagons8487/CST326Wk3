using TMPro;
using UnityEngine;

public class ScoreHandlerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int lScore, rScore;

    public CameraScript cScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lScore = 0;
        rScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        if (lScore == 11)
        {
            Debug.Log("Game Over, Left Paddle wins");
            lScore = 0;
            rScore = 0;
        }
        else if (rScore == 11)
        {
            Debug.Log("Game Over, Right Paddle wins");
            lScore = 0;
            rScore = 0;
        }

        scoreText.text = $"{lScore}  -  {rScore}";
        cScript.resetShakeMag();
    }
    
}
