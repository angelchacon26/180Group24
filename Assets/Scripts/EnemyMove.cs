using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public int speed;
    private bool goingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        //Left position grabs the transform from the leftPoint GameObject
        leftPos = leftPoint.transform.position;
        //Right position grabs the transform from the rightPoint GameObject
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    //Move left and right for Enemy
    private void move()
    {
        if (goingLeft)
        {

            //If the enemy's x position is less than or equal to the leftPos
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        //If the enemy is not goingLeft then do this
        else

        {

            //If the enemy's x position is less than or equal to the leftPos
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
        }
    }
}
