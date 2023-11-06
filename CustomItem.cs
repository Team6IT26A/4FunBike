// CustomItem.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _4FunBike
{
    public class CustomItem : UserControl
    {
        private PictureBox pictureBox;
        private Label lblName;
        private Label lblPrice;
        private Button btnAdd;
        private Button btnSubtract;

        public CustomItem()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(100, 100), // Fixed size for the picture box.
            };

            lblName = new Label
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(200, 100), // Make sure this size accommodates your text.
            };

            lblPrice = new Label
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(100, 100), // Make sure this size accommodates your text.
            };

            btnAdd = new Button
            {
                Text = "+",
                Size = new Size(50, 100), // The width and height can be adjusted as needed.
            };

            btnSubtract = new Button
            {
                Text = "-",
                Size = new Size(50, 100), // The width and height can be adjusted as needed.
            };

            btnAdd.Click += BtnAdd_Click;
            btnSubtract.Click += BtnSubtract_Click;

            // Add the controls to the UserControl's Controls collection.
            Controls.Add(pictureBox);
            Controls.Add(lblName);
            Controls.Add(lblPrice);
            Controls.Add(btnAdd);
            Controls.Add(btnSubtract);

            // Layout the controls horizontally.
            int spacing = 5;
            lblName.Location = new Point(pictureBox.Right + spacing, 0);
            lblPrice.Location = new Point(lblName.Right + spacing, 0);
            btnAdd.Location = new Point(lblPrice.Right + spacing, 0);
            btnSubtract.Location = new Point(btnAdd.Right + spacing, 0);

            // Set the size of the UserControl to fit its contents.
            Size = new Size(btnSubtract.Right, pictureBox.Height);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            OnAddButtonClicked(EventArgs.Empty);
        }

        private void BtnSubtract_Click(object sender, EventArgs e)
        {
            OnSubtractButtonClicked(EventArgs.Empty);
        }

        protected virtual void OnAddButtonClicked(EventArgs e)
        {
            AddButtonClicked?.Invoke(this, e);
        }

        protected virtual void OnSubtractButtonClicked(EventArgs e)
        {
            SubtractButtonClicked?.Invoke(this, e);
        }

        public Image ItemImage
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public string Name
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public double Price
        {
            get => double.TryParse(lblPrice.Text, out var price) ? price : 0;
            set => lblPrice.Text = $"{value:C}";
        }

        public event EventHandler AddButtonClicked;
        public event EventHandler SubtractButtonClicked;
    }
}
