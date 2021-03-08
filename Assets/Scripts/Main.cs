using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private GameObject player;
    private GameObject apple;
    private Vector2 dest;
    public float step;
    private float halfWidth, halfHeight;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 cView = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        halfWidth = cView.x;
        halfHeight = cView.y;
        Debug.Log(halfHeight + " " + halfWidth);

        player = GameObject.Find("Player");
        apple = GameObject.Find("Apple");
        // Player starts in the middle:
        player.transform.position = new Vector2(0, 0);
        // Apple starts at random position
        moveApple();
        dest = player.transform.position + new Vector3(0.1f, 0.1f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        float dist = Vector2.Distance(dest, player.transform.position);
        Vector2 move = step * (dest - (Vector2)player.transform.position) / dist;

        if (move.magnitude < dist)
        {
            player.transform.Translate((Vector3)move);
        }
        // if player is close to apple:
        float pToA = Vector2.Distance(player.transform.position, apple.transform.position);
        if (pToA < 0.9f)
        {
            moveApple();
        }
    }

    void moveApple()
    {
        float width = halfWidth * 2;
        float height = halfHeight * 2;
        apple.transform.position = new Vector2(Random.value * width - halfWidth, Random.value * height - halfHeight);
    }
}
