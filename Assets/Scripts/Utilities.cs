using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Utilities : MonoBehaviour
{
    // This code block makes Utilites a Singleton
    public static Utilities Instance { get; private set; }
    private void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } 
        else { 
            Instance = this; 
        } 
    }

    [SerializeField] GameObject BallPrefab;
    [SerializeField] Vector3 Position;
    [SerializeField] Text GameOverText;
    public static int hitCount = 0;

    private static int score = 0;
    public static int Score {
        get{
            return score;
        }
        set{
            int prevScore = score;
            score = value;
            if (score/1000 != prevScore/1000){
                Instance.spawnBall();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Quit on Escape
        // if (Input.GetKey("escape")) {
        //     Application.Quit();
        // }

        // Reset scene on R
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Score = 0;
            hitCount = 0;
        }

        // Instantiate Ball on B
        if(Input.GetKeyDown(KeyCode.B)){
            spawnBall();
        }

        // Instantiate 100 Balls on H
        if(Input.GetKeyDown(KeyCode.H)){
            for(int i = 0; i < 80; i++){
                Vector3 offset = new Vector3(Random.Range(-5f, 0f), 0, Random.Range(-1f, 1f));
                Instantiate(BallPrefab, Position + offset, Quaternion.identity);
            }
        }

        // End game if all balls be gone
        if(GameObject.FindGameObjectWithTag("Ball") == null){
            // print("Game Over!");
            GameOver();
        }
    }

    private void spawnBall(){
        Instantiate(BallPrefab, Position, Quaternion.identity);
    }

    private void GameOver(){
        GameOverText.gameObject.SetActive(true);
    }

    // Testing score
    // private void FixedUpdate(){
    //     score++;
    // }
}
