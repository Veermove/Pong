using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformR : MonoBehaviour
{

    public int platformSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(moveUp());
        } else if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(moveDown());
        }
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    IEnumerator moveUp()
    {
        while (true)
        {
            if(transform.position.y <= 4.0)
            {
                transform.Translate(Vector3.up * Time.deltaTime * platformSpeed);
            }
            if(Input.GetKeyUp(KeyCode.J))
            {
                break;
            }
            yield return null;
        }
    }

    IEnumerator moveDown()
    {
        while (true)
        {
            if(transform.position.y >= -4.0)
            {
                transform.Translate(Vector3.down * Time.deltaTime * platformSpeed);
            }
            if(Input.GetKeyUp(KeyCode.M))
            {
                break;
            }
            yield return null;
        }
    }
}
