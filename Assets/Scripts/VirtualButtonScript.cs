using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour
{
    public VirtualButtonBehaviour vbLeft;
    public VirtualButtonBehaviour vbCenter;
    public VirtualButtonBehaviour vbRight;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        vbLeft.RegisterOnButtonPressed(OnLeftButtonPress);
        vbCenter.RegisterOnButtonPressed(OnCenterButtonPress);
        vbRight.RegisterOnButtonPressed(OnRightButtonPress);
        gameManager = FindObjectOfType<GameManager>();
    }
    public void OnLeftButtonPress(VirtualButtonBehaviour vbLeft){
        CheckTileTapped(0);
        Debug.Log("Left Pressed");
    }
    public void OnCenterButtonPress(VirtualButtonBehaviour vbCenter){
        CheckTileTapped(1);
        Debug.Log("Center Pressed");
    }
    public void OnRightButtonPress(VirtualButtonBehaviour vbRight){
        CheckTileTapped(2);
        Debug.Log("Right Pressed");
    }
    
    void CheckTileTapped(int column){
        if(gameManager.tiles.Count == 0){
            return;
        }
        GameObject tileToBeTapped = gameManager.tiles.Peek();
        TileBehavior currentTileBehavior = tileToBeTapped.GetComponent<TileBehavior>();
        if(currentTileBehavior.tileColumnIndex == column){
            gameManager.TileTapped();
        }else{
            gameManager.GameLost();
        }
    }
}
