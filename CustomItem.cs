// CustomItem.cs

namespace _4FunBike
{
    public class CustomItem : UserControl
    {
        private PictureBox pictureBox;
        private Label lblName;
        private Label lblPrice;
        private Button btn;
        public double price;

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

            btn = new Button
            {
                Size = new Size(50, 100), // The width and height can be adjusted as needed.
            };
            btn.Click += Btn_Click;

            // Add the controls to the UserControl's Controls collection.
            Controls.Add(pictureBox);
            Controls.Add(lblName);
            Controls.Add(lblPrice);
            Controls.Add(btn);

            // Layout the controls horizontally.
            int spacing = 4;
            lblName.Location = new Point(pictureBox.Right + spacing, 0);
            lblPrice.Location = new Point(lblName.Right + spacing, 0);
            btn.Location = new Point(lblPrice.Right + spacing, 0);

            // Set the size of the UserControl to fit its contents.
            Size = new Size(btn.Right, pictureBox.Height);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            OnBtn_Click(EventArgs.Empty);
        }

        protected virtual void OnBtn_Click(EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
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

        public string btnText
        {
            get => btn.Text;
            set => btn.Text = value;
        }

        public double Price
        {
            get => double.TryParse(lblPrice.Text, out var price) ? price : 0;
            set
            {
                lblPrice.Text = $"{value:C}";
                price = value;
            }
        }

        public CustomItem copy()
        {
            CustomItem item = new CustomItem
            {
                Name = this.Name,
                Price = this.price,
                ItemImage = this.ItemImage,
                btnText = this.btnText
            };
            return item;
        }

        public event EventHandler ButtonClicked;
    }
}
