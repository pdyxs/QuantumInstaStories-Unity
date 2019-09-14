![Qiskagram logo](https://github.com/pdyxs/QuantumInstaStories-Unity/blob/master/img/qiskigram_header_full.jpg?raw=true)

# Qiskagram (v0.1.0)
*Quantum Instagram Stories*
Quantum Instagram Stories is a speculative project that uses qiskit to explore future quantum social platforms. Art and design can often ask wider questions about emerging technologies that their original inventors and developers often overlook. Current social networks have changed how we live, behave and view the world - from people’s body image, to fake news & trending hashtags. 

Our project explores how a future quantum instagram may interact with its users. While this project may be developed in many directions, for the Qiskit Hackathon we decided to focus on images and privacy. Currently tech companies such as Facebook and Microsoft use artificial intelligence to attempt to predict our emotions in order to sell us things. We believe that in the future, emotions will be better represented and accessed through quantum techniques rather than classical physics. After all, humans are often in complex emotional states rather than in just one emotion or another. 

Here we create a quantum state vector of emotions from an image of a face. Currently we use the somewhat blunt techniques of AI to assist in this quantum emotional state vector generation, but we suggest that when quantum computers and other techniques are more fully developed this state vector will be generated by quantum means (perhaps through a quantum-computer-brain interface). We show how quantum phase estimation can be used to find the complete spectrum of the eigenvalues of a person’s emotional Hamiltonian. (This Hamiltonian was derived my making analogies with the cognitive decision Hamiltonians in Busemeyer and Bruza 2012 and by researching the relations between emotions in psychology papers). We have built a Unity output that combines the quantum emotional (phase) prediction along with the Quantum Emojis (see below) in a simple Quantum Instagram Stories interface.

We hope that other artists, game developers, physicists and technologies continue developing aspects of this platform in the spirit of speculative design to pose further ethical questions around the future impacts of quantum social networks.


## How to run Qiskagram
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

In order to run the Quantum Emoji generator, open `<repository folder>/python/Animated_Emojis.ipynb` as a jupyter notebook

## Face Emotion Detection
In order to run the emotion detector, open `<repository folder>/python/facedetect.py` and add your Microsoft API key. You can then run `python facedetect.py`
