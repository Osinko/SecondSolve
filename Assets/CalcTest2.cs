using UnityEngine;
using System.Collections;

public class CalcTest2 : MonoBehaviour
{
		float a, b;
		void Start ()
		{
				print (39d / 321d);
				print (81d / 667d);

				a = 39f / 321f;		//これがある"傾き"を表していた場合・・・
				b = 81f / 667f;
				print (string.Format ("通常の計算方法　：{0}", a - b));
				print (string.Format ("有理数として計算：{0}", ((39f * 667f - 81f * 321f) / (321f * 667f))));
		}
}
