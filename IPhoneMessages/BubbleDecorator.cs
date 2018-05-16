using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace IPhoneMessages
{
    public class BubbleDecorator : Decorator
    {
        Bubble bubble = new Bubble();

        public BubbleDecorator()
        {
            bubble.SetBinding(Bubble.WidthProperty, new Binding("ActualWidth")
            { Source = this });
            bubble.SetBinding(Bubble.HeightProperty, new Binding("ActualHeight")
            { Source = this });
        }

        protected override Visual GetVisualChild(int index)
        {
            if (Child != null)
            {
                if (index == 0)
                    return bubble;
                if (index == 1)
                    return Child;
            }
            throw new IndexOutOfRangeException("Wrong child index");
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            bubble.Arrange(new Rect(arrangeSize));
            return base.ArrangeOverride(arrangeSize);
        }

        protected override int VisualChildrenCount { get { return Child == null ? 0 : 2; } }
    }
}
