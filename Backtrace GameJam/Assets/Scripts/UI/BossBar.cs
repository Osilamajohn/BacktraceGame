using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{

    Slider slider;
    public BossMain bossMain;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = bossMain.bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = bossMain.bossHealth;
    }
}
