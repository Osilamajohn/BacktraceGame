using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1Loader : MonoBehaviour
{

    public float waitingTime = 58;
    float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;

        if(timePassed>= waitingTime)
        {
            SceneManager.LoadScene(2);
        }


    }
}
