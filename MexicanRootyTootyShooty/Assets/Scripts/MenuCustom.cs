using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCustom : MonoBehaviour {
    
	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Run the level next in this list
    }

    public void QuitGame()
    {
        Debug.Log("HELLO");
        Application.Quit();
    }
}
