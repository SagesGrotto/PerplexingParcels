using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static private GameManager gm; //ref to game manager

    static public GameManager GM { get { return gm; } } // public access to game manager
    // Start is called before the first frame update

    void CheckGameManagerIsInScene()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this); //Do not delete the game manager when new scene is loaded
    }
#endregion

    [Header("GENERAL SETTINGS")]
    public string gameTitle = "Untitled Game";
    public string gameCredits = "Made by Sage";
    public string copyrightDate = "Copyright 2/23/2022";

    [Header("GAME SETTINGS")]

    public bool canBeatLevel = false;//replace with box check
    public int beatLevelScore;//replace with box check

    [Space(10)]

    [Tooltip("Is the level timed")]
    public bool timedLevel = false;
    publix float startTime = 5.0f;

    [Space(10)]

    [SerializeField]//Access to private variables in editor
    private int numberOfLives;
    public static int lives;
    public int Lives { get { return lives; } set { lives = value; } }
    public static int score
    public int Lives { get { return score; } set { score = value; } }
    public bool Died { get { return died; } set { died = value; } }
    [Space(10)]
    public string loseMessage = "You Lose";
    public string winMessage = "You Win";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
