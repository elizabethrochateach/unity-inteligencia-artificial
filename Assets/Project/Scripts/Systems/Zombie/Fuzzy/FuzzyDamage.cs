using System.Collections;
using UnityEngine;


public static class FuzzyDamage
{
    public static float Evaluate(float aggressiveness, float speed)
    {
        // FUZZIFICACION
        float lowAggressiveness = 1.0f - MembershipFunctions.Gamma(aggressiveness, 20, 30);
        float midAggressiveness = MembershipFunctions.Trapezoid(aggressiveness, 20, 30, 60, 70);
        float highAggressiveness = MembershipFunctions.Gamma(aggressiveness, 60, 70);

        float lowSpeed = 1.0f - MembershipFunctions.Gamma(speed, 30, 40);
        float midSpeed = MembershipFunctions.Trapezoid(speed, 30, 40, 70, 80);
        float highSpeed = MembershipFunctions.Gamma(speed, 70, 80);

        // REGLAS
        float rule1 = Mathf.Min(lowAggressiveness, lowSpeed); // 10
        float rule2 = Mathf.Min(lowAggressiveness, midSpeed); // 20
        float rule3 = Mathf.Min(lowAggressiveness, highSpeed); // 30
        float rule4 = Mathf.Min(midAggressiveness, lowSpeed); // 20
        float rule5 = Mathf.Min(midAggressiveness, midSpeed); // 30
        float rule6 = Mathf.Min(midAggressiveness, highSpeed); // 40
        float rule7 = Mathf.Min(highAggressiveness, lowSpeed); // 30
        float rule8 = Mathf.Min(highAggressiveness, midSpeed); // 40
        float rule9 = Mathf.Min(highAggressiveness, highSpeed); // 50

        // DEFUZZIFICACION
        float n =
            rule1 * 10 +
            rule2 * 20 +
            rule3 * 30 +
            rule4 * 20 +
            rule5 * 30 +
            rule6 * 40 +
            rule7 * 30 +
            rule8 * 40 +
            rule9 * 50;

        float d =
            rule1 +
            rule2 +
            rule3 +
            rule4 +
            rule5 +
            rule6 +
            rule7 +
            rule8 +
            rule9;

        float damage = n / d;
        return damage;
    }
}