using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    public float heightOffset = 10;
    
    private float _timer;
    
    // Start is called before the first frame update
    public void Start()
    {
        SpawnPipe();        
    }

    // Update is called once per frame
    public void Update()
    {
        if (_timer < spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _timer = 0;
        }
    }

    private void SpawnPipe()
    {
        var position = transform.position;
        
        float currentY = position.y;
        float currentX = position.x;
        
        float lowestPoint = currentY - heightOffset;
        float highestPoint = currentY + heightOffset;

        float yPosition = Random.Range(lowestPoint, highestPoint);
        
        Vector3 newPosition = new Vector3(currentX, yPosition, 0);
        
        Instantiate(pipe, newPosition, transform.rotation);
    }
}
