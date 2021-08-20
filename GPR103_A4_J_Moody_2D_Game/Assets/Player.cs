using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = "Forggo"; //The players name for the purpose of storing the high score

    public int playerTotalLives = 10; //Players total possible lives.
    public int playerLivesRemaining = 10; //PLayers actual lives remaining.
   
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = false; //Can the player currently move?

    private GameManager myGameManager; //A reference to the GameManager in the scene.

    // Start is called before the first frame update
    void Start()
    {
        myGameManager = GameManager.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < myGameManager.levelConstraintTop)
        {
            transform.Translate(new Vector2(0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y < myGameManager.levelConstraintBottom)
        {
            transform.Translate(new Vector2(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.A) && transform.position.y < myGameManager.levelConstraintLeft)
        {
            transform.Translate(new Vector2(-1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.y < myGameManager.levelConstraintRight)
        {
            transform.Translate(new Vector2(1, 0)); // I decided to use the "transform.translate" method as it meant that i was only dealing with vector 2 and i honestly thought it made the code look cleaner
        }
    }
    
}
