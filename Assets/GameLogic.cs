using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    //Initialize Varibales
    public GameObject startCanvas;
    public GameObject gameCanvas;
    public GameObject gameOverCanvas;
    public GameObject player;

    public float enemySpeed = 1.5f;
    public SpawnEnemies spawnEnemies;
    public PlayerScript playerScript;

    [SerializeField] TMP_Text playerLifeText;
    [SerializeField] TMP_Text playerScoreText;

    public int playerLife = 3;
    public int playerScore = 0;
    //Track current level
    int currentLevel = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetGame();

        //Initalize SpawnEnemies reference
        spawnEnemies = GetComponent<SpawnEnemies>();

        //Initalize Player reference
        playerScript = player.GetComponent<PlayerScript>();
    }
    
    //Show Game
    public void ShowGame()
    {
        //Load Game canvas and start game
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);

        //Set score for first game
        playerLife = 3;
        playerScore = 0;
        currentLevel = 0;

        //Display Lives and Score
        DisplayLives();
        DisplayScore();

        //Start spawning enemies
        UpdateLevel();
    }

    // Update is called once per frame
    void Update()
    {

        //Run game if dispalyed
        if (gameCanvas.activeSelf)
        {

            //Display Lives and Score
            DisplayLives();
            DisplayScore();

            //If player still has lives- Play game
            if (playerLife > 0)
            {
                //Show current level
                UpdateLevel();
            }
            else if (playerLife == 0)
            {
                //Stop enemy spawning
                spawnEnemies.StopSpawning();

                //Show game over canvas
                startCanvas.SetActive(false);
                gameCanvas.SetActive(false);
                gameOverCanvas.SetActive(true);
            }
        }
    }

    
    //Start or Reset Game
    public void ResetGame()
    {
        //Reset the Canvas to Start Screen
        startCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);

        //Reset Lives
        playerLife = 3;

        //Reset Score
        playerScore = 0;

        //reset level
        currentLevel = 0;

        //Stop ongoing enemies
        spawnEnemies.StopSpawning();
    }



    //Update Lives Text
    public void DisplayLives()
    {
        playerLifeText.text = playerLife.ToString();
    }

    //Update Score Text
    public void DisplayScore()
    {
        playerScoreText.text = playerScore.ToString();
    }

    void UpdateLevel()
    {
        //Initialize level
        int newLevel = 0;
        
        if (playerScore <= 25)
        {
            newLevel = 1;
        }
        else if (playerScore > 25 && playerScore <= 50)
        {
            newLevel = 2;
        }
        else if (playerScore > 50)
        {
            newLevel = 3;
        }


        if (newLevel != currentLevel)
        {
            spawnEnemies.StartSpawning(newLevel);
        }
    }
}
