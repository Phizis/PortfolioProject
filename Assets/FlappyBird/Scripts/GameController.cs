using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{ 

    [Header("Pipe Controller")]
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float spawnCooldown;
    [SerializeField] float height;

    [Header("Score Controller")]
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] PipeMovement scoreSpeed;
    private int currentScore;
    private int bestScore;
    public bool isGameOver;

    [Header("LeaderBoard")]
    [SerializeField] GameObject GoldMedal;
    [SerializeField] GameObject SilverMedal;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    
    void Start()
    {
        isGameOver= false;
        GoldMedal.SetActive(false);
        SilverMedal.SetActive(false);
        LoadScore();

        StartCoroutine(PipesSpawn());
        StartCoroutine(ScoreCount());        
    }

    public void GameOver()
    {
        isGameOver = true;
        StopAllCoroutines();
        currentScore--;

        if(currentScore > bestScore)
        {
            GoldMedal.SetActive(true);
            bestScore = currentScore;
            SaveScore(bestScore);
        }
        else
        {
            SilverMedal.SetActive(true);
        }

        currentScoreText.text = currentScore.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    private void SaveScore(int bestScore)
    {
        PlayerPrefs.SetInt("bestScore", bestScore);
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("bestScore"))
            bestScore = PlayerPrefs.GetInt("bestScore");
        else
            PlayerPrefs.SetInt("bestScore", bestScore);
    }

    IEnumerator PipesSpawn()
    {
        while (true)
        {
            Instantiate(pipePrefab, transform.position + new Vector3(0, Random.Range(-height, height)), Quaternion.identity );
            yield return new WaitForSeconds(spawnCooldown);
        }        
    }

    IEnumerator ScoreCount()
    {
        while (true)
        {
            ScoreText.text = currentScore.ToString();
            currentScore++;
            yield return new WaitForSeconds(scoreSpeed.pipeSpeed);
        }
    }
}
