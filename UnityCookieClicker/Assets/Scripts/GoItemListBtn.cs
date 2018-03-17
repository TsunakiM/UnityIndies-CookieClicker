using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoItemListBtn : MonoBehaviour {
	GameObject gameManager;
	void Start () {
		gameManager = GameObject.Find("GameManager");
	}
	public void goItemList () {
		SceneManager.LoadScene("ItemListScenes");
	}
}
