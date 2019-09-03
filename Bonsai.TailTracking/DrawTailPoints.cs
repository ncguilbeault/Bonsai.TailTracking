﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Drawing.Design;
using System.Collections.Generic;
using OpenCV.Net;

namespace Bonsai.TailTracking
{

    [Description("Draws tracking points onto image.")]
    [WorkflowElementCategory(ElementCategory.Transform)]

    public class DrawTailPoints : Transform<Tuple<IplImage, Point2f[]>, IplImage>
    {
        public DrawTailPoints()
        {
            Colour = new Scalar(255, 0, 0, 255);
            Radius = 1;
            Thickness = 1;
            Fill = true;
        }

        [Range(0, 255)]
        [Precision(0, 1)]
        [Editor(DesignTypes.SliderEditor, typeof(UITypeEditor))]
        [Description("Colour used for overlaying tracking points onto image.")]
        public Scalar Colour { get; set; }

        private int radius;
        [Description("Radius used for drawing tracking points.")]
        public int Radius { get => radius; set => radius = value > 1 ? value : 1; }

        private int thickness;
        [Description("Thickness of tracking point border.")]
        public int Thickness { get => thickness; set => thickness = value < 1 ? 1 : value; }

        [Description("Fills tracking points with colour.")]
        public bool Fill { get; set; }

