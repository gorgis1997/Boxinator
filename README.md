# Boxinator
## Summary
Boxinator is a software that supports annoation and 2d data labeling. Boxinator allows you to take in a text file containing multiple categories, then annotate those categories on images. The software also includes an integrated image sequence converter that converts image sequences into frames for annoation.

## Getting started
To start using Boxinator, you will need to download the exe file on your computer (Windows). Once installed, you can open the software and begin creating your first annoation project in the "New" tab. Here you fill in the following boxes and chose between video mode or image mode based on your situation. The category file is of type .txt and each row in this file is a new category e.g. car.

![image](https://user-images.githubusercontent.com/67705679/212739592-27922705-eda2-4d0a-8896-4c62195c8b68.png)
## Annotation
Open the annotation tool and select the category you want to use from the combobox at the top of the screen.

In the annotation window, click and hold the left mouse button to draw a box around the object you want to label. Release the mouse button to finish drawing the box.

To move a box, click on it to select it, then click and hold the left mouse button to drag the box to a new location.

To resize a box, click on it to select it, then click and hold one of the handles (small squares) on the edges of the box and drag it to resize the box.

To delete a box, select it and press the delete key on your keyboard.

To mark a frame as a keyframe, select the keyframe button. This defines the starting and ending points of a smooth transition

all frames between keyframes are automatically interpolated, which means that all the boxes in the keyframe will be copied to all frames between keyframes.

Once you have labeled all the objects in a frame, you can move on to the next frame and repeat the process.

![image](https://user-images.githubusercontent.com/67705679/212743579-fd22d949-e598-46da-b6c7-ef2aadbc1457.png)

## Conclusion
Boxinator is a software that makes it easy to annotate and label 2D data. With its integrated image sequence converter and support for importing categories, it is a versatile tool for any 2D annotation project.
