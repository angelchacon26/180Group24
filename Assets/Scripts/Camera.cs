using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 tempvector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempvector.x = player.transform.position.x;
        tempvector.z = player.transform.position.z;
        tempvector.y = transform.position.y;
        transform.position = tempvector;
    }
}
