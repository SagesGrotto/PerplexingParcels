using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class PerplexingParcels : MonoBehaviour

{
    static private PerplexingParcels S; // a private Singleton

    public Text uitLevel;
    public GameObject[] levels;


    public int level;
    public int levelMax;
    public GameObject puzzle;
    public GameMode mode = GameMode.idle;

    // Start is called before the first frame update
    void Start()
    {
        S = this;

        level = 0;
        levelMax = levels.Length;
        StartLevel();

    }

    void StartLevel()
    {
        if (puzzle != null)
        {
            Destroy(puzzle);
        }
        puzzle = Instantiate<GameObject>(levels[level]);
        Goal.goalMet = false;
        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("ResetLevel", 1f);
        }
        if ((mode == GameMode.playing) && Goal.goalMet)
        {

            mode = GameMode.levelEnd;
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
    void ResetLevel()
    {
        StartLevel();
    }
}
