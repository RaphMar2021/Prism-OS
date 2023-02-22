﻿# Introduction - PrismGraphics

PrismgGraphics is the 2D graphics rasterization platform that allows for drawing of text, images, shapes, gradients, and whatever else on a 2D canvas.

This readme is still in progress, not finished!

> There is no hardware acceleration and is constantly WIP, expect bugs!

<hr/>

## Animation - [AnimationController.cs](https://github.com/Project-Prism/Prism-OS/blob/main/PrismGraphics/Animation/AnimationController.cs)

This animation controler is a non-blocking number interpolator that lerps one number to another over a period of time based on the mode it is set in. The available modes are defined [Here](https://github.com/Project-Prism/Prism-OS/blob/main/PrismGraphics/Animation/AnimationMode.cs).

To know when the animation has finished, check if the current value has reached the target value like so:
```cs
if (C.Current == C.Target)
{

}
```
To make it looping (reverse & forward) add the following in the ``if`` statement:
```cs
(C.Source, C.Target) = (C.Target, C.Source);
C.Reset();
```

> The controler has an update 'fidelity' of once every ``50`` milliseconds.

### Example(s)

Interpolate ``0.0f`` to ``255.0f`` over the span of ``5`` seconds with the ``Ease`` mode.
```cs
AnimationController A = new(0.0f, 255.0f, new(0, 0, 5), AnimationMode.Ease);
```

Display the material-theme cirlce spinning progress bar
```cs
AnimationController A = new(25f, 270f, new(0, 0, 0, 0, 750), AnimationMode.Ease);
AnimationController P = new(0f, 360f, new(0, 0, 0, 0, 500), AnimationMode.Linear);

int X = C.Width / 2;
int Y = C.Height / 2;

while (true)
{
	if (A.Current == A.Target)
	{
		(A.Source, A.Target) = (A.Target, A.Source);
		A.Reset();
	}
	if (P.Current == P.Target)
	{
		P.Reset();
	}

	int LengthOffset = (int)(P.Current + A.Current);
	int Offset = (int)P.Current;

	C.Clear();
	C.DrawFilledRectangle(X - 32, Y - 32, 64, 64, 6, Color.White);
	C.DrawArc(400, 300, 19, Color.LightGray, Offset, LengthOffset);
	C.DrawArc(400, 300, 20, Color.Black, Offset, LengthOffset);
	C.DrawArc(400, 300, 21, Color.LightGray, Offset, LengthOffset);
	C.Update();
}
```
The output result should look as follows:

https://user-images.githubusercontent.com/76945439/220498920-b9d7a999-f8d1-4d00-a6d4-ed7e97e2a2de.mp4

#### The algorithm
It's two actually. The absolute starting point circles around continuously and linearly and the length of the arc eases in and out between a short and long length

<hr/>

## Animation - [ColorController.cs](https://github.com/Project-Prism/Prism-OS/blob/main/PrismGraphics/Animation/ColorController.cs)

This animation controler is a non-blocking color interpolator that lerps one color to another over a period of time based on the mode it is set in. The available modes are defined [Here](https://github.com/Project-Prism/Prism-OS/blob/main/PrismGraphics/Animation/AnimationMode.cs).

> The controler has an update 'fidelity' of once every ``50`` milliseconds.

### Example(s)

Interpolate ``Color.Black`` to ``Color.Blue`` over the span of ``5`` seconds with the ``Ease`` mode.
```cs
ColorController A = new(Color.Black, Color.Blue, new(0, 0, 5), AnimationMode.Ease);
```

<hr/>

## Graphics - [Color.cs](https://github.com/Project-Prism/Prism-OS/blob/main/PrismGraphics/Color.cs)

The Color class is used to represent colors with their ARGB values and provide static predefined colors.

### Properties:
- ``A``: The alpha component of the color.
- ``R``: The red component of the color.
- ``G``: The green component of the color.
- ``B``: The blue component of the color.

### Constructors:
- ``new Color()``: Creates a new instance of the Color class with ARGB value of 0x00000000 (fully transparent black).
- ``new Color(uint argb)``: Creates a new instance of the Color class with the specified ARGB value.
- ``new Color(byte a, byte r, byte g, byte b)``: Creates a new instance of the Color class with the specified alpha, red, green, and blue values.

### Methods:
- ``FromArgb(uint argb)``: Creates a new instance of the Color class with the specified ARGB value.
- ``FromArgb(byte a, byte r, byte g, byte b)``: Creates a new instance of the Color class with the specified alpha, red, green, and blue values.
- ``Equals(object obj)``: Determines whether the specified object is equal to the current Color instance.
- ``GetHashCode()``: Serves as the default hash function.
- ``ToString()``: Returns a string representation of the current Color instance.

<hr/>

# ToDo

This project still has many things to finish, including video drivers.
See [here](https://wiki.osdev.org/Accelerated_Graphic_Cards).