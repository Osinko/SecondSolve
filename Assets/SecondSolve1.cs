using UnityEngine;
using System.Collections;

public class SecondSolve1 : MonoBehaviour
{
		public int root;
		public int  digit;
		decimal sqrt;
		decimal  deltaArea, restArea;

		//現時点、小数点表現を抜いた27桁まで表示できる
		void Start ()
		{
				sqrt = 0;
				restArea = root;

				for (int i = 0; i < digit; i++) {
						sqrt *= 10;
						for (int d = 1; d <= 10; d++) {
								decimal hit = restArea;
				
								deltaArea = d * (sqrt * 2 + d);
								hit = hit - deltaArea;
								if (hit < 0) {
										deltaArea = (d - 1) * (sqrt * 2 + (d - 1));
										restArea = restArea - deltaArea;
										sqrt += d - 1;
										break;
								}
						}
						restArea *= 100;
				}
				print (sqrt);
		}
}