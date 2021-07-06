using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSinglton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int chekenni = FindObjectsOfType<ChickenSinglton>().Length;
        if (chekenni > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Awake()
    {
       
    }
}
