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

        const int edgeUR = 10;
        const int edgeLD = 25;

        static public void DrawGraphAxles(Panel panel, Graphics graphObj, string xAxleName, string yAxleName)
        {
            float intervalX = (float)Math.Max(1, (float)(panel.Width - edgeLD - edgeUR) / 19);
            float intervalY = (float)Math.Max(0.25, (float)(panel.Height - edgeLD - edgeUR) / 1250);
            int intervalNumber = 40;
            if (intervalY > 0.4)
                intervalNumber = 20;
            graphObj.DrawString(xAxleName, DrawingTools.Font, DrawingTools.Brush(Color.Black), panel.Width - edgeUR - 12, panel.Height - edgeLD + 8);
            graphObj.DrawString(yAxleName, DrawingTools.Font, DrawingTools.Brush(Color.Black), edgeLD - 19, edgeUR - 7);
            graphObj.DrawLine(DrawingTools.Pen(Color.Black), edgeLD, edgeUR, edgeLD, panel.Height - edgeLD);
            graphObj.DrawLine(DrawingTools.Pen(Color.Black), edgeLD, panel.Height - edgeLD, panel.Width - edgeUR, panel.Height - edgeLD);
            graphObj.DrawLine(DrawingTools.Pen(Color.Black), edgeLD, 10, edgeLD + 5, edgeLD - 5);
            graphObj.DrawLine(DrawingTools.Pen(Color.Black), edgeLD, 10, edgeLD - 5, edgeLD - 5);
            graphObj.DrawLine(DrawingTools.Pen(Color.Black), panel.Width - edgeUR, panel.Height - edgeLD, panel.Width - edgeUR - 5, panel.Height - edgeLD - 5);
            graphObj.DrawLine(DrawingTools.Pen(Color.Black), panel.Width - edgeUR, panel.Height - edgeLD, panel.Width - edgeUR - 5, panel.Height - edgeLD + 5);
            int number = 1;
            for (float loop = edgeLD + intervalX; loop < panel.Width - edgeUR * 2; loop += intervalX)
            {
                int numberOffset = 0;
                graphObj.DrawLine(DrawingTools.Pen(Color.Black), loop, panel.Height - edgeLD - 2, loop, panel.Height - edgeLD + 5);
                numberOffset = -((number.ToString().Length - 1) * 4); // Numbers left align offset.
                graphObj.DrawString(number++.ToString(), DrawingTools.Font, DrawingTools.Brush(Color.Black), loop - 3 + numberOffset, panel.Height - edgeLD + 5 + 3);
            }
            number = 0;
            for (float loop = panel.Height - edgeLD; loop > edgeUR * 2; loop -= (intervalY * intervalNumber))
            {
                int numberOffset = 0;
                graphObj.DrawLine(DrawingTools.Pen(Color.Black), edgeLD - 5, loop, edgeLD + 2, loop);
                numberOffset = -((number.ToString().Length - 1) * 4); // Numbers left align offset.
                graphObj.DrawString(number.ToString(), DrawingTools.Font, DrawingTools.Brush(Color.Black), edgeLD - 5 - 7 + numberOffset, loop - 3);
                number += intervalNumber;
            }
        }

        static public void DrawGraph(Panel panel, Graphics graphObj, int[] yAxle, Color color)
        {
            float intervalX = (float)Math.Max(1, (float)(panel.Width - edgeLD - edgeUR) / 19);
            float intervalY = (float)Math.Max(0.25, (float)(panel.Height - edgeLD - edgeUR) / 1250);
            graphObj.DrawEllipse(DrawingTools.Marker(color), edgeLD + 0 - 1, panel.Height - edgeLD - yAxle[0] * intervalY - 1, 2, 2);
            for (float loop = 1; loop < yAxle.Length; loop++)
            {
                PointF from = new PointF(edgeLD + (loop - 1) * intervalX, panel.Height - edgeLD - yAxle[(int)(loop - 1)] * intervalY);
                PointF to = new PointF(edgeLD + loop * intervalX, panel.Height - edgeLD - yAxle[(int)loop] * intervalY);
                graphObj.DrawLine(DrawingTools.Pen(color), from, to);
                graphObj.DrawEllipse(DrawingTools.Marker(color), to.X - 1, to.Y - 1, 2, 2);
            }
        }
    }
}
