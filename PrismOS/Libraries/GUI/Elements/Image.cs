﻿using PrismOS.Libraries.Graphics;

namespace PrismOS.Libraries.GUI.Elements
{
    public class Image : Element
    {
        public Formats.Image Source;

        public override void Update(Canvas Canvas)
        {
            if (Visible && Source != null)
            {
                if (Width == default)
                {
                    Width = (int)Source.Width;
                }
                if (Height == default)
                {
                    Height = (int)Source.Height;
                }

                Canvas.DrawImage(X, Y, Width, Height, Source);
            }
        }
    }
}