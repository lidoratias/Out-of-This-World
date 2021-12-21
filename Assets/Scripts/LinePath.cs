using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePath : Path
{
    private bool direction = true;

    public LinePath(Point startPoint, Point endPoint, Point currentPoint, double velocity) : base(startPoint, endPoint, currentPoint, velocity)
    { }

    public calcIncline()
    {
        //TODO implement
    }

    public override Point getNextPoint()
    {
        if (direction && this.currentPoint.getX() )
        {

        }
    }
}
