using System.Collections;
using UnityEngine;


public class FuzzyTesting : MonoBehaviour
{
    [Header("Gamma")]
    [SerializeField] private float gammaA;
    [SerializeField] private float gammaM;
    [SerializeField] private float gammaS;
    [SerializeField] private bool showGamma;

    [Header("Triangular")]
    [SerializeField] private float triangularA;
    [SerializeField] private float triangularM;
    [SerializeField] private float triangularB;
    [SerializeField] private float triangularS;
    [SerializeField] private bool showTriangular;

    [Header("Trapezoid")]
    [SerializeField] private float trapezoidA;
    [SerializeField] private float trapezoidB;
    [SerializeField] private float trapezoidC;
    [SerializeField] private float trapezoidD;
    [SerializeField] private float trapezoidS;
    [SerializeField] private bool showTrapezoid;

    private void Update()
    {
        if(showGamma && gammaS > 0)
        {
            for (float x = gammaA - 1; x <= gammaM + 1; x += gammaS)
            {
                float y1 = Membership.Gamma(x, gammaA, gammaM);
                float y2 = Membership.Gamma(x + gammaS, gammaA, gammaM);
                Debug.DrawLine(
                    transform.position + new Vector3(x, y1, 0),
                    transform.position + new Vector3(x + gammaS, y2, 0),
                    Color.red);
            }
        }

        if(showTriangular && triangularS > 0)
        {
            for(float x = triangularA - 1; x <= triangularB + 1; x += triangularS)
            {
                float y1 = Membership.Triangular(x, triangularA, triangularM, triangularB);
                float y2 = Membership.Triangular(x + triangularS, triangularA, triangularM, triangularB);
                Debug.DrawLine(
                    transform.position + new Vector3(x, y1, 0),
                    transform.position + new Vector3(x + triangularS, y2, 0),
                    Color.green);
            }
        }

        if(showTrapezoid && trapezoidS > 0)
        {
            for(float x = trapezoidA - 1; x <= trapezoidD + 1; x += trapezoidS)
            {
                float y1 = Membership.Trapezoid(x, trapezoidA, trapezoidB, trapezoidC, trapezoidD);
                float y2 = Membership.Trapezoid(x + trapezoidS, trapezoidA, trapezoidB, trapezoidC, trapezoidD);
                Debug.DrawLine(
                    transform.position + new Vector3(x, y1, 0),
                    transform.position + new Vector3(x + trapezoidS, y2, 0),
                    Color.yellow);
            }
        }
    }
}