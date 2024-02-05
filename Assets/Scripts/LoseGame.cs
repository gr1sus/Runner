using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerVisual;
    [SerializeField] GameObject cubeVisual;
    [SerializeField] Text loseText;
    [SerializeField] GameObject parentLoseText;
    [SerializeField] private LayerMask ignoreMask;
    PlayerMovement playerMovement;
    private Text spawningText;
    bool lose = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement  = GameObject.FindObjectOfType<PlayerMovement>();    
    }

    // Update is called once per frame
    void Update()
    {

        RestartGame();
    }

    private void FixedUpdate()
    {
        GameLost(); 
    }
    private void RestartGame()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void GameLost()
    {
        Ray ray = new Ray(cubeVisual.transform.position, cubeVisual.transform.forward);
        Debug.DrawRay(transform.position, transform.forward * (transform.localScale.z / 2 + 0.2f), Color.yellow);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, (cubeVisual.transform.localScale.z / 2) + 0.2f))
        {
            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Obstackle"))
            {
                player.transform.SetParent(hitInfo.collider.gameObject.transform);
                playerMovement.SetSpeed(0);
                //SpawnLoseText();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void SpawnLoseText()
    {
        if (!lose)
        {
        Vector3 positionParent = parentLoseText.transform.position;
        spawningText = Instantiate(loseText,
                                      positionParent,
                                      Quaternion.identity);
        spawningText.transform.SetParent(parentLoseText.transform);
            lose = true;
        }
    }
}

