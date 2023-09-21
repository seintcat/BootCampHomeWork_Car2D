using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float finishTime = 30f;
    [SerializeField]
    private float nowSecondsToFinish;
    [SerializeField]
    private TextMeshProUGUI timerText;

    public bool isUpdated;
    public float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        nowSecondsToFinish = finishTime - totalTime;
        if(nowSecondsToFinish < 0)
        {
            isUpdated = true;
            totalTime = 0;
            GameManager.instance.CheckEndGame();
        }
        timerText.text = string.Format("{0:N2}", nowSecondsToFinish);
    }
}
