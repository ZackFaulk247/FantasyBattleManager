using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movelimit;

    void Update()
    {
        Vector2 pos = transform.position;
        if (Input.GetKey("up"))
        {
            pos.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("down"))
        {
            pos.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("right"))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }



       
        pos.x = Mathf.Clamp(pos.x, -movelimit.x, movelimit.x);
        pos.y = Mathf.Clamp(pos.y, -movelimit.y, movelimit.y);

        transform.position = pos;
    }
}
