using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtension {
	// 上限値
	public const int UPPER_LIMIT = 999999999;
	// 下限値
	public const int LOWER_LIMIT = 0;

	///<summary>
	/// Int同士の加算時に、加算予定の値につけて下限・上限を超えないかチェック。
	///<param name="baseVariable">加算される元の値</param>
	///<example> 
	///<code>
	///	willAddInt.AddIntAndIntLimitCheck(BaseInt);
	///</code>
	///</example>
	///</summary>
	public static int AddIntAndIntLimitCheck(this int _willAdd, int baseVariable) {
		int checkedNum;
		// 加算する二値が上限値より大きい場合、上限値で上書きする。
		if (_willAdd + baseVariable > UPPER_LIMIT) {
			checkedNum = UPPER_LIMIT;
		// 二値の和が下限値未満になる場合、下限値で上書きする。
		} else if (_willAdd + baseVariable < LOWER_LIMIT) {
			checkedNum = LOWER_LIMIT;
		// 問題がなければ、二値の和をそのまま返す。
		} else {
			checkedNum = _willAdd + baseVariable;
		}
		return checkedNum;
	}
}
