using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sideSpeed;
    private Vector3 movement;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        movement = new Vector3(0f, 0f, -1*Input.GetAxis("Horizontal"));
        pos.z = Mathf.Clamp(pos.z, -4f, 4f); //returns min if z pos < min or returns max if z pos > max
        transform.position = pos;
        //Debug.Log(movement);
        Move();
    }

    void Move()
    {
        //Debug.Log(this.transform.position);
        Vector3 newPos = speed*Vector3.right + sideSpeed*movement;
        transform.position = transform.position + newPos*Time.deltaTime;
        
    }
}
