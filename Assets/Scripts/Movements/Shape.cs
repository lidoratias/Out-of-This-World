using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape
{
    protected Point startPoint;
    protected Point endPoint;

    private string name;

    public Shape(Point startPoint, Point endPoint, string name)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.name = name;
    }

    public Point getStartPoint()
    {
        return this.startPoint;
    }

    public Point getEndPoint()
    {
        return endPoint;
    }

    public string getName()
    {
        return this.name;
    }

    public void setStartPoint(Point startPoint)
    {
        this.startPoint.setX(startPoint.getX());
    }

    public void setEndPoint(Point endPoint)
    {
        this.endPoint.setX(endPoint.getX());
    }

    public void setName(string newName)
    {
        this.name = newName;
    }
}
