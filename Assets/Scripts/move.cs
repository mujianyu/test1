using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 moveInput;
    [SerializeField] private float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }
    
   
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameMode==GameManager.GameMode.Normal)
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.gameMode == GameManager.GameMode.Normal)
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);
    }
}
