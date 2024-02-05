
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] private GameObject ObstacleSpawnPoint;
    [SerializeField] private GameObject[] Obstacles;

    GroundSpawner groundSpawner;
    int randomObstacle;
    void SpawnObstacle()
    {
        randomObstacle = Random.Range(0, Obstacles.Length);
        GameObject temp = Instantiate(Obstacles[randomObstacle],ObstacleSpawnPoint.transform.position, Quaternion.identity);
        temp.transform.SetParent(ObstacleSpawnPoint.transform);

    }
    

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();

    }
    
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
