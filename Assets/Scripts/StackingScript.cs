using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackingScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform cubeVisual;
    CollisionWithObstacles collisionWithObstacles;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject scoreTextParent;
    [SerializeField] Animator animator;

    float jumpHight = 1f;
    private Text movingText;


    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        MoveText();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stackable"))
        {
            StartCoroutine(JumpAnimation());
            Vector3 newPos = player.position;
            newPos.y += jumpHight;
            player.position = newPos;
           

            Vector3 newPosCube = cubeVisual.position;
            newPosCube.y += jumpHight;
            cubeVisual.position = newPosCube;
            
            Transform t = other.transform;
            t.tag = "Untagged";
            t.SetParent(this.transform);
            t.localPosition = new Vector3(0, cubeVisual.transform.position.y-1,  0);
            SpawnText();
           



        }
       

    }
    private IEnumerator JumpAnimation()
    {
        animator.SetBool("Jump", true);

        // ∆дем некоторое врем€, чтобы анимаци€ прыжка воспроизвелась
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        animator.SetBool("Jump", false);
    }
    private void SpawnText()
    {
        Vector3 positionParent = scoreTextParent.transform.position;
        Text temp = Instantiate(scoreText,
                                      positionParent,
                                      Quaternion.identity);
        temp.transform.SetParent(scoreTextParent.transform);
        movingText = temp;
        
        Destroy(temp, 0.3f);
    }
    private void MoveText()
    {
        float randomNumberX = Random.Range(-300, -200);
        float randomNumberY = Random.Range(-100, -50);
        if (movingText != null)
        {
            movingText.transform.Translate(new Vector2(randomNumberX * Time.deltaTime, randomNumberY * Time.deltaTime));
           
        }
    }

}
