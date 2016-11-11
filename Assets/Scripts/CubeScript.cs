using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ToggleVRMode()
    {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }

    public void OnGazeEnter()
    {
        CubeColorChange(Color.red);
    }

    public void OnGazeExit()
    {
        CubeColorChange(Color.green);
    }

    public void OnGazeClicked()
    {
        CubeColorChange(Color.blue);
    }

    public void ResetColor()
    {
        CubeColorChange(Color.clear);
    }

    public void SetToCyan()
    {
        CubeColorChange(Color.cyan);
    }
    void CubeColorChange(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
