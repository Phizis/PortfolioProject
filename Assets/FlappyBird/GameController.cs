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
    private float score = 0;

    
    void Start()
    {
        StartCoroutine(PipesSpawn());
        StartCoroutine(ScoreCount());        
    }

    public void GameOver()
    {
        StopAllCoroutines();
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
            ScoreText.text = score.ToString();
            score++;
            yield return new WaitForSeconds(scoreSpeed.pipeSpeed);
        }
    }
}
