# GraphingAlgorithms
Test of 3 simply greedy algorithms.

This project is being developed in C# using WPF to test 3 algorithms for resolving graphs. These algorithms are as follow:
  - Kurskal's
  - Prim's
  - Dijkstra's

The backend design is using implementation of the IResolver interface where the work for resolving will be done. 

The front end is a WPF implementation which uses Caliburn for the dependancy injection container and bootstrapper to create a simple fast UX. 

On-going works;
  - Frontend  
    - Design needs a refresh when the back end is completed
    - Draw then connections between the nodes 
    - Change the drawing surface of the input to a canvas or similar control
    
  - Backend
    - Rearrange the providers for a better factory implementation
    - Rearrange dependancies for a clean set of factories
    - Complete ViewModel Provider 
    - Implement Kurskal's Algorithm as an IResolver
    - Implement Dijstrak's Algorithm as an IResolver
    - Implement Prim's Algorithm as an IResolver
    
Future Work;
  - Add more algorithms
  - Add a step by step style to allow the user to step through each stage of solution (cache the result and step through later)
  
    
