using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private Button switcSceneBtn;

    private void Start ()
    {
        switcSceneBtn.onClick.AddListener(OnClickSwitcScene);
    }
	
	private void Update () {
		
	}

    private void OnClickSwitcScene()
    {
        SceneManager.LoadScene("UIWebView");
    }
}
