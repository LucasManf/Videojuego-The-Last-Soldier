using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(Player!=null)
        {
            Vector3 position = transform.position;
            position.x = Player.transform.position.x;
            transform.position = position;
        }
    }
}
