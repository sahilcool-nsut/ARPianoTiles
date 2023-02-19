using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonScript : MonoBehaviour
{
    public VirtualButtonBehaviour vbLeft;
    public VirtualButtonBehaviour vbCenter;
    public VirtualButtonBehaviour vbRight;

    // Start is called before the first frame update
    void Start()
    {
        vbLeft.RegisterOnButtonPressed(OnLeftButtonPress);
        vbCenter.RegisterOnButtonPressed(OnCenterButtonPress);
        vbRight.RegisterOnButtonPressed(OnRightButtonPress);

    }
    public void OnLeftButtonPress(VirtualButtonBehaviour vbLeft){
        Debug.Log("Left Pressed");
    }
    public void OnCenterButtonPress(VirtualButtonBehaviour vbCenter){
        Debug.Log("Center Pressed");
    }
    public void OnRightButtonPress(VirtualButtonBehaviour vbRight){
        Debug.Log("Right Pressed");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
