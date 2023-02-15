using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;


namespace Modhi.WhackAMole
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float gameTimer;
        [SerializeField] private TextMeshProUGUI countdown;
        [SerializeField] private TextMeshProUGUI Score;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Mole[] Moles;

        private Mole cur;
        private bool stopGame;
        private float score;
        public static GameManager Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            stopGame = false;
        }
        // Start is called before the first frame update
        void Start()
        {
            score = 0;
            PopMole();
        }

        // Update is called once per frame
        void Update()
        {
            gameTimer -= Time.deltaTime;
            countdown.text = gameTimer.ToString("0");
            if (gameTimer < 1)
            {
                countdown.text = "Finish";
                gameTimer = 0;
                if (!stopGame)
                    GameOver();
            }
        }


        public void updateScore()
        {
            score++;
            Score.text = score.ToString("0");

        }

        public void PopMole()
        {
            cur = Moles[Random.Range(0, Moles.Length)];
            while (!cur.ISReady)
            {
                cur = Moles[Random.Range(0, Moles.Length)];
            }
            cur.setMovingUp = true;
            cur.GetComponent<Collider>().enabled = true;
        }


        public void GameOver()
        {
            stopGame = true;
            foreach (Mole mole in Moles)
            {
                cur.setMovingUp = false;

            }
            GameAnimation.Instance.Scale(gameOverPanel);
        }
    }
}