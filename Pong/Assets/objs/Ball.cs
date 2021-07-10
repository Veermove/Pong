using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Ball : MonoBehaviour
{

    public int ballSpeed = 4;

    Vector3 direction;

    PlatformL platLeft;
    PlatformR platRight;

    Text txt;
    int leftScore = 0;
    int rightScore = 0;



    // Start is called before the first frame update
    void Start()
    {

        txt = GameObject.Find("Text").GetComponent<Text>();
        platLeft = GameObject.Find("PlatformLeft").GetComponent<PlatformL>();
        platRight = GameObject.Find("PaltformRight").GetComponent<PlatformR>();

        txt.text = leftScore + " - " + rightScore;
        direction = Vector3.zero;
        System.Random rand = new System.Random();
        float angle = (float)(rand.Next(361));
        direction.x = Mathf.Cos(angle);
        direction.y = Mathf.Sin(angle);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 left = platLeft.getPosition();
        Vector3 right = platRight.getPosition();
        // Debug.Log(right.x);
        if (transform.position.x <= left.x + 0.35)
        {
            if (transform.position.y <= left.y + 1.5 && transform.position.y >= left.y - 1.5)
            {
                direction.x *= -1;
            }
        }
        if (transform.position.x >= + right.x - 0.35)
        {
            if (transform.position.y <= right.y + 1.5 && transform.position.y >= right.y - 1.5)
            {
                direction.x *= -1;
            }
        }

        if (transform.position.y >= 4.7 || transform.position.y <= -4.7)
        {
            direction.y *= -1;
        }
        if (transform.position.x > 10 || transform.position.x < -10)
        {
            if (transform.position.x > 0)
            {
                leftScore++;
            } else
            {
                rightScore++;
            }
            transform.SetPositionAndRotation(Vector3.zero, transform.rotation);
            txt.text = leftScore + " - " + rightScore;
            System.Random r = new System.Random();
            float angle = (float)(r.Next(361));
            direction.x = Mathf.Cos(angle);
            direction.y = Mathf.Sin(angle);
        }
        transform.Translate(direction * Time.deltaTime * ballSpeed);
    }
}
