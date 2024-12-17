using System.Drawing;
using System.Windows.Forms;

public class ColoredBorderLabel : Label
{
    public Color BorderColor { get; set; } = Color.Blue;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (BorderStyle == BorderStyle.FixedSingle)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                BorderColor, ButtonBorderStyle.Solid);
        }
    }
}