using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveApple : MonoBehaviour
{
    private float halfWidth, halfHeight;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 cView = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        halfWidth = cView.x;
        halfHeight = cView.y;
        moveApple();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        moveApple();
    }

    void moveApple()
    {
        float width = halfWidth * 2;
        float height = halfHeight * 2;
        transform.position = new Vector2(Random.value * width - halfWidth, Random.value * height - halfHeight);
    }
}
