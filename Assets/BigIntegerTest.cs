using UnityEngine;
using System.Collections;
using System.Numerics;

public class BigIntegerTest : MonoBehaviour
{
		void Start ()
		{
				BigInteger a = new BigInteger (25);
				a = a + 100;
					
				BigInteger b = new BigInteger ("139435810094598308945890230913");
					
				BigInteger c = b / a;
				BigInteger d = b % a;
					
				BigInteger e = (c * a) + d;

				print (a);
				print (b);
				print (c);
				print (d);
				print (e);
		
				if (e != b) {
						print ("真ではない");
				}
		}
}
