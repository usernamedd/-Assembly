using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace 查看程序集依赖
{
    public class MovingChildCanvas:Canvas
    {
        private bool _isMoving = false;
        private UIElement _whoIs;
        public MovingChildCanvas()
        {
            this.MouseMove += CustomCanvas_MouseMove;
            this.MouseUp += CustomCanvas_MouseUp;
        }

        private void CustomCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMoving = false;
            _whoIs = null;
        }

        private void CustomCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_isMoving == false || _whoIs == null)
            {
                return;
            }
            SetLeft(_whoIs, e.GetPosition(this).X);
            SetTop(_whoIs, e.GetPosition(this).Y);
        }
        /// <summary>
        /// 从此处添加的子元素不可移动
        /// </summary>
        /// <param name="uiElement"></param>
        public void AddChildNoMove(UIElement uiElement)
        {
            this.Children.Add(uiElement);
        }
        /// <summary>
        /// 从此处添加的元素可移动
        /// </summary>
        /// <param name="uiElement"></param>
        public void AddChildCanMove(UIElement uiElement)
        {
            this.Children.Add(uiElement);
            //e.Handled = true  防止出现这种情况：当在移动元素UI对象时，画布同时也在移动
            uiElement.MouseDown += (s, e) => { _whoIs = uiElement; _isMoving = true; e.Handled = true; };
        }
        /// <summary>
        /// 开启在ScrollViewer上按下鼠标左键移动的功能
        /// </summary>
        public void StartupMoveInScrollViewer()
        {
            this.Loaded += (ss, ee) =>
            {
                ScrollViewer ScrollViewer1 = LogicalTreeHelper.GetParent(this) as ScrollViewer;
                if (ScrollViewer1 == null)
                {
                    throw new Exception("父元素不是ScrollViewer，此功能不可用");
                }
                Point scrollStartPoint = default(Point);
                bool useScroll = false;
                this.MouseLeftButtonDown += (sender, e) =>
                {
                    scrollStartPoint = e.GetPosition(this);
                    useScroll = true;
                };

                ScrollViewer1.MouseMove += (sender, e) =>
                {
                    if (useScroll == true)
                    {
                        var newPoint = e.GetPosition(this);
                        double newHScrollOffset = ScrollViewer1.HorizontalOffset - (newPoint.X - scrollStartPoint.X) / 2;
                        ScrollViewer1.ScrollToHorizontalOffset(newHScrollOffset);

                        double newVScrollOffset = ScrollViewer1.VerticalOffset - (newPoint.Y - scrollStartPoint.Y) / 2;
                        ScrollViewer1.ScrollToVerticalOffset(newVScrollOffset);

                        scrollStartPoint = newPoint;
                    }
                };
                ScrollViewer1.MouseUp += (sender, e) => { useScroll = false; };
            };
        }
    }
}