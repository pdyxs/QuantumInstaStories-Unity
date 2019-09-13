using System;
using System.Collections;
using System.Collections.Generic;
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
}

[Serializable]
public class HamiltonianRow
{
    public float[] values;
}
