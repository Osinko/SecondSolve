using UnityEngine;
using System.Collections;
using System;

public class PIsolve1 : MonoBehaviour
{
		int calcLoop;
		double an, pi;

		void Start ()
		{
				calcLoop = 25;
				an = 1d;
				for (int i = 0; i < calcLoop; i++) {
						an = an / (Math.Sqrt (2 + Math.Sqrt (4 - an * an)));
				}
				pi = an * 6d * Math.Pow (2d, calcLoop);	//○角形の辺の数だけ掛算する
				print (pi / 2d);
		}
}
