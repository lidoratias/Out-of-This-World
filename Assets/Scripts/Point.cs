using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Point
{
    private double x;
    private double y;

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double getX()
    {
        return this.x;
    }

    public double getY()
    {
        return this.y;
    }

    public void setX(double x)
    {
        this.x = x;
    }

    public void setY(double y)
    {
        this.y = y;
    }

    public double distanceFrom(Point otherPoint)
    {
        return Math.Sqrt(Math.Pow(this.x - otherPoint.getX(), 2) + Math.Pow(this.y - otherPoint.getY(), 2));
    }
}
