using UnityEngine;
using System.Collections;

public class CalcError1 : MonoBehaviour
{
		float a, b, c;
		float trueValue1, trueValue2, trueValue3, trueValue4;

		void Start ()
		{
				a = 1234.567f;
				b = 1234.55f;
				c = 0.001f;
				trueValue1 = 2469.117f;
				trueValue2 = 1234.568f;
				trueValue3 = 0.017f;
				trueValue4 = 1234.566f;

				print (string.Format ("①{0}+{1}={2} : 変化率{3:p7}：真値率{4:p}", a, b, a + b, (a + b) / a, (a + b) / trueValue1));
				print (string.Format ("②{0}+{1}={2} : 変化率{3:p7}：真値率{4:p}", a, c, a + c, (a + c) / a, (a + c) / trueValue2));
				print (string.Format ("③{0}-{1}={2} : 変化率{3:p7}：真値率{4:p}", a, b, a - b, (a - b) / a, (a - b) / trueValue3));
				print (string.Format ("④{0}-{1}={2} : 変化率{3:p7}：真値率{4:p}", a, c, a - c, (a - c) / a, (a - c) / trueValue4));
		}
}
