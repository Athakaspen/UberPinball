using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{

    [SerializeField] GameObject BallPrefab;
    [SerializeField] Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
