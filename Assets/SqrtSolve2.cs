using UnityEngine;
using System.Collections;
using System.Numerics;

public class SqrtSolve2 : MonoBehaviour
{
		public float root;		//平方数
		public int digit;		//計算させる桁数
		public int shiftRoot;	//1.○○*10^nに調整した平方数
		public int shiftDigit;	//移動した桁数(n)
		BigInteger sqrt;		//答えとなる平方根
	
		BigInteger  restArea, deltaArea ;	//残されたエリア、平方完成を利用して計算した膨張していく差分エリア
	
		//現時点、小数点表現を抜いた27桁まで表示できる
		void Start ()
		{
				RootShift (root, out shiftRoot, out shiftDigit);
				//小数点を基準に２桁ごとに区切りを入れた値　⇒　PCで計算しやすいように整数範囲へ桁移動させている
				print (string.Format ("{0}　⇒　{1}　　digit:{2} ", root, shiftRoot, shiftDigit));
		
				sqrt = 0;
				restArea = shiftRoot;
		
				for (int i = 0; i < digit; i++) {
						sqrt *= 10;		//平方根側の桁移動
						for (int d = 1; d <= 10; d++) {
								BigInteger hit = restArea;			//飛出し判定用の捨て変数
				
								deltaArea = d * (sqrt * 2 + d);	//ここで平方完成を利用している、L字の鎌型のエリア
								hit = hit - deltaArea;
								if (hit < 0) {
										//残されたエリアから差分エリアが飛び出したら
										//一歩戻して、残されたエリアから差分エリアを引算する
										deltaArea = (d - 1) * (sqrt * 2 + (d - 1));
										restArea = restArea - deltaArea;
										sqrt += d - 1;
										break;
								}
						}
						//桁を移動させながら計算はより細かく密になっていく
						restArea *= 100;
				}
				print (sqrt);
		}
	
		public void RootShift (float root, out int shiftRoot, out int shiftDigit)
		{
				int digit = Mathf.FloorToInt (Mathf.Log (root, 100f));		//小数点を基準に10^2毎に区切る
				float value_shift = root * Mathf.Pow (100, -digit);			//桁位置合わせ
				int scale = GetScale (value_shift);		
		
				//奇数偶数判定
				if (scale % 2 != 0) {
						scale++;		//一番近い大きな偶数に修正して２桁毎に合わせる
				}
				scale /= 2;
				value_shift = value_shift * Mathf.Pow (100, scale);			//桁位置合わせ
				digit -= scale;		
		
				shiftRoot = (int)value_shift;
				shiftDigit = digit;
		}
	
		/// <summary>
		/// 小数点以下の桁数を取得
		/// </summary>
		public int GetScale (float value)
		{
				string valueString = value.ToString ().TrimEnd ('0');
		
				int index = valueString.IndexOf ('.');
				if (index == -1)
						return 0;
		
				return valueString.Substring (index + 1).Length;
		}
}