using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithObstacles : MonoBehaviour
{
    
    [SerializeField] private GameObject cube;
    [SerializeField] private LayerMask ignoreMask;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * (transform.localScale.z / 2 + 0.2f), Color.yellow);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, (transform.localScale.z / 2) + 0.2f))
        {
            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Obstackle"))
            {
                cube.transform.SetParent(hitInfo.collider.gameObject.transform);
            }
        }
    }
    private void FixedUpdate()
    {
       
    }
    /*    private void OnCollisionEnter(Collision collision)
        {
                Debug.Log("Collision detected");
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstackle"))
            {
                Debug.Log("Cube has hit obstacle");
                cube.transform.SetParent(collision.collider.gameObject.transform);

            }
            else
            {
            }
        }*/

}
