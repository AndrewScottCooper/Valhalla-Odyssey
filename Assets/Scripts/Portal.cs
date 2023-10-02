using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public int targetScene;
    public bool keyReset = true;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            keyReset = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.GetComponent<SaveSystem>().SaveAllData();
            Debug.Log("Data saved, " + PlayerPrefs.GetInt("SoulsCollected"));
            if (Input.GetButton("Submit"))
            {
                
                NextLevel();
            }

            

        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(targetScene);
    }
}
