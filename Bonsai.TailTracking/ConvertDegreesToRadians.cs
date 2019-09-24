﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.TailTracking
{

    [Description("Converts radians to degrees.")]
    [WorkflowElementCategory(ElementCategory.Transform)]

    public class ConvertDegreesToRadians : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(value => Utilities.ConvertDegreesToRadians(value));
        }
    }
}