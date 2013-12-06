using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
namespace VTMS
{
    public class ResizableForm : Office2007Form
    {
        private Hashtable satesOfAllCtrl = new Hashtable();

        private int FormSizeWidth = 1024;//用以存储窗体原始的水平尺寸
        private int FormSizeHeight = 701;//用以存储窗体原始的垂直尺寸

        //private double whScale;

        private double FormSizeChangedX;//用以存储相关父窗体/容器的水平变化量
        private double FormSizeChangedY;//用以存储相关父窗体/容器的垂直变化量

        public ResizableForm()
        {
            this.Load += new EventHandler(ResizableForm_Load);
            this.SizeChanged += new EventHandler(ResizableForm_SizeChanged);
        }
        protected void ResizableForm_Load(object sender, EventArgs e)
        {
            //whScale = (double)FormSizeWidth / FormSizeHeight;
            GetAllCtrlStates(this);
        }

        private void ResizableForm_SizeChanged(object sender, EventArgs e)
        {
            //如果窗体的大小在改变过程中小于窗体尺寸的初始值，则窗体中的各个控件自动重置为初始尺寸，且窗体自动添加滚动条
            if (this.Size.Width < FormSizeWidth || this.Size.Height < FormSizeHeight)
            {

                foreach (DictionaryEntry item in satesOfAllCtrl)
                {
                    Control ctrl = (Control)item.Key;
                    SizeAndPosition temp = (SizeAndPosition)item.Value;

                    ctrl.Width = temp.width;

                    ctrl.Height = temp.height;

                    ctrl.Bounds = new Rectangle(new Point(temp.locationX, temp.locationY),
                        ctrl.Size);
                }
                this.AutoScroll = true;
            }
            else
            //否则，重新设定窗体中所有控件的大小（窗体内所有控件的大小随窗体大小的变化而变化）
            {
                this.AutoScroll = false;
                FormSizeChangedX = this.Size.Width / (double)FormSizeWidth;
                FormSizeChangedY = (double)this.Size.Height / (double)FormSizeHeight;

                foreach (DictionaryEntry item in satesOfAllCtrl)
                {
                    Control ctrl = (Control)item.Key;
                    SizeAndPosition temp = (SizeAndPosition)item.Value;

                    ctrl.Width = (int)(temp.width * FormSizeChangedX);

                    ctrl.Height = (int)(temp.height * FormSizeChangedY);

                    ctrl.Bounds = new Rectangle(new Point((int)(temp.locationX * FormSizeChangedX), (int)(temp.locationY * FormSizeChangedY)),
                        ctrl.Size);
                }
            }
        }
        private void GetAllCtrlStates(Control CrlContainer)//获得并存储窗体中各控件的初始位置
        {
            foreach (Control iCrl in CrlContainer.Controls)
            {
                if (iCrl.GetType() != typeof(ExpandablePanel))
                {
                    satesOfAllCtrl.Add(iCrl, new SizeAndPosition(iCrl.Width, iCrl.Height, iCrl.Location.X, iCrl.Location.Y));
                    if (iCrl.Controls.Count > 0)
                        GetAllCtrlStates(iCrl);
                }
            }
        }
        class SizeAndPosition
        {
            public int width;
            public int height;
            public int locationX;
            public int locationY;

            public SizeAndPosition(int width, int height, int locationX, int locationY)
            {
                this.width = width;
                this.height = height;
                this.locationX = locationX;
                this.locationY = locationY;
            }
        }
    }
}
