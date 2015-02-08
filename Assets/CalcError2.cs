using UnityEngine;
using System.Collections;

public class CalcError2 : MonoBehaviour
{
		float a, b, trueValue;
	
		void Start ()
		{
				a = 1234.567f;
				b = 1234.55f;

				trueValue = 0.017f;
		
				print (string.Format ("③{0}-{1}={2} : 変化率{3:p7}", a, b, a - b, (a - b) / a));
				print (string.Format ("1÷③^2={0} : 1÷trueValue^2={1}", 1f / ((a - b) * (a - b)), 1f / (trueValue * trueValue)));
		}
}

