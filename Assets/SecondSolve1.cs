using UnityEngine;
using System.Collections;

public class SecondSolve1 : MonoBehaviour
{
		public int root;	//平方数
		public int  digit;	//計算させる桁数
		decimal sqrt;		//答えとなる平方根

		decimal  restArea, deltaArea ;	//残されたエリア、平方完成を利用して計算した膨張していく差分エリア

		//現時点、小数点表現を抜いた27桁まで表示できる
		void Start ()
		{
				sqrt = 0;
				restArea = root;

				for (int i = 0; i < digit; i++) {
						sqrt *= 10;		//平方根側の桁移動
						for (int d = 1; d <= 10; d++) {
								decimal hit = restArea;			//飛出し判定用の捨て変数
				
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
}