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
    [SerializeField] private float scale;

    [Header("Aggressiveness")]
    [SerializeField] private float health;
    [SerializeField] private float distance;
    [SerializeField] private float infectionTime;

    [Header("Detection")]
    [SerializeField] private float time;
    [SerializeField] private float height;

    [Header("Damage")]
    [SerializeField] private float speed;

    private void Update()
    {
        //MembershipUtility.DrawGamma(transform.position, step, (y) => (1.0f - y) * height, 20, 40);
        //MembershipUtility.DrawTrapezoid(transform.position, step, (y) => y * height, 20, 40, 60, 80);
        //MembershipUtility.DrawGamma(transform.position, step, (y) => y * height, 60, 80);

        //MembershipUtility.DrawGamma(transform.position, step, (y) => (1.0f - y) * height, 1, 3);
        //MembershipUtility.DrawTrapezoid(transform.position, step, (y) => y * height, 1, 3, 6, 8);
        //MembershipUtility.DrawGamma(transform.position, step, (y) => y * height, 6, 8);

        MembershipUtility.DrawGamma(transform.position, step, (y) => (1.0f - y) * height, 16, 24);
        MembershipUtility.DrawTrapezoid(transform.position, step, (y) => y * height, 16, 24, 48, 56);
        MembershipUtility.DrawGamma(transform.position, step, (y) => y * height, 48, 56);

        float aggressiveness = FuzzyAggressiveness.Evaluate2(health, distance, infectionTime);
        //print($"Aggressiveness: {aggressiveness}");

        float damage = FuzzyDamage.Evaluate(aggressiveness, speed);
        print($"Aggressiveness: {aggressiveness}. Damage: {damage}");

        //MembershipUtility.DrawSigmoid(transform.position, step, (y) => (1.0f - y) * scale, 0, 7);
        //MembershipUtility.DrawSigmoid(transform.position, step, (y) => y * scale, 5, 12);
        //MembershipUtility.DrawSigmoid(transform.position, step, (y) => (1.0f - y) * scale, 12, 19);
        //MembershipUtility.DrawSigmoid(transform.position, step, (y) => y * scale, 17, 23);

        //MembershipUtility.DrawGamma(transform.position, step, (y) => (1.0f - y) * scale, 1.0f, 1.2f);
        //MembershipUtility.DrawTrapezoid(transform.position, step, (y) => y * scale, 1.0f, 1.2f, 1.4f, 1.6f);
        //MembershipUtility.DrawGamma(transform.position, step, (y) => y * scale, 1.4f, 1.6f);

        //float detection = FuzzyDetection.Evaluate(time, height);
        //print($"Detection range: {detection}");


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