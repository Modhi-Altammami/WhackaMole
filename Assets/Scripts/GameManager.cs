using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTimer;
    [SerializeField] private TextMeshProUGUI countdown;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private Mole[] Moles;
    private Mole cur;
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
       PopMole();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
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

    public void PopMole()
    {
        cur = Moles[Random.Range(0, Moles.Length)];
        while (!cur.ISReady) 
        {
                cur = Moles[Random.Range(0, Moles.Length)];
        } 
       cur.setMovingUp=true;
       cur.GetComponent<Collider>().enabled = true;
    }
}
