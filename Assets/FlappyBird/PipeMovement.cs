using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] float pipeSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }
}
