using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour
{
    [SerializeField] string LevelName;

	public void LoadScene(string LevelName)
    {
       
            SceneManager.LoadScene(LevelName);
        
    }
	
}
