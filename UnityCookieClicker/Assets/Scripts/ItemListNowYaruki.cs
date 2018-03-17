using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ItemListNowYaruki : MonoBehaviour {

	// Use this for initialization
	void Start () {
		refreshItemListYarukiText();
	}

	public void refreshItemListYarukiText () {
		this.GetComponent<Text> ().text = " Y: " + UserParameter.PlayerYaruki.ToString("N0");
	}
}
