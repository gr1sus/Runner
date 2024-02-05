
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject level;
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject StartGroundTile1;
    [SerializeField] private GameObject StartGroundTile2;
    [SerializeField] private int numberOfGround = 5;
    Vector3 nextSpawnPoint;
    Vector3 lastGroundTile;
    float differencePlayerAndNextSpawnPoint;
    private Queue<GameObject> spawningGroundTiles = new Queue<GameObject>();
    [SerializeField] private GameObject[] groundTiles;
    PlayerMovement playerMovement;
    private float speed;


    private void Awake()
    {
        for (int i = 0; i < numberOfGround; i++)
        {
            SpawnTile();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();


    }

    // Update is called once per frame
    void Update()
    {
        differencePlayerAndNextSpawnPoint = lastGroundTile.z - Player.transform.position.z;
        SpawnNewTile();
    }

    private void SpawnTile()
    {
       int randomTile = Random.Range(0, groundTiles.Length);
       GameObject temp = Instantiate(groundTiles[randomTile],nextSpawnPoint,Quaternion.identity);
       nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        Debug.Log(nextSpawnPoint);
       temp.transform.SetParent(level.transform);
       lastGroundTile = temp.transform.position;
       spawningGroundTiles.Enqueue(temp);

    }
    public void SpawnNewTile()
    {
        if (differencePlayerAndNextSpawnPoint <= 50)
        {
            SpawnTile();
            Destroy(spawningGroundTiles.Dequeue());
            speed = playerMovement.GetSpeed(speed);
            if(speed <= 51)
            {
                playerMovement.SetSpeed(speed+1.5f);
            }
        }
    }
   
}
