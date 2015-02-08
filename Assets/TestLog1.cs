using UnityEngine;
using System.Collections;
using System;

public class TestLog1 : MonoBehaviour
{
		void Start ()
		{
				float value = 0.000012345f;
//				float value = 12345000f;
//				float value = 0.2f;
				float digit = Mathf.FloorToInt (Mathf.Log (value, 100f));		//小数点を基準に10^2毎に区切る
				float value_shift = value * Mathf.Pow (100, -digit);			//桁位置合わせ
				int scale = GetScale (value_shift);		

				//奇数偶数判定
				if (scale % 2 != 0) {
						scale++;		//一番近い大きな偶数に修正して２桁毎に合わせる
				}
				scale /= 2;
				value_shift = value_shift * Mathf.Pow (100, scale);			//桁位置合わせ
				digit -= scale;		

				//小数点を基準に２桁ごとに区切りを入れた値　⇒　PCで計算しやすいように整数範囲へ桁移動させている
				print (string.Format ("{0}　⇒　{1}　　digit:{2} ", value, value_shift, digit));
		}

		/// <summary>
		/// 小数点以下の桁数を取得
		/// </summary>
		private int GetScale (float value)
		{
				string valueString = value.ToString ().TrimEnd ('0');
		
				int index = valueString.IndexOf ('.');
				if (index == -1)
						return 0;
		
				return valueString.Substring (index + 1).Length;
		}
}
