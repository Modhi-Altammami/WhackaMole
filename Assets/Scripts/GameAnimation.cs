using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modhi.WhackAMole
{
    
    public class GameAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject mole;
        public static GameAnimation Instance;
        


        void Awake()
        {
            if (Instance == null) // if instance is not initilized then instance is equal to class
                Instance = this;
            else
            {
                Destroy(gameObject);
            }
            GameManager.ScaleEvent += Scale;
            ScaleLoop(mole);
        }

        public void MoveLoop(GameObject gameObject)
        {
            LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 50f, 1f).setLoopPingPong();
        }

        public void Scale(GameObject gameObject)
        {
            LeanTween.scale(gameObject, new Vector3(5f, 3f, 1f), 2f).setDelay(0.5f).setEase(LeanTweenType.easeOutElastic);

        }

        public void ScaleLoop(GameObject gameObject)
        {
            LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1f), 0.5f).setLoopPingPong();

        }
    }

}
