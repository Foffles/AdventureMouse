using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (levelToLoad == "Dungeon_Rand")
            {
                SceneManager.LoadScene(levelToLoad + "_" + Random.Range(1, 4));
            }
            else
            {
                SceneManager.LoadScene(levelToLoad);
            }
            
        }
    }
}
