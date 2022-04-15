using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: [Chacon, Angelica]
 * Date: [04/12/2022]
 * [PlayerMovement script.]
 */
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump_force;
    public bool isGrounded = true;
    public int coins = 0;
    public int lives = 3;
    private Vector3 startPos;
    private Rigidbody rigid_body;
    public Text coinText;
    public Text livesText;
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigid_body = GetComponent<Rigidbody>();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 add_position = Vector3.zero;

        //Movement for left and right using A and D 
        if (Input.GetKey("a"))
        {
            add_position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            add_position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey("w"))
        {
            add_position += Vector3.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("s"))
        {
            add_position += Vector3.back * Time.deltaTime * speed;
        }
        //Jumping using space key
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKey("space") && isGrounded)
        {
            rigid_body.AddForce(Vector3.up * jump_force);
        }

        GetComponent<Transform>().position += add_position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spike")
        {
            Respawn();
        }
        print("Trigger");
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            print("Coin" + coins);
            other.gameObject.SetActive(false);
            SetCountText();

        }
    }
    public void Respawn()
    {
        transform.position = startPos;
        lives--;
        SetCountText();
     
    }
    public void SetCountText()
    {
        coinText.text = "Coins :" + coins.ToString();
        livesText.text = "Lives :" + lives.ToString();
        if (lives <= 0)
        {
            gameOverText.text = "Game Over";
            this.gameObject.SetActive(false);
        }
    }


}
