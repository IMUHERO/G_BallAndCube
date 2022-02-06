using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/// <summary>
/// 
/// </summary>
public class PlayerController : MonoBehaviour
{
    public int speed = 2;
    public TextMeshProUGUI countText;
    public GameObject winText;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.SetActive(false);
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 moveDis = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(moveDis * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count ++;
            setCountText();
        }
    }

    private void setCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 4){
            winText.SetActive(true);
        }
    }
}
