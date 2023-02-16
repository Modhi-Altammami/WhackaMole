using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Modhi.WhackAMole
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class Mole : MonoBehaviour
    {
        [SerializeField] private bool MovingUp;
        [SerializeField] private float Ydirection;
        [SerializeField] private float speed;
        [SerializeField] private float moleUpDuration;
        private float FixedMoleUpDuration;
        private bool isReady;
        private Vector3 startingPoint;
        public bool setMovingUp { set { MovingUp = value; } get { return MovingUp; } }
        public bool ISReady { set { isReady = value; } get { return isReady; } }

        public event Action UpdateScoreEvent;
        public event Action PopMoleEvent;

        // Start is called before the first frame update
        void Start()
        {
            startingPoint = transform.position;
            FixedMoleUpDuration = moleUpDuration;
            isReady = true;
        }

        // Update is called once per frame
        void Update()
        {
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

                moleUpDuration -= Time.deltaTime;
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
                    isReady = true;
                }
            }

            if (moleUpDuration < 1 && MovingUp == true)
            {
                Generate();
            }
        }


        void moveUp()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        void moveDown()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }


        public void OnMouseDown()
        {
           UpdateScoreEvent? .Invoke();
            Generate();

        }


        void Generate()
        {
            gameObject.GetComponent<Collider>().enabled = false;
            MovingUp = false;
            isReady = false;
            PopMoleEvent? .Invoke();
            moleUpDuration = FixedMoleUpDuration;
        }
    }
}