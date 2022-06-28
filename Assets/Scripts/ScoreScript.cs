using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static float scoreValue = 0;
    private Text score;

    private void Start()
    {
        score = GetComponent<Text>();
        Debug.Log(score);
    }

    private void Update()
    {
        score.text = "Height: " + scoreValue.ToString("0.00") + " meters";
    }
}
