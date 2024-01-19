# ArraySort_AidanaBeken

## Features

This project includes the following features:

- Creation of `n` objects with random colors and an `x` value used for sorting.
- Ability to choose the sorting method:
  - Bubble Sort
  - Insertion Sort
  - Selection Sort
  - Quick Sort
- Smooth movement of objects to their target positions after sorting.
- Deletion of all objects from the scene.

## How to Use

To use this project, follow these steps:

1. **Opening the Scene:**
   Launch the scene in Unity.

2. **Entering the Number of Objects:**
   Enter a numerical value `n` in the input field. This number will determine the number of objects to be created.

3. **Creating Objects:**
   Click the `Random create` button. This will create `n` objects with random colors. The size of each object will be proportional to its value, which is also determined randomly.

4. **Choosing a Sorting Method:**
   Select a sorting method.

5. **Sorting Objects:**
   Click the `Sort` button to start the sorting process.

6. **Completing the Sort:**
   Optionally, disable smooth movement by clicking `Finish`.

7. **Deleting or Recreating Objects:**
   To delete all objects, click `Remove`. To delete the current objects and create new ones, click `Random Create` again with a new or the same value in the input field.

## Notes
- For smooth movement demonstration, it is recommended to use values up to 12, as a larger number of objects may not fit within the camera frame. To compare sorting algorithms, you can use values up to 1000. The sorting execution time will be displayed in the console.
- During sorting, the `Random Create`, `Sort`, and `Remove` buttons will be inactive.
- Access to buttons is restored after the objects have finished moving.
