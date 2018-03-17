using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;
using System;
using SaveGameExtension;

public class ScoreTextManager : MonoBehaviour {
	static float TakeTime = 1.0f;

	// Use this for initialization
	void Start () {
		scoreTextSetting ();
		scoreTextBehavior ();
	}

	// スコアPrefabの表示内容を設定
	void scoreTextSetting () {
		this.GetComponent<Text> ().text = "+" + UserParameter.PlayerYarukiGetQuantity.ToString("N0") + " ";
	}

	// 自身を破棄すると同時に、スコアを加算(scoreTextBehaviorから呼ぶ)
	void destroyScoreText () {
		UserParameter.PlayerYaruki += UserParameter.PlayerYarukiGetQuantity;
		SaveGameEx.SaveGameData();
		Destroy(this.gameObject);
	}
	// スコアPrefabの動きを指定
	void scoreTextBehavior () {
		RectTransform rect = GetComponent<RectTransform> ();
		// 軌道の設定
		Vector3[] path = {
			// 中間地点
			new Vector3(800.0f * UnityEngine.Random.Range(-0.7f, 0.7f),
						400.0f * UnityEngine.Random.Range(0.8f, 1.0f),
						0f),
			// 最終目標点
			new Vector3(0f, 200.0f, 0f),
		};
		// 軌道と反映までかける時間、終了時の挙動の指定
		rect.DOLocalPath (path, TakeTime, PathType.CatmullRom)
			.SetEase (Ease.OutQuad)
			.OnComplete (destroyScoreText);
		rect.DOScale (
			new Vector3 (0.5f, 0.5f, 0f),
			TakeTime
		);
		// 色（alpha）の変化指定
		DOTween.ToAlpha(
			() => this.GetComponent<Text> ().color, // 対象のgetter, 何に入れるか
			color => this.GetComponent<Text> ().color = color, // 対象のsetter, 何を入れるか
			0.3f, // 最終的な値
			TakeTime // アニメーションする時間
		);
	}
}
