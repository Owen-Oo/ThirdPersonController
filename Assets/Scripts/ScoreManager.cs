using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private static GameObject[] coins;

    void Start()
    {
        score = 0;
        scoreText.SetText("Score: " +  score);

        coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coins)
        {
            Coin coinScript = coin.GetComponent<Coin>();
            coinScript.CoinCollected.AddListener(increaseScore);
        }
    }

    private void increaseScore()
    {
        score++;
        scoreText.SetText("Score: " + score);
    }
}
