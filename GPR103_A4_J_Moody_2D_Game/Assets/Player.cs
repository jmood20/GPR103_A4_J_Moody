﻿using System.Collections;
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
    public bool playerCanMove = true; //Can the player currently move?

    // this is the public section thingy-mah-bob where the audio for the game is help

    public AudioClip jumpAudio;    
    public AudioClip ScoreAudio;
    public AudioClip hurtAudio;
    



    private GameManager myGameManager; //A reference to the GameManager in the scene.

    // Start is called before the first frame update
    void Start()
    {
        myGameManager = GameManager.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    { if (playerIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < myGameManager.levelConstraintTop) //this code means that the player can move within a certain area, but the constraints in the game manager are implemented
            {
                transform.Translate(new Vector2(0, 1));
                GetComponent<AudioSource>().PlayOneShot(jumpAudio);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > myGameManager.levelConstraintBottom)// the "else if" stops the player from being able to move diagonally and pressing multiple directional keys simutainously
            {
                transform.Translate(new Vector2(0, -1));
                GetComponent<AudioSource>().PlayOneShot(jumpAudio);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > myGameManager.levelConstraintLeft)
            {
                transform.Translate(new Vector2(-1, 0));
                GetComponent<AudioSource>().PlayOneShot(jumpAudio);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < myGameManager.levelConstraintRight)
            {
                transform.Translate(new Vector2(1, 0)); // I decided to use the "transform.translate" method as it meant that i was only dealing with vector 2 and i honestly thought it made the code look cleaner
                GetComponent<AudioSource>().PlayOneShot(jumpAudio); //I decided to keep the audio the same pitch as i felt like it was cuter, i was also starting to get pressed for time
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Vehicle>() != null) //this is the collision code for the "highway" section of the game. the vehicle component was chosen as the component as it is the common demoninator amongst all the cars.
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()// this is a function of code that would be used to contain and initialise the code for the player to die, kind of like a tupperware container. 
    {
        GetComponent<AudioSource>().PlayOneShot(hurtAudio);
        playerIsAlive = false;
        playerCanMove = false;
        print("oooof!");
    }
        
        
        
        
 }
