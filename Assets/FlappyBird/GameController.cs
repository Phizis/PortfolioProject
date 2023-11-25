using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float spawnCooldown;
    [SerializeField] float height;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PipesSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PipesSpawn()
    {
        while (true)
        {
            Instantiate(pipePrefab, transform.position + new Vector3(0, Random.Range(-height, height)), Quaternion.identity );
            yield return new WaitForSeconds(spawnCooldown);
        }
        
    }
}
