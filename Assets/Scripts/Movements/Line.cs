using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : Shape
{
    public Line(Point startPoint, Point endPoint) : base(startPoint, endPoint, "Line")
    { }

    public double calcIncline()
    {
        if (this.endPoint.getX() - this.startPoint.getX() == 0)
        {
            return double.MaxValue;
        }
        return (double)(this.endPoint.getY() - this.startPoint.getY()) / (this.endPoint.getX() - this.startPoint.getX());
    }
}
