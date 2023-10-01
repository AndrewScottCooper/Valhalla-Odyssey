using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public string targetScene;
    public bool keyReset = true;

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
        if (collision.GetComponent<Rigidbody2D>().CompareTag("Player"))
        {
            if (Input.GetButton("Submit"))
            {
                NextLevel();
            }

            

        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(targetScene);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(targetScene));
    }
}