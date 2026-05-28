using UnityEngine;

public static class FuzzyAggressiveness
{
    public static float Evaluate(float health, float distance)
    {
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
        return aggressiveness;
    }
}