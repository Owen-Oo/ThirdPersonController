using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;

    private static GameObject[] coins;

    void Start()
    {
        score = 0;
        Debug.Log(score.ToString());

        coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coins)
        {
            Coin coinScript = coin.GetComponent<Coin>();
            coinScript.CoinCollected.AddListener(increaseScore);
        }
    }

    void Update()
    {
        
    }

    private void increaseScore()
    {
        score++;
        Debug.Log(score.ToString());
    }
}
