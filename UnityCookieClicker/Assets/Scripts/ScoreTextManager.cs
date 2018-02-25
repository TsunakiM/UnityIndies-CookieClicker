using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;
using System;

public class ScoreTextManager : MonoBehaviour {
	static float TakeTime = 1.0f;

	// Use this for initialization
	void Start () {
		scoreTextSetting ();
		scoreTextBehavior ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void scoreTextSetting () {
		this.GetComponent<Text> ().text = "+" + UserParameter.PlayerYarukiGetQuantity.ToString("N0") + " ";
	}

	void destroyScoreText () {
		UserParameter.PlayerYaruki += UserParameter.PlayerYarukiGetQuantity;
		Destroy(this.gameObject);
	}

	void scoreTextBehavior () {
		RectTransform rect = GetComponent<RectTransform> ();

		Vector3[] path = {
			// 中間地点
			new Vector3(800.0f * UnityEngine.Random.Range(-0.7f, 0.7f),
						400.0f * UnityEngine.Random.Range(0.8f, 1.0f),
						0f),
			// 最終目標点
			new Vector3(0f, 200.0f, 0f),
		};

		rect.DOLocalPath (path, TakeTime, PathType.CatmullRom)
			.SetEase (Ease.OutQuad)
			.OnComplete (destroyScoreText);
		rect.DOScale (
			new Vector3 (0.5f, 0.5f, 0f),
			TakeTime
		);
		DOTween.ToAlpha(
			() => this.GetComponent<Text> ().color, // 対象のgetter, 何に入れるか
			color => this.GetComponent<Text> ().color = color, // 対象のsetter, 何を入れるか
			0.3f, // 最終的な値
			TakeTime // アニメーションする時間
		);
	}
}
