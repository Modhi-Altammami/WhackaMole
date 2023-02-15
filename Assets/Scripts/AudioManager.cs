using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    void Awake()
    {
        if (instance == null) // if instance is not initilized then instance is equal to class
            instance = this;
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Start()
    {
        DontDestroyOnLoad(gameObject);
 
    }

}
