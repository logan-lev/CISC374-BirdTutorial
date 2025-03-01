using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject pipesPrefab;
    
    private float timer = 0.0f;
    
    public float spawnTime = 2.0f;

    public float heightOffset = 10.0f;

    // Spawns the first pipe in position
    void Start()
    {
        Instantiate(pipesPrefab, transform.position, transform.rotation);
    }

    // Spawns a new pipe when the timer reaches the spawn time
    void Update()
    {
        if (timer < spawnTime) 
        {
            timer += Time.deltaTime;
        } 
        else 
        {
            spawnPipe();
            timer = 0.0f;
        }
        
    }

    // Spawns a new pipe at a random height
    void spawnPipe() 
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipesPrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
