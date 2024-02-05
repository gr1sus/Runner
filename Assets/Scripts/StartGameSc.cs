
using UnityEngine;
using UnityEngine.UI;

public class StartGameSc : MonoBehaviour
{
    [SerializeField] Text startText;
    [SerializeField] GameObject parentStartText;
    private Text spawningText;
    PlayerMovement playerMovement;
    //Start is called before the first frame update
    private void Awake()
    {
        SpawnStartText();
    }
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        playerMovement.SetSpeed(0);

        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Space))
         {
             Destroy(spawningText);
             playerMovement.SetSpeed(5);
         }*/
        if (Input.touchCount > 0)
        {
            Destroy(spawningText);
            playerMovement.SetSpeed(5);
        }
    }
    private void SpawnStartText()
    {

       Vector3 positionParent = parentStartText.transform.position;
        spawningText = Instantiate(startText,
                                      positionParent,
                                      Quaternion.identity);
        spawningText.transform.SetParent(parentStartText.transform);
    }
}
