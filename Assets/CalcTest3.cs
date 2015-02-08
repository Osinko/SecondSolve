using UnityEngine;
using System.Collections;
using System;

public class CalcTest3 : MonoBehaviour
{
		void Start ()
		{
				//float計算の場合
				print ("通常計算　　　：" + Mathf.Sqrt (2f - Mathf.Sqrt (4f - 0.05f * 0.05f)));
				print ("有理化した計算：" + 0.05f / Mathf.Sqrt (2f + Mathf.Sqrt (4f - 0.05f * 0.05f)));
		
				//double計算の場合
				print ("通常計算　　　：" + Math.Sqrt (2d - Math.Sqrt (4d - 0.00005d * 0.00005d)));
				print ("有理化した計算：" + 0.00005d / Math.Sqrt (2d + Math.Sqrt (4d - 0.00005d * 0.00005d)));
		}
}
