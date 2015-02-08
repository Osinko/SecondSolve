using UnityEngine;
using System.Collections;

public class CalcTest1 : MonoBehaviour
{
		double an, ann;
		void Start ()
		{
				an = 355d / 113d;
				ann = 333d / 106d;
				print (an);
				print (ann);
				print (an - ann);
		}
}
