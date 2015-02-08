using UnityEngine;
using System.Collections;
using System.Numerics;
using System;

public class SqrtSolve3 : MonoBehaviour
{
		BigInteger sqrt;
		public float root;
		public int digit;
		double calcValue;
		int sqrtDigit;

		void Start ()
		{
				restArea = 0;
				sqrt = 0;
				sqrtDigit = (int)Math.Floor (Math.Log (root, 100f));
				calcValue = root * Math.Pow (100d, -sqrtDigit);

				for (int i = 0; i < digit; i++) {
						sqrt *= 10;		//平方根側の桁移動
						CalcSqrt ();
				}	
				print (sqrt);
		}
		
		double left, right;
		BigInteger  restArea, deltaArea ;	//残されたエリア、平方完成を利用して計算した膨張していく差分エリア

		private void CalcSqrt ()
		{
				left = Math.Floor (calcValue);
				right = calcValue - left;
				restArea += (int)left;

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
}
