using UnityEngine;

public static class MembershipFunctions
{
    public static float Gamma(float x, float a, float m)
    {
        if (x <= a) return 0;
        if (x >= m) return 1;

        return (x - a) / (m - a);
    }

    public static float Triangular(float x, float a, 
        float m, float b)
    {
        if (x <= a) return 0;
        if (x > b) return 0;

        if (x > a && x <= m)
            return (x - a) / (m - a);
        return (b - x) / (b - m);
    }

    public static float Trapezoid(float x, float a,
        float b, float c, float d)
    {
        if (x <= a) return 0;
        if (x > b && x <= c) return 1;
        if (x > d) return 0;

        if (x > a && x <= b)
            return (x - a) / (b - a);
        return (d - x) / (d - c);
    }

    public static float Sigmoid(float x, float a, float c)
    {
        if (x <= a) return 0;
        if (x >= c) return 1;

        if (x <= ((a + c) / 2))
            return 2 * (((x - a) / (c - a)) * ((x - a) / (c - a)));


        return 1 - (2 * (((x - c) / (c - a)) * ((x - c) / (c - a))));
    }
}
