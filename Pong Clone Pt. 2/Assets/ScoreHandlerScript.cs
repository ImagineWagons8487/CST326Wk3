using TMPro;
using UnityEngine;

public class ScoreHandlerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int lScore, rScore;

    public CameraScript cScript;

    private bool scored;

    private float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lScore = 0;
        rScore = 0;
        scored = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scored)
        {
            t += Time.deltaTime;
            scoreText.fontSize -= .5f;
            if (t >= 1 && scoreText.fontSize <= 42)
            {
                scored = false;
                scoreText.text = $"<color=white>{lScore}  -  {rScore}</color>";
                scoreText.fontSize = 42;
                t = 0;
            }
        }
    }

    public void UpdateScore(string scorer)
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

        if (scorer == "right")
        {
            scoreText.text = $"{lScore}  -  <color=red>{++rScore}</color>";
            scored = true;
            scoreText.fontSize += 42;
        }
        else if (scorer == "left")
        {
            scoreText.text = $"<color=red>{++lScore}</color>  -  {rScore}";
            scored = true;
            scoreText.fontSize += 42;
        }
        cScript.resetShakeMag();
    }
    
}
