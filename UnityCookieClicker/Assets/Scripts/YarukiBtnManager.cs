using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;
using System;

public class YarukiBtnManager : MonoBehaviour {
	public GameObject canvasGame;
	public GameObject userParameter;
	public GameObject imageYarukiBtn;
	public GameObject scoreTextPrefab;

	public void TapYarukiBtn () {
		YarukiBtnAnimation();
		CriateScoreTextPrefab ();
	}

	private void YarukiBtnAnimation () {
		AnimatorStateInfo stateInfo = imageYarukiBtn.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0);

		if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.YarukiTapAnimation")) {
			imageYarukiBtn.GetComponent<Animator> ().Play (stateInfo.fullPathHash, 0, 0.0f);
		} else {
			imageYarukiBtn.GetComponent<Animator> ().SetTrigger ("TapYarukiBtnAnimation");
		}
	}

	private void CriateScoreTextPrefab () {
		GameObject textScore = (GameObject)Instantiate (scoreTextPrefab);
		textScore.transform.SetParent (canvasGame.transform, false);
		textScore.transform.localPosition = new Vector3(0f, -450.0f, 0f);
	}
}
