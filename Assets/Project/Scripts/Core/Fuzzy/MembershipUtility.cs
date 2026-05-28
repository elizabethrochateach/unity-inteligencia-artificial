using System;
using UnityEngine;

public static class MembershipUtility
{
    public delegate float MembershipEvaluation(float y);

    public static void DrawGamma(Vector3 origin, float s, MembershipEvaluation evaluate, 
        float a, float m)
    {
        if (s <= 0)
            return;

        for (float x = a - 1; x <= m + 1; x += s)
        {
            float y1 = evaluate(MembershipFunctions.Gamma(x, a, m));
            float y2 = evaluate(MembershipFunctions.Gamma(x + s, a, m));
            Debug.DrawLine(
                origin + new Vector3(x, y1, 0),
                origin + new Vector3(x + s, y2, 0),
                Color.red);
        }
    }

    public static void DrawTriangular(Vector3 origin, float s, MembershipEvaluation evaluate,
        float a, float m, float b)
    {
        if (s <= 0)
            return;

        for (float x = a - 1; x <= b + 1; x += s)
        {
            float y1 = evaluate(MembershipFunctions.Triangular(x, a, m, b));
            float y2 = evaluate(MembershipFunctions.Triangular(x + s, a, m, b));
            Debug.DrawLine(
                origin + new Vector3(x, y1, 0),
                origin + new Vector3(x + s, y2, 0),
                Color.green);
        }
    }

    public static void DrawTrapezoid(Vector3 origin, float s, MembershipEvaluation evaluate,
        float a, float b, float c, float d)
    {
        if (s <= 0)
            return;

        for (float x = a - 1; x <= d + 1; x += s)
        {
            float y1 = evaluate(MembershipFunctions.Trapezoid(x, a, b, c, d));
            float y2 = evaluate(MembershipFunctions.Trapezoid(x + s, a, b, c, d));
            Debug.DrawLine(
                origin + new Vector3(x, y1, 0),
                origin + new Vector3(x + s, y2, 0),
                Color.yellow);
        }
    }

    public static void DrawSigmoid(Vector3 origin, float s, MembershipEvaluation evaluate,
        float a, float c)
    {

        for (float x = a - 1; x <= c + 1; x += s)
        {
            float y1 = evaluate(MembershipFunctions.Sigmoid(x, a, c));
            float y2 = evaluate(MembershipFunctions.Sigmoid(x + s, a, c));
            Debug.DrawLine(
                origin + new Vector3(x, y1, 0),
                origin + new Vector3(x + s, y2, 0),
                Color.cyan);
        }
    }
}