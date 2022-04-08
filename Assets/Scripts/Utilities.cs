using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static int score = 0;

    // Update is called once per frame
    void Update()
    {
        // Quit on Escape
        if (Input.GetKey("escape")) {
            Application.Quit();
        }

        // Reset scene on R
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Instantiate Ball on B
        if(Input.GetKeyDown(KeyCode.B)){
            Instantiate(BallPrefab, Position, Quaternion.identity);
        }

        // Instantiate 100 Balls on H
        if(Input.GetKeyDown(KeyCode.H)){
            for(int i = 0; i < 80; i++){
                Vector3 offset = new Vector3(Random.Range(-5f, 0f), 0, Random.Range(-1f, 1f));
                Instantiate(BallPrefab, Position + offset, Quaternion.identity);
            }
        }
    }

    // Testing score
    private void FixedUpdate(){
        score++;
    }
}
