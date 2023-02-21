using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public float tileSpeed;
    public int tileId;
    public int tileColumnIndex; // 0 for Left, 1 for Center, 2 for Right
    

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * tileSpeed);
        // CheckIfGameLost();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GameLoseLine"){
            FindObjectOfType<GameManager>().GameLost();
        }
    }
    // IEnumerator SelfDestruct(){
    //     yield return new WaitForSeconds(5);
    //     Destroy(gameObject);
    // }
    public void InitializeTileParameters(int lastTileId,int tileColumn,float currentTileSpeed){
        tileId = lastTileId;
        tileColumnIndex = tileColumn;
        tileSpeed = currentTileSpeed;
    }
    
}
