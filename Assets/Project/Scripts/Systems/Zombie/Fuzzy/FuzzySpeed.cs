using UnityEngine;

public static class FuzzySpeed
{
    public static float Evaluate(float hunger, float thirst)
    {
        // FUZZIFICACION
        float starving = 1.0f - MembershipFunctions.Gamma(hunger, 10, 20);
        float satisfied = MembershipFunctions.Trapezoid(hunger, 10, 20, 50, 60);
        float full = MembershipFunctions.Gamma(hunger, 50, 60);

        float dehidrated = 1.0f - MembershipFunctions.Gamma(thirst, 10, 30);
        float normal = MembershipFunctions.Trapezoid(thirst, 10, 30, 60, 80);
        float hydrated = MembershipFunctions.Gamma(thirst, 60, 80);

        // REGLAS
        float rule1 = Mathf.Min(starving, dehidrated); // 1
        float rule2 = Mathf.Min(starving, normal); // 10
        float rule3 = Mathf.Min(starving, hydrated); // 20
        float rule4 = Mathf.Min(satisfied, dehidrated); // 50
        float rule5 = Mathf.Min(satisfied, normal); // 60
        float rule6 = Mathf.Min(satisfied, hydrated); // 70
        float rule7 = Mathf.Min(full, dehidrated); // 50
        float rule8 = Mathf.Min(full, normal); // 80
        float rule9 = Mathf.Min(full, hydrated); // 100

        // DEFUZZIFICACION
        float n =
            rule1 * 1 +
            rule2 * 10 +
            rule3 * 20 +
            rule4 * 50 +
            rule5 * 60 +
            rule6 * 70 +
            rule7 * 50 +
            rule8 * 80 +
            rule9 * 100;

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

        float speed = n / d;
        return speed;
    }
}
