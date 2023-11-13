namespace _4FunBike
{
    public class OrderLabel : UserControl
    {
        private Label lbl;
        private Button btn;

        public OrderLabel()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            lbl = new Label
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Size = new Size(410, 100), // Make sure this size accommodates your text.
                Font = new Font("Arial", 18, FontStyle.Bold),
            };
            btn = new Button
            {
                Text = "Click here to make a order!!!",
                Size = new Size(200, 100), // The width and height can be adjusted as needed.
                BackColor = Color.LightBlue,
            };
            btn.Click += Btn_Click;


            Controls.Add(lbl);
            Controls.Add(btn);

            int spacing = 1;
            btn.Location = new Point(lbl.Right + spacing, 0);

            // Set the size of the UserControl to fit its contents.
            Size = new Size(btn.Right, lbl.Height);
        }

        public void setText(string das)
        {
            lbl.Text = das;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            OnBtn_Click(EventArgs.Empty);
        }

        protected virtual void OnBtn_Click(EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
        }

        public event EventHandler ButtonClicked;
    }
}
