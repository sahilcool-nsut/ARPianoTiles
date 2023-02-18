using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    bool surfaceFound = false;
    bool gameStart = false;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject surfaceMenu;
    [SerializeField] GameObject tile;
    [SerializeField] GameObject tileSpawner;
    void Awake(){
        gameStart = false;
        surfaceFound = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSurfaceFound(){
        // if(!gameStart){
            Debug.Log("Surface Found");
            surfaceFound = true;
            surfaceMenu.gameObject.SetActive(false);
            startMenu.gameObject.SetActive(true);
        // }
    }

    public void OnStartButtonTap(){
        gameStart = true;
        StartCoroutine("spawnTiles");
        startMenu.gameObject.SetActive(false);
    }
    IEnumerator spawnTiles(){
        int i = 0;
        while(true){
            GameObject tileSpawnLocationObject = tileSpawner.transform.GetChild((i%4)).gameObject;
            Vector3 spawnLocation = tileSpawnLocationObject.transform.localPosition;
            Instantiate(tile, new Vector3(spawnLocation.x,spawnLocation.y,spawnLocation.y), Quaternion.identity,tileSpawnLocationObject.transform);
            i++;
            yield return new WaitForSeconds(1);   
            if(i==10){
                break;
            }
        }
    }
}
