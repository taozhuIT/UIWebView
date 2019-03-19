using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour

{
    [SerializeField] private Button showBtn;
    [SerializeField] private GameObject panel;

	void Start ()
    {
        showBtn.onClick.AddListener(OnShowPanel);
    }
	
	void Update () {
		
	}

    private void OnShowPanel()
    {
        panel.SetActive(true);
    }
}
