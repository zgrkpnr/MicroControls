using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

namespace Nothing
{
    public class MicroArrowButton : Canvas
    {

        public enum ArrowDirection
        {
            Down = 0,
            Up = 1,
        }

        private ArrowDirection _direction;

        public MicroArrowButton(ArrowDirection direction)
        {
            _direction = direction;
        }



        public override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            dc.DrawRectangle(new SolidColorBrush(Colors.Black), new Pen(Colors.Black), 0, 0, 50, 50);

            if (_direction == ArrowDirection.Down)
            {
                int Y, X;
                for (int i = 0; i <= 12; i++)
                {
                    Y = 6 - i;
                    X = 12 - i;
                    dc.DrawLine(new Pen(Color.White), (this.Width / 2 - X), (this.Height / 2 - Y), (this.Width / 2 + X), (this.Height / 2 - Y));
                }
            }
            else
            {
                int Y, X;
                for (int i = 0; i <= 12; i++)
                {
                    Y = 17 - i;
                    X = 12 - i;
                    dc.DrawLine(new Pen(Color.White), (this.Width / 2 - X), Y, (this.Width / 2 + X), Y);
                }
            }

        }
    }
}
