﻿using PrismOS.Libraries.Graphics;
using System;

namespace PrismOS.Libraries.UI
{
    public abstract class Control : IDisposable
    {
        public Control()
        {
            IsHovering = false;
            IsPressed = false;
            IsVisible = true;
            HasBorder = true;
        }

        public Action OnClick { get; set; } = () => { };
        public Action OnUpdate { get; set; } = () => { };
        public FrameBuffer FrameBuffer { get; set; }
        public bool IsHovering { get; set; }
        public bool IsPressed { get; set; }
        public bool IsVisible { get; set; }
        public bool HasBorder { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int Height
        {
            get
            {
                return (int)FrameBuffer.Height;
            }
            set
            {
                FrameBuffer = new((uint)Width, (uint)value);
            }
        }
        public int Width
        {
            get
            {
                return (int)FrameBuffer.Width;
            }
            set
            {
                FrameBuffer = new((uint)value, (uint)Height);
            }
        }

        public abstract void Update(Window Parent);

        public abstract void OnKey(Cosmos.System.KeyEvent Key);

        public void Dispose()
        {
            Cosmos.Core.GCImplementation.Free(this);
            GC.SuppressFinalize(this);
        }
    }
}