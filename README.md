# Qiskagram
*Quantum Instagram Stories*



## How to run
To run this demo, you need to have the [Unity Editor](https://unity3d.com/get-unity/) and python 3.7 with [qiskit](https://qiskit.org) installed.

### Running the qiskit server
The front-end app communicates with a local qiskit server to run the quantum circuits in real-time. Open a terminal and:
* `cd <repository folder>/python`
* `python quantum_phase_estimation.py`

### Running the Demo
Open the project in the Unity editor, and choose one of the two scenes in the `Assets/Scenes` folder (*Queen* or *Kanye*) and run the project.

It's advised that you run the project in a 1080x1920 resolution (portrait), edit this in the 'Game' window in Unity.

#### Interactions
Right now, you can click on the left side of the story to go back a page, and the rest of the screen to go to the next one.

## Generating Quantum Emojis
Quantum Emoji Generator (Animated Emojis) takes classical emojis from current digital social networks and uses qiskit quantum simulation to animate them. Conceptually, and based on current research into cognitive function (Busemeyer and Bruza 2012), we argue that in the future emotions will be better represented using techniques from quantum mechanics rather than classical science. Humans are often in complex emotional states rather than in just one emotion or another. By animating emojis, we represent this by passing four emojis representing the core emotions of happy, angry, sad and scared jointly through quantum circuits, blurring and combining them, before they evolve back into recognisable forms.

In order to run the Quantum Emoji generator, open *<repository folder>/python/Animated_Emojis.ipynb* as a jupyter notebook
