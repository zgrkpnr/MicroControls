using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation.Media;


namespace MicroControls
{
    /// <summary>
    /// <para>Inherits Canvas class</para>
    /// </summary>
    public class MicroButton : Canvas
    {
        private Border border;
        private Text btnText;
        private Color btnStateNormal;
        private Color btnStatePressed;

        public delegate void OnClick(object sender, TouchEventArgs e);
        public event OnClick onClick;

        /// <summary>
        /// <para><paramref name="height"/>: Height of the button</para>
        /// <para><paramref name="width"/>: Width of the button</para>
        /// <para><paramref name="content"/>: Text content of the button</para>
        /// <para>To make text content displayed, Font should be set using <c>SetFont()</c> method</para>
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="content"></param>
        public MicroButton(int height, int width, string content/*, Font buttonFont*/)
        {
            btnStateNormal = Colors.Black;
            btnStatePressed = Colors.DarkGray;
            //btnText.Font = buttonFont;

            Height = height;
            Width = width;
            border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.Height = this.Height; ;
            border.Width = this.Width; ;
            border.Background = new SolidColorBrush(Colors.Black);
            this.Children.Add(border);

            btnText = new Text();
            btnText.ForeColor = Colors.White;
            btnText.TextContent = content;
            btnText.VerticalAlignment = VerticalAlignment.Center;
            btnText.HorizontalAlignment = HorizontalAlignment.Center;
            border.Child = btnText;

        }


        /// <summary>
        /// <para>Sets the text font of button's text content</para>
        /// </summary>
        /// <param name="font"></param>
        public MicroButton SetFont(Font font)
        {
            btnText.Font = font;
            return this;
        }

        /// <summary>
        /// <para>Set the text content of the button</para>
        /// </summary>
        /// <param name="text"></param>
        public MicroButton SetText(string text)
        {
            btnText.TextContent = text;
            btnText.Invalidate();
            btnText.UpdateLayout();
            return this;
        }

        /// <summary>
        /// <para>Set background color of the button</para>
        /// </summary>
        /// <param name="color"></param>
        public MicroButton SetBackgroundColor(Color color)
        {
            border.Background = new SolidColorBrush(color);
            border.BorderBrush = new SolidColorBrush(color);
            btnStateNormal = color;
            return this;
        }


        /// <summary>
        /// <para>Sets the background color of the button when it is pressed</para>
        /// </summary>
        /// <param name="color"></param>
        public MicroButton SetOnclickColor(Color color)
        {
            btnStatePressed = color;
            return this;
        }

        protected override void OnTouchDown(TouchEventArgs e)
        {
            base.OnTouchDown(e);

            if (onClick != null)
            {
                onClick(this, e);
            }
            border.Background = new SolidColorBrush(btnStatePressed);
            border.BorderBrush = new SolidColorBrush(btnStatePressed);
            this.Invalidate();
            this.UpdateLayout();
            //e.Handled = true;
        }

        protected override void OnTouchUp(TouchEventArgs e)
        {
            base.OnTouchUp(e);
            border.Background = new SolidColorBrush(btnStateNormal);
            border.BorderBrush = new SolidColorBrush(btnStateNormal);
            this.Invalidate();
            this.UpdateLayout();
        }
    }
}
