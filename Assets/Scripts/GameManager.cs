using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Game States
    bool surfaceFound = false;
    bool gameStart = false;
    public bool gameLost = false;

    // UI
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject surfaceMenu;
    [SerializeField] GameObject gameOverMenu;

    // Game Objects
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject tileSpawner;

    // Game Variables
    int numTiles;
    int lastTileId;
    GameObject tileToBeTapped;
    public Queue<GameObject> tiles = new Queue<GameObject>();
    int score;
    public float initalTileSpeed = 0.1f;
    float currentTileSpeed;
    
    [SerializeField] int scoreIncrement = 5;
    [SerializeField] float spawnTimeInterval = 2;

    void Awake(){
        gameStart = false;
        surfaceFound = false;
        gameLost = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLost){
            GameLost();
        }
    }

    public void OnSurfaceFound(){
        if(!gameStart){
            // Debug.Log("Surface Found");
            surfaceFound = true;
            surfaceMenu.gameObject.SetActive(false);
            startMenu.gameObject.SetActive(true);
        }
    }

    public void OnStartButtonTap(){
        gameStart = true;
        score = 0;
        numTiles = 20;
        lastTileId = 0;
        currentTileSpeed = initalTileSpeed;
        StartCoroutine("spawnTiles");
        startMenu.gameObject.SetActive(false);
    }
    public void OnPlayAgainTap(){
        // Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameLost(){
        gameLost = true;
        gameStart = false;
        StopAllCoroutines();
        // Time.timeScale = 0;
        
        gameOverMenu.SetActive(true);
    }


    IEnumerator spawnTiles(){
        while(true){
            int tileColumnIndex = Random.Range(0,3);
            GameObject tileSpawnLocationObject = tileSpawner.transform.GetChild(tileColumnIndex).gameObject;
            Vector3 spawnLocation = tileSpawnLocationObject.transform.position;
            GameObject newTile = Instantiate(tilePrefab, new Vector3(spawnLocation.x,spawnLocation.y,spawnLocation.z), Quaternion.identity,tileSpawnLocationObject.transform);
            currentTileSpeed += 0.01f;
            if(spawnTimeInterval>0.5){
                spawnTimeInterval -= 0.1f;
            }
            
            newTile.GetComponent<TileBehavior>().InitializeTileParameters(lastTileId,tileColumnIndex,currentTileSpeed);
            tiles.Enqueue(newTile);
            lastTileId++;

            yield return new WaitForSeconds(spawnTimeInterval);   
            if(lastTileId==numTiles){
                break;
            }
        }
    }
    public void TileTapped(){
        GameObject tileTapped = tiles.Dequeue();
        Destroy(tileTapped);
        score+=scoreIncrement;
        Debug.Log(score);
    }
}
