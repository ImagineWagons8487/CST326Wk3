using UnityEngine;

public class LGoalScript : MonoBehaviour
{
    public ScoreHandlerScript lScore;

    public BallScript ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            lScore.lScore++;
            lScore.UpdateScore();
            ball.ResetBall(-1);
            Debug.Log($"Right side player scored. Current Score:{lScore.lScore}  -  {lScore.rScore}");
        }
    }
}
