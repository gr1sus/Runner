
using System;
using UnityEngine;


public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private float speed = 5;
    [SerializeField] private float horizontalMultiplier = 2;
    [SerializeField] private Rigidbody rb;
    private float horizontalInput;
    private Touch touch;


    // Start is called before the first frame update
    void Start()
    {

        
    }
    void OnEnable()
    {
        //TouchSimulation.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
    }
    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
       
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Debug.Log(touch);
            Vector3 horizontalMove = transform.right * touch.deltaPosition.x * speed * horizontalMultiplier * Time.fixedDeltaTime;
            Debug.Log("touch" + touch.deltaPosition.x);
            Debug.Log("speed" + speed);
            Vector3 movementIfApplied = horizontalMove + transform.position;
            if (movementIfApplied.x >= 2.8f)
            {
                horizontalMove.x = 0.0f;
            }
            if (movementIfApplied.x <= -2.8f)
            {
                horizontalMove.x = 0.0f;
            }
            rb.MovePosition(rb.position + horizontalMove );
        }
        rb.MovePosition(rb.position + forwardMove);
    }
    public void SetSpeed(float speed1)
    {
        speed = speed1;
    }
    public float GetSpeed(float speed1)
    {
        return speed1 = this.speed;
    }
}
