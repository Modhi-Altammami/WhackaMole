using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{

    [SerializeField] private bool MovingUp;
    [SerializeField] private float Ydirection;
    [SerializeField] private float speed;
    [SerializeField] private float moleUpDuration;
    private Vector3 startingPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (MovingUp == true)
        {
            moleUpDuration -= Time.deltaTime;
        }

        if (MovingUp)
        {
            if (transform.position.y < Ydirection)
            {
                moveUp();
            }
            else
            {
                transform.position = new Vector3(startingPoint.x, Ydirection, startingPoint.z);
            }
        }
        else
        {
            if (transform.position.y > startingPoint.y)
            {
                moveDown();
            }
            else
            {
                transform.position = startingPoint;
            }
        }

        if (moleUpDuration < 1 &&MovingUp == true)
        {
            MovingUp = false;
            moleUpDuration = 3;
        }
    }


    void moveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void moveDown()
    {
        transform.Translate(Vector3.down * speed* Time.deltaTime);
    }


    public void OnMouseDown()
    {
       MovingUp = false;
       moleUpDuration = 3;
       GameManager.Instance.updateScore();
    }
}
