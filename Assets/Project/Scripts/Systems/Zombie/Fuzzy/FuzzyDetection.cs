using System.Collections;
using UnityEngine;

public static class FuzzyDetection
{
    public static float Evaluate(float time, float height)
    {
        // Fuzzificacion
        float dark = (1.0f - MembershipFunctions.Sigmoid(time, 0, 7))
            + MembershipFunctions.Sigmoid(time, 17, 24);

        float light1 = MembershipFunctions.Sigmoid(time, 5, 12);
        float light2 = 1.0f - MembershipFunctions.Sigmoid(time, 12, 19);
        float light = (time < 12 ? 0 : light2) 
            + (time >= 12 ? 0 : light1);

        float low = 1.0f - MembershipFunctions.Gamma(height, 1.0f, 1.2f);
        float medium = MembershipFunctions.Trapezoid(height, 1.0f, 1.2f, 1.4f, 1.6f);
        float tall = MembershipFunctions.Gamma(height, 1.4f, 1.6f);

        // Reglas
        float rule1 = Mathf.Min(dark, low); // 1
        float rule2 = Mathf.Min(dark, medium); // 1.5
        float rule3 = Mathf.Min(dark, tall); // 2

        float rule4 = Mathf.Min(light, low); // 6
        float rule5 = Mathf.Min(light, medium); // 8
        float rule6 = Mathf.Min(light, tall); // 10

        // Defuzzificacion
        float n =
            rule1 * 1 +
            rule2 * 1.5f +
            rule3 * 2.0f +
            rule4 * 6 +
            rule5 * 8 +
            rule6 * 10;

        float d =
            rule1 +
            rule2 +
            rule3 +
            rule4 +
            rule5 +
            rule6;

        float detection = n / d;
        return detection;
    }
}