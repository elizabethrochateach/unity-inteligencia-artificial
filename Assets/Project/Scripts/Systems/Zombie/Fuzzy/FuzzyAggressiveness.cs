using UnityEngine;

public static class FuzzyAggressiveness
{
    public static float Evaluate(float health, float distance, float infectionTime)
    {
        // Fuzzificacion (Grado de pertenencia)
        float lowHealth = 1.0f - MembershipFunctions.Gamma(health, 20, 40);
        float midHealth = MembershipFunctions.Trapezoid(health, 20, 40, 60, 80);
        float highHealth = MembershipFunctions.Gamma(health, 60, 80);

        float closeDistance = 1.0f - MembershipFunctions.Gamma(distance, 1, 3);
        float midDistance = MembershipFunctions.Trapezoid(distance, 1, 3, 6, 8);
        float farDistance = MembershipFunctions.Gamma(distance, 6, 8);

        float shortInfection = 1.0f - MembershipFunctions.Gamma(infectionTime, 16, 24);
        float midInfection = MembershipFunctions.Trapezoid(infectionTime, 16, 24, 48, 56);
        float longInfection = MembershipFunctions.Gamma(infectionTime, 48, 56);

        // Reglas difusas
        float rule1 = Mathf.Min(lowHealth, closeDistance, shortInfection); // 5
        float rule2 = Mathf.Min(lowHealth, closeDistance, midInfection); // 10
        float rule3 = Mathf.Min(lowHealth, closeDistance, longInfection); // 20

        float rule4 = Mathf.Min(lowHealth, midDistance, shortInfection); // 2
        float rule5 = Mathf.Min(lowHealth, midDistance, midInfection); // 5
        float rule6 = Mathf.Min(lowHealth, midDistance, longInfection); // 10

        float rule7 = Mathf.Min(lowHealth, farDistance, shortInfection); // 1
        float rule8 = Mathf.Min(lowHealth, farDistance, midInfection); // 2
        float rule9 = Mathf.Min(lowHealth, farDistance, longInfection); // 5

        float rule10 = Mathf.Min(midHealth, closeDistance, shortInfection); // 25
        float rule11 = Mathf.Min(midHealth, closeDistance, midInfection); // 35
        float rule12 = Mathf.Min(midHealth, closeDistance, longInfection); // 50

        float rule13 = Mathf.Min(midHealth, midDistance, shortInfection); // 20
        float rule14 = Mathf.Min(midHealth, midDistance, midInfection); // 25
        float rule15 = Mathf.Min(midHealth, midDistance, longInfection); // 35

        float rule16 = Mathf.Min(midHealth, farDistance, shortInfection); // 15
        float rule17 = Mathf.Min(midHealth, farDistance, midInfection); // 20
        float rule18 = Mathf.Min(midHealth, farDistance, longInfection); // 25

        float rule19 = Mathf.Min(highHealth, closeDistance, shortInfection); // 80
        float rule20 = Mathf.Min(highHealth, closeDistance, midInfection); // 90
        float rule21 = Mathf.Min(highHealth, closeDistance, longInfection); // 100

        float rule22 = Mathf.Min(highHealth, midDistance, shortInfection); // 50
        float rule23 = Mathf.Min(highHealth, midDistance, midInfection); // 65
        float rule24 = Mathf.Min(highHealth, midDistance, longInfection); // 80

        float rule25 = Mathf.Min(highHealth, farDistance, shortInfection); // 40
        float rule26 = Mathf.Min(highHealth, farDistance, midInfection); // 50
        float rule27 = Mathf.Min(highHealth, farDistance, longInfection); // 65

        // Defuzzificacion (n1 / d1)
        float n1 =
            rule1 * 5 +
            rule2 * 10 +
            rule3 * 20 +
            rule4 * 2 +
            rule5 * 5 +
            rule6 * 10 +
            rule7 * 1 +
            rule8 * 2 +
            rule9 * 5 +
            rule10 * 25 +
            rule11 * 35 +
            rule12 * 50 +
            rule13 * 20 +
            rule14 * 25 +
            rule15 * 35 +
            rule16 * 15 +
            rule17 * 20 +
            rule18 * 25 +
            rule19 * 80 +
            rule20 * 90 +
            rule21 * 100 +
            rule22 * 50 +
            rule23 * 65 +
            rule24 * 80 +
            rule25 * 40 +
            rule26 * 50 +
            rule27 * 65;

        float d1 =
            rule1 +
            rule2 +
            rule3 +
            rule4 +
            rule5 +
            rule6 +
            rule7 +
            rule8 +
            rule9 +
            rule10 +
            rule11 +
            rule12 +
            rule13 +
            rule14 +
            rule15 +
            rule16 +
            rule17 +
            rule18 +
            rule19 +
            rule20 +
            rule21 +
            rule22 +
            rule23 +
            rule24 +
            rule25 +
            rule26 +
            rule27;

        float aggressiveness = n1 / d1;
        return aggressiveness;
    }

    public static float Evaluate2(float health, float distance, float infectionTime)
    {
        // Fuzzificacion (Grado de pertenencia)
        float lowHealth = 1.0f - MembershipFunctions.Gamma(health, 20, 40);
        float midHealth = MembershipFunctions.Trapezoid(health, 20, 40, 60, 80);
        float highHealth = MembershipFunctions.Gamma(health, 60, 80);

        float closeDistance = 1.0f - MembershipFunctions.Gamma(distance, 1, 3);
        float midDistance = MembershipFunctions.Trapezoid(distance, 1, 3, 6, 8);
        float farDistance = MembershipFunctions.Gamma(distance, 6, 8);

        float shortInfection = 1.0f - MembershipFunctions.Gamma(infectionTime, 16, 24);
        float midInfection = MembershipFunctions.Trapezoid(infectionTime, 16, 24, 48, 56);
        float longInfection = MembershipFunctions.Gamma(infectionTime, 48, 56);

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

        float infectionMultiplier =
            shortInfection * 0.8f +
            midInfection * 1.0f +
            longInfection * 1.5f;

        float aggressiveness = n1 / d1;
        return Mathf.Clamp(
            aggressiveness * infectionMultiplier,
            0, 100);
    }
}