        public override IObservable<IplImage> Process(IObservable<Tuple<IplImage, Point2f[]>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item1.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item1.Size.Width, value.Item1.Size.Height), value.Item1.Depth, 3);
                    CV.CvtColor(value.Item1, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item1.Clone();
                }
                for (int i = 0; i < value.Item2.Length; i++)
                {
                    if (!Fill)
                    {
                        CV.Circle(newImage, new Point((int)value.Item2[i].X, (int)value.Item2[i].Y), radius, Colour, thickness);
                    }
                    else
                    {
                        CV.Circle(newImage, new Point((int)value.Item2[i].X, (int)value.Item2[i].Y), radius, Colour, -1);
                    }
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<Point2f[], IplImage>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item2.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item2.Size.Width, value.Item2.Size.Height), value.Item2.Depth, 3);
                    CV.CvtColor(value.Item2, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item2.Clone();
                }
                for (int i = 0; i < value.Item1.Length; i++)
                {
                    if (!Fill)
                    {
                        CV.Circle(newImage, new Point((int)value.Item1[i].X, (int)value.Item1[i].Y), radius, Colour, thickness);
                    }
                    else
                    {
                        CV.Circle(newImage, new Point((int)value.Item1[i].X, (int)value.Item1[i].Y), radius, Colour, -1);
                    }
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<Point2f, IplImage>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item2.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item2.Size.Width, value.Item2.Size.Height), value.Item2.Depth, 3);
                    CV.CvtColor(value.Item2, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item2.Clone();
                }
                if (!Fill)
                {
                    CV.Circle(newImage, new Point((int)value.Item1.X, (int)value.Item1.Y), radius, Colour, thickness);
                }
                else
                {
                    CV.Circle(newImage, new Point((int)value.Item1.X, (int)value.Item1.Y), radius, Colour, -1);
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<IplImage, Point2f>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item1.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item1.Size.Width, value.Item1.Size.Height), value.Item1.Depth, 3);
                    CV.CvtColor(value.Item1, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item1.Clone();
                }
                if (!Fill)
                {
                    CV.Circle(newImage, new Point((int)value.Item2.X, (int)value.Item2.Y), radius, Colour, thickness);
                }
                else
                {
                    CV.Circle(newImage, new Point((int)value.Item2.X, (int)value.Item2.Y), radius, Colour, -1);
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<Point2f[][], IplImage>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item2.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item2.Size.Width, value.Item2.Size.Height), value.Item2.Depth, 3);
                    CV.CvtColor(value.Item2, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item2.Clone();
                }
                for (int i = 0; i < value.Item1.Length; i++)
                {
                    for (int j = 0; j < value.Item1[i].Length; j++)
                    {
                        if (!Fill)
                        {
                            CV.Circle(newImage, new Point((int)value.Item1[i][j].X, (int)value.Item1[i][j].Y), radius, Colour, thickness);
                        }
                        else
                        {
                            CV.Circle(newImage, new Point((int)value.Item1[i][j].X, (int)value.Item1[i][j].Y), radius, Colour, -1);
                        }
                    }
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<IplImage, Point2f[][]>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item1.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item1.Size.Width, value.Item1.Size.Height), value.Item1.Depth, 3);
                    CV.CvtColor(value.Item1, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item1.Clone();
                }
                for (int i = 0; i < value.Item2.Length; i++)
                {
                    for (int j = 0; j < value.Item2[i].Length; j++)
                    {
                        if (!Fill)
                        {
                            CV.Circle(newImage, new Point((int)value.Item2[i][j].X, (int)value.Item2[i][j].Y), radius, Colour, thickness);
                        }
                        else
                        {
                            CV.Circle(newImage, new Point((int)value.Item2[i][j].X, (int)value.Item2[i][j].Y), radius, Colour, -1);
                        }
                    }
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<IplImage, IList<Point2f>>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item1.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item1.Size.Width, value.Item1.Size.Height), value.Item1.Depth, 3);
                    CV.CvtColor(value.Item1, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item1.Clone();
                }
                for (int i = 0; i < value.Item2.Count; i++)
                {
                    if (!Fill)
                    {
                        CV.Circle(newImage, new Point((int)value.Item2[i].X, (int)value.Item2[i].Y), radius, Colour, thickness);
                    }
                    else
                    {
                        CV.Circle(newImage, new Point((int)value.Item2[i].X, (int)value.Item2[i].Y), radius, Colour, -1);
                    }
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<IList<Point2f>, IplImage>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item2.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item2.Size.Width, value.Item2.Size.Height), value.Item2.Depth, 3);
                    CV.CvtColor(value.Item2, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item2.Clone();
                }
                for (int i = 0; i < value.Item1.Count; i++)
                {
                    if (!Fill)
                    {
                        CV.Circle(newImage, new Point((int)value.Item1[i].X, (int)value.Item1[i].Y), radius, Colour, thickness);
                    }
                    else
                    {
                        CV.Circle(newImage, new Point((int)value.Item1[i].X, (int)value.Item1[i].Y), radius, Colour, -1);
                    }
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<IplImage, IList<Point2f[]>>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item1.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item1.Size.Width, value.Item1.Size.Height), value.Item1.Depth, 3);
                    CV.CvtColor(value.Item1, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item1.Clone();
                }
                for (int i = 0; i < value.Item2.Count; i++)
                {
                    for (int j = 0; j < value.Item2[i].Length; j++)
                    {
                        if (!Fill)
                        {
                            CV.Circle(newImage, new Point((int)value.Item2[i][j].X, (int)value.Item2[i][j].Y), radius, Colour, thickness);
                        }
                        else
                        {
                            CV.Circle(newImage, new Point((int)value.Item2[i][j].X, (int)value.Item2[i][j].Y), radius, Colour, -1);
                        }
                    }
                }
                return newImage;
            });
        }

        public IObservable<IplImage> Process(IObservable<Tuple<IList<Point2f[]>, IplImage>> source)
        {
            return source.Select(value =>
            {
                IplImage newImage;
                if (value.Item2.Channels == 1)
                {
                    newImage = new IplImage(new Size(value.Item2.Size.Width, value.Item2.Size.Height), value.Item2.Depth, 3);
                    CV.CvtColor(value.Item2, newImage, ColorConversion.Gray2Bgr);
                }
                else
                {
                    newImage = value.Item2.Clone();
                }
                for (int i = 0; i < value.Item1.Count; i++)
                {
                    for (int j = 0; j < value.Item1[i].Length; j++)
                    {
                        if (!Fill)
                        {
                            CV.Circle(newImage, new Point((int)value.Item1[i][j].X, (int)value.Item1[i][j].Y), radius, Colour, thickness);
                        }
                        else
                        {
                            CV.Circle(newImage, new Point((int)value.Item1[i][j].X, (int)value.Item1[i][j].Y), radius, Colour, -1);
                        }
                    }
                }
                return newImage;
            });
        }
    }
}
