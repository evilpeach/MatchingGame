using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty_receiver : MonoBehaviour {

    int difficulty_ = 0;

    public void setDifficulty(int difficulty)
    {
        difficulty_ = difficulty;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Difficulty = " + difficulty_.ToString())) ;
    }
}
