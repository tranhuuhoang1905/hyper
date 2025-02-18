using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void OnEnable()
    {
        ScoreSignal.OnScoreUpdated += UpdateScoreUI;
    }

    void OnDisable()
    {
        ScoreSignal.OnScoreUpdated -= UpdateScoreUI;
    }

    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
