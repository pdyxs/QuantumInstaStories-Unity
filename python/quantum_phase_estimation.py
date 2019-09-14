#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Sep 13 13:34:04 2019

@author: ana
"""

import numpy as np
import qiskit
import json
import time
import zmq
from numpy import linalg as LA
from qiskit import QuantumRegister, ClassicalRegister, QuantumCircuit
from qiskit import BasicAer, execute
from qiskit.tools.visualization import plot_histogram
from scipy.linalg import expm

def run(input, shot):
    #Define the Hamiltonian extracted from the picture
    Picture_Hamilt=np.array(input)
    #Make it Hermitian
    Hermitian_Hamilt=1/(np.matrix.trace(Picture_Hamilt))*Picture_Hamilt
    #Classically get its eigenvalues "l" and eigenvectors "u", we will use the later to intialize one of the qubits
    l,u=LA.eig(Hermitian_Hamilt)

    #Let's create the circuit!
    q=QuantumRegister(2)
    c=ClassicalRegister(2)
    qc=QuantumCircuit(q,c)

    #The inithial state of the second qubit of our circuit will be one of the eigenvectors of the Hamiltonian, we define it:
    state_vector=[u[0][j] for j in range(2)]
    qc.initialize(state_vector,[q[1]])
    #Quantum Phase Estimation begins
    #create superposition wuth the Hadamard gate
    qc.h(q[0])
    #The unitary matrix of the controlled unitary gate of the quantum phase estimation circuit is the following:
    UH=expm(1j*Hermitian_Hamilt)
    (th, ph, lam)=qiskit.quantum_info.synthesis.two_qubit_decompose.euler_angles_1q(UH)
    qc.cu3(th, ph, lam, q[0],q[1])
    #Inverse QFT
    qc.h(q[0])

    #projection and meassurement
    qc.barrier(q[0])
    qc.barrier(q[1])
    qc.measure(q[0],c[0])
    qc.measure(q[1],c[1])

    #Run on qasm simulator
    backend_qasm=BasicAer.get_backend('qasm_simulator')
    job_qasm=execute(qc,backend_qasm,shots=shot)
    result_qasm=job_qasm.result()
    counts=result_qasm.get_counts(qc)
    print(counts)
    Emo1=(counts.get('11') or 0)
    Emo2=(counts.get('10') or 0)
    Emo3=(counts.get('01') or 0)
    Emo4=(counts.get('00') or 0)
    ProbEmo1=round(Emo1/shot,2)
    ProbEmo2=round(Emo2/shot,2)
    ProbEmo3=round(Emo3/shot,2)
    ProbEmo4=round(Emo4/shot,2)
    plot_histogram(counts)
    probs = {"11": ProbEmo1, "10": ProbEmo2, "01": ProbEmo3, "00": ProbEmo4}
    return probs

context = zmq.Context()
socket = context.socket(zmq.REP)
socket.bind("tcp://*:5555")

while True:
    #  Wait for next request from client
    message = socket.recv()
    array = json.loads(message)

    # result = run([[0.2,0.4],[0.4,0.8]], 3)
    # socket.send_string(str(result))
    # socket.send_string(str(run([[0.2,0.4],[0.4,0.8]], 301)))
    # socket.send_string(str(run([[0.2,0.4],[0.4,0.8]], 3001)))
    socket.send_string(str(run(array, 8192)))
