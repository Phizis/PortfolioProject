using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float pipeSpeed;

    void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }
}
