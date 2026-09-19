using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;


namespace CaptchaImage
{
    /// <summary>
    /// 这个生成验证码图片的代码来自：http://www.codeproject.com/KB/aspnet/CaptchaImage.aspx
    /// </summary>
    public class CaptchaImage
    {
        // 公开属性（全部只读）。
        public string Text
        {
            get { return this.text; }
        }
        public Bitmap Image
        {
            get { return this.image; }
        }
        public int Width
        {
            get { return this.width; }
        }
        public int Height
        {
            get { return this.height; }
        }

        // 内部属性。
        private string text;
        private int width;
        private int height;
        private string familyName;
        private Bitmap image;

        // 用来生成随机数。
        private Random random = new Random();

        // ====================================================================
        // 用以下参数初始化 CaptchaImage 实例：
        // 指定的文本、宽度和高度。
        // ====================================================================
        public CaptchaImage(string s, int width, int height)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.GenerateImage();
        }

        // ====================================================================
        // 用以下参数初始化 CaptchaImage 实例：
        // 指定的文本、宽度、高度和字体族。
        // ====================================================================
        public CaptchaImage(string s, int width, int height, string familyName)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.SetFamilyName(familyName);
            this.GenerateImage();
        }

        // ====================================================================
        // 重写 Object.Finalize。
        // ====================================================================
        ~CaptchaImage()
        {
            Dispose(false);
        }

        // ====================================================================
        // 释放此对象占用的全部资源。
        // ====================================================================
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        // ====================================================================
        // 自定义 Dispose，用来清理非托管资源。
        // ====================================================================
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                // 释放位图。
                this.image.Dispose();
        }

        // ====================================================================
        // 设置图片宽度和高度。
        // ====================================================================
        private void SetDimensions(int width, int height)
        {
            // 校验宽度和高度。
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.");
            this.width = width;
            this.height = height;
        }

        // ====================================================================
        // 设置图片文字使用的字体。
        // ====================================================================
        private void SetFamilyName(string familyName)
        {
            // 指定的字体没装就回退到系统字体。
            try
            {
                Font font = new Font(this.familyName, 13F);
                this.familyName = familyName;
                font.Dispose();
            }
            catch (Exception)
            {
                this.familyName = System.Drawing.FontFamily.GenericSerif.Name;
            }
        }

        // ====================================================================
        // 创建位图。
        // ====================================================================
        private void GenerateImage()
        {
            // 新建一张 32 位位图。
            Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);

            // 创建用于绘图的 Graphics 对象。
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.width, this.height);

            // 填充背景。
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightGray, Color.White);
            g.FillRectangle(hatchBrush, rect);

            // 设置文字字体。
            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;
            // 不断调小字号，直到文字能放进图片。
            do
            {
                fontSize--;
                font = new Font(this.familyName, fontSize, FontStyle.Bold);
                size = g.MeasureString(this.text, font);
            } while (size.Width > rect.Width);

            // 设置文字格式。
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // 按文字生成路径并随机扭曲。
            GraphicsPath path = new GraphicsPath();
            path.AddString(this.text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            float v = 8F;
            PointF[] points =
			{
				new PointF(this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v)
			};
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            // 绘制文字。
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.Green, Color.DarkGray);
            g.FillPath(hatchBrush, path);

            // 撒一些随机噪点。
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = this.random.Next(rect.Width);
                int y = this.random.Next(rect.Height);
                int w = this.random.Next(m / 50);
                int h = this.random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            // 清理资源。
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            // 保存图片。
            this.image = bitmap;
        }
    }
}
