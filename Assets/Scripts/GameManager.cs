using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using System;

namespace Modhi.WhackAMole
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float gameTimer;
        [SerializeField] private TextMeshProUGUI countdown;
        [SerializeField] private TextMeshProUGUI Score;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Mole[] Moles;
        [SerializeField] private ParticleSystem particle;


        private Mole cur;
        private bool stopGame;
        private float score;
        private AudioSource Pop;
        public static GameManager Instance;
        public static event Action<GameObject> ScaleEvent;

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

            foreach(Mole mole in Moles)
            {
                mole.UpdateScoreEvent += updateScore;
                mole.PopMoleEvent += PopMole;
            }
            

           
        }
        // Start is called before the first frame update
        void Start()
        {
            Pop = GetComponent<AudioSource>();
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

         void updateScore()
        {
            displaychunk(cur.transform.position);
            score++;
            Score.text = score.ToString("0");
            if ((int)score > GetScore("Score"))
            {
                SetScore((int)score);
                PopMole();
            }

           
        }

         void PopMole()
        {
            cur = Moles[Random.Range(0, Moles.Length)];
            while (!cur.ISReady)
            {
                cur = Moles[Random.Range(0, Moles.Length)];
            }
            cur.setMovingUp = true;
            cur.GetComponent<Collider>().enabled = true;
            //displaychunk(cur.transform.position);
        }


         void GameOver()
        {
            stopGame = true;
            foreach (Mole mole in Moles)
            {
                cur.setMovingUp = false;

            }
            ScaleEvent?.Invoke(gameOverPanel);
            Pop.Play();
        }

         void SetScore(int Value)
        {
            PlayerPrefs.SetInt("Score", Value);
        }

         int GetScore(string KeyName)
        {
            return PlayerPrefs.GetInt(KeyName);
        }

        void displaychunk(Vector3 pos)
        {
            particle.Play();
            particle.transform.position = new Vector3(pos.x ,3 ,pos.z);
        }

    }

}