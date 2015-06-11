using UnityEngine;
using System.Collections;
using System;
using System.Numerics;

public class SqrtSolve4 : MonoBehaviour
{
		//仕様
		//rootの値は浮動小数点6桁まで指定可
		//digitは求める桁数。基本的に制限なし（BigIntegerの仕様に依存）

		public float root;
		public int digit;
		Square square;

		BigInteger sqrt;					//求めた答えをここに入れている
		BigInteger left, right;
		BigInteger restArea, deltaArea ;	//残されたエリア、平方完成を利用して計算した膨張していく差分エリア
	
		void Start ()
		{
				left = 0;
				sqrt = 0;
				square = GetInteger (root);
				print (string.Format ("{0}　⇒　{1}　　digit:{2} ", root, square.value, square.digit));
				int colum = square.value.ToString ().Length;

				//これから計算する部分をleft
				//計算待ちの部分をrightにしている。計算待ちの部分が無くなったら単純に余りを100倍してleftに入れる仕組みになっている
				//最初の1回目だけ10^2の桁位置合わせの意味で奇数桁数なら1カラム。偶数桁数なら２カラムをleftに割当てるようにしている
				string leftStr, rightStr;
				if (colum % 2 != 0) {
						leftStr = square.value.ToString ().Substring (0, 1);
						rightStr = square.value.ToString ().Substring (1);
				} else {
						leftStr = square.value.ToString ().Substring (0, 2);
						rightStr = square.value.ToString ().Substring (2);
				}

				left = new BigInteger (leftStr);
				if (rightStr.Length == 0) {
						right = 0;
				} else {
						right = new BigInteger (rightStr);
				}

				//積分計算
				for (int i = 0; i < digit; i++) {
						sqrt *= 10;		//平方根側の桁移動
						for (int d = 1; d <= 10; d++) {
								BigInteger hit = left;			//飛出し判定用の捨て変数
			
								deltaArea = d * (sqrt * 2 + d);	//ここで平方完成を利用している、L字の鎌型のエリア
								hit = hit - deltaArea;
								if (hit < 0) {
										//残されたエリアから差分エリアが飛び出したら
										//一歩戻して、残されたエリアから差分エリアを引算する
										deltaArea = (d - 1) * (sqrt * 2 + (d - 1));
										restArea = left - deltaArea;
										sqrt += d - 1;
										break;
								}
						}

						//以下はleft、rightの桁位置調整
						BigInteger remaind = restArea * 100;

						if (right == 0) {
								left = 0;
						} else {
								leftStr = right.ToString ().Substring (0, 2);
								rightStr = right.ToString ().Substring (2);
				
								left = new BigInteger (leftStr);
								if (rightStr.Length == 0) {
										right = 0;
								} else {
										right = new BigInteger (rightStr);
								}
						}
						left += remaind;
				}
				PrintSqrt (sqrt, square.digit);
		}

		//小数点表示処理（内部計算では値を整数で扱っていたので必要）
		void PrintSqrt (BigInteger sqrt, int squareDigit)
		{
				if (squareDigit >= 0) {
						squareDigit++;
						string str = sqrt.ToString ().Insert (squareDigit, ".");
						print (str);
				} else {
						squareDigit = squareDigit * -1 - 1;
				
						string dec = "0.";
						dec = dec.PadRight (2 + squareDigit, '0');
						string str = sqrt.ToString ().Insert (0, dec);
						print (str);
				}
		}

		//小数点の平方根を整数で扱えるようにするための補助クラス
		class Square
		{
				public BigInteger value;
				public int digit;
		}

		//小数点を基準に２桁ごとに区切りを入れた値　⇒　BigIntegerで計算出来るように整数範囲へ桁移動させている
		Square GetInteger (float value)
		{
				int digit = Mathf.FloorToInt (Mathf.Log (value, 100));
				//小数点を基準に10^2毎に区切る
				float value_shift = value * Mathf.Pow (100, -digit);
				//桁位置合わせ
				int scale = GetScale (value_shift);
				//奇数偶数判定
				if (scale % 2 != 0) {
						scale++;
						//一番近い大きな偶数に修正して２桁毎に合わせる
				}
				scale /= 2;
				value_shift = value_shift * Mathf.Pow (100, scale);

				return new Square{value=new BigInteger(value_shift.ToString()),digit=digit};
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
