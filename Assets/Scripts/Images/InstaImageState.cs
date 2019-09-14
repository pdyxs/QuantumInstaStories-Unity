using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class InstaImageState : ScriptableObject
{
    public QiskitRequest[] requests;
}

[Serializable]
public class QiskitRequest
{
    public QuantumEmotions.Emotion[] emotions;
    public HamiltonianRow[] hamiltonian;

    public string HamiltonianString()
    {
        return $"[{string.Join(",", (object[]) hamiltonian)}]";
    }

    public void Normalise()
    {
        var sum = 0f;
        foreach (var row in hamiltonian)
        {
            foreach (var prob in row.values)
            {
                sum += (prob * prob);
            }
        }

        foreach (var row in hamiltonian)
        {
            row.values = Array.ConvertAll(row.values, val => val / sum);
        }
    }
}

[Serializable]
public class HamiltonianRow
{
    public float[] values;

    public override string ToString()
    {
        return $"[{string.Join(",", values)}]";
    }
}
