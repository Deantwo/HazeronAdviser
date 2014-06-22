using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace HazeronAdviser
{
    static public class DrawingTools
    {
        static public Pen Pen(Color color)
        {
            return new Pen(color, 1);
        }
        static public Pen Marker(Color color)
        {
            return new Pen(color, 3);
        }
        static Font _font = new Font("Ariel", 6);
        static public Font Font
        {
            get { return _font; }
        }
        static public SolidBrush Brush(Color color)
        {
            return new SolidBrush(color);
        }
    }

    class StatisticsGraph
    {
        public StatisticsGraph(object sender, PaintEventArgs e, int yTop, int yBottom = 0)
        {
            _panel = (sender as Panel);
            _graphObj = e.Graphics;
            _yTop = yTop;
            _yBottom = yBottom;
            InitializeGraph();
        }

        public StatisticsGraph(Panel panel, Graphics graphObj, int yTop, int yBottom = 0)
        {
            _panel = panel;
            _graphObj = graphObj;
            _yTop = yTop;
            _yBottom = yBottom;
            InitializeGraph();
        }

        public void InitializeGraph()
        {
            _edgeTop = 15;
            _edgeRight = _panel.Width - 10;
            _edgeBottom = _panel.Height - 25;
            _edgeLeft = 25;
            _intervalX = (float)Math.Max(1, (float)(_edgeRight - _edgeLeft) / 19);
            _intervalY = (float)Math.Max(0.10, (float)(_edgeBottom - _edgeTop) / (_yTop - _yBottom));
            _yZero = _edgeBottom + _yBottom * _intervalY;
        }

        internal Panel _panel;
        internal Graphics _graphObj;
        internal int _yTop;
        internal int _yBottom;
        internal int _edgeTop;
        internal int _edgeRight;
        internal int _edgeBottom;
        internal int _edgeLeft;
        internal float _intervalX;
        internal float _intervalY;
        internal float _yZero;

        public void DrawGraphAxles(string xAxleName, string yAxleName)
        {
            // Set the interval between numbers on the Y axle. This may still need ajustment!
            int intervalNumber;
            if (_intervalY > 7.5)
                intervalNumber = 1;
            else if (_intervalY > 5)
                intervalNumber = 2;
            else if (_intervalY > 1)
                intervalNumber = 5;
            else if (_intervalY > 0.4)
                intervalNumber = 20;
            else if (_intervalY > 0.24)
                intervalNumber = 50;
            else
                intervalNumber = 100;
            // Draw the axle labels
            _graphObj.DrawString(xAxleName, DrawingTools.Font, DrawingTools.Brush(Color.Black), _edgeRight - 12, _edgeBottom + 8);
            _graphObj.DrawString(yAxleName, DrawingTools.Font, DrawingTools.Brush(Color.Black), 6, 3);
            if (_panel.Height > 30) // If the panel is too small, don't draw anything.
            {
                // Draw the axles
                _graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeLeft, _edgeBottom, _edgeRight, _edgeBottom);
                _graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeLeft, _edgeTop, _edgeLeft, _edgeBottom);
                // Draw the X axle arrow
                _graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeRight, _edgeBottom, _edgeRight - 5, _edgeBottom - 5);
                _graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeRight, _edgeBottom, _edgeRight - 5, _edgeBottom + 5);
                // Draw the Y axle arrow
                //_graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeLeft, _edgeTop, _edgeLeft + 5, _edgeTop + 5);
                //_graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeLeft, _edgeTop, _edgeLeft - 5, _edgeTop + 5);
                // Add numbers to the X axle
                int number = 1;
                for (float loop = _edgeLeft + _intervalX; loop < _edgeRight - 10; loop += _intervalX)
                {
                    int numberOffset = 0;
                    _graphObj.DrawLine(DrawingTools.Pen(Color.Black), loop, _edgeBottom - 2, loop, _edgeBottom + 5);
                    numberOffset = -((number.ToString().Length - 1) * 4); // Numbers left align offset.
                    _graphObj.DrawString(number++.ToString(), DrawingTools.Font, DrawingTools.Brush(Color.Black), loop - 3 + numberOffset, _edgeBottom + 5 + 3);
                }
                // Add numbers to the Y axle
                number = _yBottom;
                for (float loop = _edgeBottom; loop >= _edgeTop - 0.1; loop -= (_intervalY * intervalNumber))
                {
                    int numberOffset = 0;
                    _graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeLeft - 5, loop, _edgeLeft + 2, loop);
                    numberOffset = -((number.ToString().Length - 1) * 4); // Numbers left align offset.
                    _graphObj.DrawString(number.ToString(), DrawingTools.Font, DrawingTools.Brush(Color.Black), _edgeLeft - 5 - 7 + numberOffset, loop - 3);
                    number += intervalNumber;
                }
                // If yZero is not at the buttom, make a line at yZero.
                if (_yBottom != _yZero)
                {
                    _graphObj.DrawLine(DrawingTools.Pen(Color.Black), _edgeLeft, _yZero, _edgeRight, _yZero); for (float loop = _edgeLeft + _intervalX; loop < _edgeRight * 2; loop += _intervalX)
                        for (loop = _edgeLeft + _intervalX; loop < _edgeRight * 2; loop += _intervalX)
                        {
                            _graphObj.DrawLine(DrawingTools.Pen(Color.Black), loop, _yZero - 2, loop, _yZero + 2);
                        }
                }
            }
        }

        public void DrawGraph(int[] yAxle, Color color)
        {
            if (_panel.Height > 30) // If the panel is too small, don't draw anything.
            {
                _graphObj.DrawEllipse(DrawingTools.Marker(color), _edgeLeft + 0 - 1, _yZero - yAxle[0] * _intervalY - 1, 2, 2);
                for (float loop = 1; loop < yAxle.Length; loop++)
                {
                    PointF from = new PointF(_edgeLeft + (loop - 1) * _intervalX, _yZero - yAxle[(int)(loop - 1)] * _intervalY);
                    PointF to = new PointF(_edgeLeft + loop * _intervalX, _yZero - yAxle[(int)loop] * _intervalY);
                    _graphObj.DrawLine(DrawingTools.Pen(color), from, to);
                    _graphObj.DrawEllipse(DrawingTools.Marker(color), to.X - 1, to.Y - 1, 2, 2);
                }
            }
        }
    }
}
