using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd,
}

public class PerplexingParcels : MonoBehaviour

{
    static private PerplexingParcels S; // a private Singleton

    public Text uitLevel;
    public Text highScoreText;
    public Text scoreCounter;
    public Text title;
    public Button StartButton;
    public Text StartButtonText;
    public GameObject[] levels;
    public string button = "Start";
    public Text Credit;
    public Text MadeBy;

    private float time = 0.0f;
    public int score = 10000;
    public int highscore = 0000;

    public int level;
    public int levelMax;
    public GameObject puzzle;
    public GameMode mode = GameMode.idle;
    private Color LevCount;
    private Color HighSc;
    private Color ScCo;
    private Color TitleC;
    private Color StButton;
    private Color StButtonT;
    private Color CreditCo;
    private Color MadeByCo;
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", highscore);
        highScoreText.text = "High Score: " + highscore.ToString();
    }

    void Start()
    {
        S = this;
        level = 0;
        levelMax = levels.Length;
        LevCount = uitLevel.color;
        HighSc = highScoreText.color;
        ScCo = scoreCounter.color;
        TitleC = title.color;
        StButton = StartButton.image.color;
        StButtonT = StartButtonText.color;
        CreditCo = Credit.color;
        MadeByCo = MadeBy.color;
    }

    public void ButtonPress(string eView = "")
    {
        if (eView == "")
        {
            eView = StartButtonText.text;
        }
        button = eView;
        switch (button)
        {
            case "Start":

                LevCount.a = 1.0f;
                uitLevel.color = LevCount;
                HighSc.a = 0.0f;
                highScoreText.color = HighSc;
                ScCo.a = 1.0f;
                scoreCounter.color = ScCo;
                TitleC.a = 0.0f;
                title.color = TitleC;
                StButton.a = 0.0f;
                StartButton.image.color = StButton;
                StartButton.interactable = false;
                StButtonT.a = 0.0f;
                StartButtonText.color = StButtonT;
                StartLevel();
                score = 10000;
                scoreCounter.text = score.ToString();
                break;
            case "Restart":
                level = 0;
                TitleC.a = 1.0f;
                title.color = TitleC;
                CreditCo.a = 0.0f;
                Credit.color = CreditCo;
                MadeByCo.a = 0.0f;
                MadeBy.color = MadeByCo;
                StartButtonText.text = "Start";
                break;
        }
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
        time += Time.deltaTime;
        if (time >= 5f && mode == GameMode.playing)
        {
            time = 0.0f;
            score -= 100;
            scoreCounter.text = score.ToString();
        }
        if (Input.GetKeyDown(KeyCode.R) && mode == GameMode.playing)
        {
            Invoke("ResetLevel", 1f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
            mode = GameMode.idle;
            Destroy(puzzle);
            Invoke("Credits",0f);
        }
        else StartLevel();
    }
    void ResetLevel()
    {
        StartLevel();
    }

    void Credits()
    {
        LevCount.a = 0.0f;
        uitLevel.color = LevCount;
        if(score > highscore)
        {
            highscore = score;
        }
        if (highscore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        highScoreText.text = "High Score: " + scoreCounter.text;
        HighSc.a = 1.0f;
        highScoreText.color = HighSc;
        ScCo.a = 0.0f;
        scoreCounter.color = ScCo;
        StButton.a = 1.0f;
        StartButtonText.text = "Restart";
        StartButton.image.color = StButton;
        StButtonT.a = 1.0f;
        StartButtonText.color = StButtonT;
        CreditCo.a = 1.0f;
        Credit.color = CreditCo;
        MadeByCo.a = 1.0f;
        MadeBy.color = MadeByCo;
        StartButton.interactable = true;
    }

}
