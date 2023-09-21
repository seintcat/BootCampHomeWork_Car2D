using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private int stage;
    [SerializeField]
    private List<GameObject> stages;
    [SerializeField]
    private TextMeshProUGUI stageText;

    public List<GameObject> customers;
    public int score;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == null)
        {
            return;
        }
    }

    public void CheckNextStage()
    {
        if (customers.Count == score)
        {
            GoNextStage();
        }
    }

    private void GoNextStage()
    {
        score = 0;
        stages[stage].SetActive(false);
        stage++;
        if(stage >= stages.Count)
        {
            stage = 0;
        }
        stages[stage].SetActive(true);
        stageText.text = "Stage " + (stage + 1);
        timer.totalTime = 0;
    }

    public void CheckEndGame()
    {
        if (customers.Count != score && timer.isUpdated)
        {
            timer.isUpdated = false;
        }
    }
}
