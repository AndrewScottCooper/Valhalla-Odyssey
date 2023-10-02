using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.UI;
public class MainMenu : MonoBehaviour
{

    public CanvasGroup mainGroup;
    public CanvasGroup aboutGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(3);
    }
    public void OnAboutClicked()
    {
        showhideMainPanel();
        showHideAboutGroup();
    }

    void showhideMainPanel()
    {

        mainGroup.gameObject.SetActive(!mainGroup.gameObject.activeSelf);
    }
    void showHideAboutGroup()
    {

        aboutGroup.gameObject.SetActive(!aboutGroup.gameObject.activeSelf);
    }

}
