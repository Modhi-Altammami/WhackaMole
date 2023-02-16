using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Modhi.WhackAMole
{
    public class DisplayScore : MonoBehaviour
    {

        private int score;
        // Start is called before the first frame update
        void Start()
        {
            score = PlayerPrefs.GetInt("Score");

            GetComponent<TextMeshProUGUI>().text = score.ToString("0");
        }



    }
}