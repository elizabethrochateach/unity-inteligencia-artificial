using System.Collections;
using UnityEngine;


public class FuzzyTesting : MonoBehaviour
{
    //[Header("Gamma")]
    //[SerializeField] private float gammaA;
    //[SerializeField] private float gammaM;
    //[SerializeField] private float gammaS;
    //[SerializeField] private bool showGamma;

    //[Header("Triangular")]
    //[SerializeField] private float triangularA;
    //[SerializeField] private float triangularM;
    //[SerializeField] private float triangularB;
    //[SerializeField] private float triangularS;
    //[SerializeField] private bool showTriangular;

    //[Header("Trapezoid")]
    //[SerializeField] private float trapezoidA;
    //[SerializeField] private float trapezoidB;
    //[SerializeField] private float trapezoidC;
    //[SerializeField] private float trapezoidD;
    //[SerializeField] private float trapezoidS;
    //[SerializeField] private bool showTrapezoid;

    //[Header("Sigmoid")]
    //[SerializeField] private float sigmoidA;
    //[SerializeField] private float sigmoidC;
    //[SerializeField] private float sigmoidS;
    //[SerializeField] private bool showSigmoid;

    [SerializeField] private float step;
    [SerializeField] private float height;

    [SerializeField] private float health;
    [SerializeField] private float distance;

    private void Update()
    {
        MembershipUtility.DrawGamma(transform.position, step, (y) => (1.0f - y) * height, 20, 40);
        MembershipUtility.DrawTrapezoid(transform.position, step, (y) => y * height, 20, 40, 60, 80);
        MembershipUtility.DrawGamma(transform.position, step, (y) => y * height, 60, 80);

        MembershipUtility.DrawGamma(transform.position, step, (y) => (1.0f - y) * height, 1, 3);
        MembershipUtility.DrawTrapezoid(transform.position, step, (y) => y * height, 1, 3, 6, 8);
        MembershipUtility.DrawGamma(transform.position, step, (y) => y * height, 6, 8);

        // Fuzzificacion (Grado de pertenencia)
        float lowHealth = 1.0f - MembershipFunctions.Gamma(health, 20, 40);
        float midHealth = MembershipFunctions.Trapezoid(health, 20, 40, 60, 80);
        float highHealth = MembershipFunctions.Gamma(health, 60, 80);

        float closeDistance = 1.0f - MembershipFunctions.Gamma(distance, 1, 3);
        float midDistance = MembershipFunctions.Trapezoid(distance, 1, 3, 6, 8);
        float farDistance = MembershipFunctions.Gamma(distance, 6, 8);

        // Reglas difusas
        float rule1 = Mathf.Min(lowHealth, closeDistance); // 5
        float rule2 = Mathf.Min(lowHealth, midDistance); // 2.5
        float rule3 = Mathf.Min(lowHealth, farDistance); // 1

        float rule4 = Mathf.Min(midHealth, closeDistance); // 40
        float rule5 = Mathf.Min(midHealth, midDistance); // 30
        float rule6 = Mathf.Min(midHealth, farDistance); // 20

        float rule7 = Mathf.Min(highHealth, closeDistance); // 100
        float rule8 = Mathf.Min(highHealth, midDistance); // 80
        float rule9 = Mathf.Min(highHealth, farDistance); // 60

        // Defuzzificacion (n1 / d1)
        float n1 =
            rule1 * 5 +
            rule2 * 2.5f +
            rule3 * 1 +
            rule4 * 40 +
            rule5 * 30 +
            rule6 * 20 +
            rule7 * 100 +
            rule8 * 80 +
            rule9 * 60;

        float d1 =
            rule1 +
            rule2 +
            rule3 +
            rule4 +
            rule5 +
            rule6 +
            rule7 +
            rule8 +
            rule9;

        float aggressiveness = n1 / d1;
        print($"Agresividad: {aggressiveness}");


        

        //    if(showGamma && gammaS > 0)
        //    {
        //        for (float x = gammaA - 1; x <= gammaM + 1; x += gammaS)
        //        {
        //            float y1 = MembershipFunctions.Gamma(x, gammaA, gammaM);
        //            float y2 = MembershipFunctions.Gamma(x + gammaS, gammaA, gammaM);
        //            Debug.DrawLine(
        //                transform.position + new Vector3(x, y1, 0),
        //                transform.position + new Vector3(x + gammaS, y2, 0),
        //                Color.red);
        //        }
        //    }

        //    if(showTriangular && triangularS > 0)
        //    {
        //        for(float x = triangularA - 1; x <= triangularB + 1; x += triangularS)
        //        {
        //            float y1 = MembershipFunctions.Triangular(x, triangularA, triangularM, triangularB);
        //            float y2 = MembershipFunctions.Triangular(x + triangularS, triangularA, triangularM, triangularB);
        //            Debug.DrawLine(
        //                transform.position + new Vector3(x, y1, 0),
        //                transform.position + new Vector3(x + triangularS, y2, 0),
        //                Color.green);
        //        }
        //    }

        //    if(showTrapezoid && trapezoidS > 0)
        //    {
        //        for(float x = trapezoidA - 1; x <= trapezoidD + 1; x += trapezoidS)
        //        {
        //            float y1 = MembershipFunctions.Trapezoid(x, trapezoidA, trapezoidB, trapezoidC, trapezoidD);
        //            float y2 = MembershipFunctions.Trapezoid(x + trapezoidS, trapezoidA, trapezoidB, trapezoidC, trapezoidD);
        //            Debug.DrawLine(
        //                transform.position + new Vector3(x, y1, 0),
        //                transform.position + new Vector3(x + trapezoidS, y2, 0),
        //                Color.yellow);
        //        }
        //    }

        //    if (showSigmoid && sigmoidS > 0)
        //    {
        //        for (float x = sigmoidA - 1; x <= sigmoidC + 1; x += sigmoidS)
        //        {
        //            float y1 = MembershipFunctions.Sigmoid(x, sigmoidA, sigmoidC);
        //            float y2 = MembershipFunctions.Sigmoid(x + sigmoidS, sigmoidA, sigmoidC);
        //            Debug.DrawLine(
        //                transform.position + new Vector3(x, y1, 0),
        //                transform.position + new Vector3(x + sigmoidS, y2, 0),
        //                Color.cyan);
        //        }
        //    }
        //}
    }
}