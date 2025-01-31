﻿using PrismGraphics;
using PrismTools.IO;

namespace PrismUI.Controls
{
	/// <summary>
	/// The <see cref="Button"/> class, used to represent the image state(s) of a clickable button.
	/// </summary>
	public class Button : Control
	{
		/// <summary>
		/// Creates a new instance of the <see cref="Button"/> class, Which is abstracted from the <see cref="Control"/> class.
		/// </summary>
		/// <param name="Width">The Width of the button.</param>
		/// <param name="Height">The Height of the button.</param>
		/// <param name="Radius">The radius/curvature of the button.</param>
		/// <param name="Text">The text shown in the button.</param>
		/// <param name="OnClick">The method fired when the button is pressed.</param>
		public Button(ushort Width, ushort Height, ushort Radius, string Text, Action OnClick) : base(Width, Height, Radius)
		{
			ButtonHovering = new(Width, Height);
			ButtonClicked = new(Width, Height);
			ButtonIdle = new(Width, Height);
			this.OnClick = OnClick;
			this.Text = Text;
		}

		#region Properties

		public override Graphics MainImage
		{
			get
			{
				// Check if the mouse is within the control.
				if (MouseEx.IsMouseWithin(X, Y, Width, Height))
				{
					if (MouseEx.IsClickPressed())
					{
						// Check if a click event should fire.
						if (MouseEx.IsClickReady())
						{
							// Invoke the click method.
							OnClick.Invoke();
						}

						// Return the clicked state of the button.
						return ButtonClicked;
					}

					// Return the hovering state of the button.
					return ButtonHovering;
				}

				// Return the idle state of the button.
				return ButtonIdle;
			}
		}

		#endregion

		#region Methods

		public override void Render()
		{
			// Define start & end colors for gradients.
			Color StartColor = "#EAEAEA";
			Color EndColor = "#979797";

			// Set new sizes if needed.
			ButtonHovering.Height = Height;
			ButtonHovering.Width = Width;
			ButtonClicked.Height = Height;
			ButtonClicked.Width = Width;
			ButtonIdle.Height = Height;
			ButtonIdle.Width = Width;

			// Clear each image to be transparent.
			ButtonHovering.Clear(Color.Transparent);
			ButtonClicked.Clear(Color.Transparent);
			ButtonIdle.Clear(Color.Transparent);

			// Draw the base of the button.
			ButtonHovering.DrawFilledRectangle(0, 0, Width, Height, Radius, Color.White);
			ButtonClicked.DrawFilledRectangle(0, 0, Width, Height, Radius, Color.White);
			ButtonIdle.DrawFilledRectangle(0, 0, Width, Height, Radius, Color.White);

			// Generate gradients for each button.
			Gradient GradientHovering = new(Width, Height, StartColor - 32f, EndColor);
			Gradient GradientClicked = new(Width, Height, EndColor, StartColor);
			Gradient GradientIdle = new(Width, Height, StartColor, EndColor);

			// Mask each button image to apply the gradient & draw it onto the images.
			ButtonHovering.DrawImage(0, 0, Filters.MaskAlpha(ButtonHovering, GradientHovering));
			ButtonClicked.DrawImage(0, 0, Filters.MaskAlpha(ButtonClicked, GradientClicked));
			ButtonIdle.DrawImage(0, 0, Filters.MaskAlpha(ButtonIdle, GradientIdle));

			// Draw the text onto the images.
			ButtonHovering.DrawString(Width / 2, Height / 2, Text, default, Color.Black, true);
			ButtonClicked.DrawString(Width / 2, Height / 2, Text, default, Color.Black, true);
			ButtonIdle.DrawString(Width / 2, Height / 2, Text, default, Color.Black, true);
		}

		#endregion

		#region Fields

		public Graphics ButtonHovering;
		public Graphics ButtonClicked;
		public Graphics ButtonIdle;
		public Action OnClick;
		public string Text;

		#endregion
	}
}