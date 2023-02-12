using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTimer;
    [SerializeField] private TextMeshProUGUI countdown;
    [SerializeField] private TextMeshProUGUI Score;
    private float score;
    public static GameManager Instance;


    void Awake()
    {
        if (Instance == null){
            Instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

       score= 0;


    }

    // Update is called once per frame
    void Update()
    {
       
        gameTimer -= Time.deltaTime;
      
        // Convert integer to string
        countdown.text =gameTimer.ToString("0");
        if (gameTimer < 1)
        {
            countdown.text = "Finish";
        }

      


    }


   public void updateScore()
    {
        score++;
        Score.text = score.ToString("0");

    }
}
