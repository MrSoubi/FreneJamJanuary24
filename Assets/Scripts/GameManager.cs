using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    static int score = 0;
    static int rank = 1;

    // Damages from attacks depend on the dragon's rank. The rank starts at 1 and gets bigger by destroying buildings, props and vehicules which give xp points.
    // The ammount of xp points necessary to lvl up to the rank n is calculated by the formula : a*(rank-1)^n + b
    // For example, with the formula 10 * rank^2 + 10, the xp needed to get to each rank is as follows :
    // Rank 2 : 20
    // Rank 3 : 50
    // Rank 4 : 90
    // Rank 5 : 170
    // Rank 6 : 330
    // Rank 7 : 650
    // Rank 8 : 1290
    // Rank 9 : 5130
    // And so one...

    // Note that xp points and score are the same thing.

    static float a = 10;
    static float b = 10;
    static float n = 2.5f;

    public static void AddScore(int points)
    {
        score += points;
    }

    public static int CalculateRankFromScore()
    {
        float localRank = score;

        localRank -= b;
        localRank = localRank / a;
        localRank = Mathf.Pow(Mathf.Max(localRank, 0), 1/n);

        Debug.Log(localRank + " score : " + score);
        return (int)localRank;
    }

    public static int GetRank()
    {
        if (rank < CalculateRankFromScore())
        {
            rank = CalculateRankFromScore();
        }

        return rank;
    }
}
