namespace _4FunBike;

using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomItem : UserControl
{
    private PictureBox pictureBox;
    private Label lblPrice;
    private Button btnOne;
    private Button btnTwo;
    private Label lblDescription;

    public CustomItem()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        pictureBox = new PictureBox
        {
            Size = new Size(100, 100),
            Location = new Point(5, 5),
            BorderStyle = BorderStyle.Fixed3D
        };

        lblPrice = new Label
        {
            Location = new Point(110, 5),
            Size = new Size(80, 20),
            TextAlign = ContentAlignment.MiddleRight
        };

        btnOne = new Button
        {
            Location = new Point(110, 30),
            Size = new Size(80, 25),
            Text = "Button1"
        };

        btnTwo = new Button
        {
            Location = new Point(110, 60),
            Size = new Size(80, 25),
            Text = "Button2"
        };

        lblDescription = new Label
        {
            Location = new Point(5, 110),
            Size = new Size(185, 20),
            TextAlign = ContentAlignment.MiddleCenter
        };

        btnOne.Click += BtnOne_Click;
        btnTwo.Click += BtnTwo_Click;

        this.Controls.Add(pictureBox);
        this.Controls.Add(lblPrice);
        this.Controls.Add(btnOne);
        this.Controls.Add(btnTwo);
        this.Controls.Add(lblDescription);
        this.Size = new Size(200, 135);
    }

    public Image ItemImage
    {
        get => pictureBox.Image;
        set => pictureBox.Image = value;
    }

    public decimal Price
    {
        get => decimal.Parse(lblPrice.Text);
        set => lblPrice.Text = value.ToString("C");
    }

    public string Description
    {
        get => lblDescription.Text;
        set => lblDescription.Text = value;
    }

    public event EventHandler ButtonOneClicked;
    public event EventHandler ButtonTwoClicked;

    private void BtnOne_Click(object sender, EventArgs e)
    {
        ButtonOneClicked?.Invoke(this, e);
    }

    private void BtnTwo_Click(object sender, EventArgs e)
    {
        ButtonTwoClicked?.Invoke(this, e);
    }
}
