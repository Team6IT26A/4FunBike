namespace _4FunBike
{
    public partial class ShopApplication : Form
    {
        public ShopApplication()
        {
            InitializeComponent();

            // Create an instance of CustomItem
            CustomItem item = new CustomItem();
            item.Location = new Point(10, 10); // Position on the form
            item.Price = 50.99M;
            item.Description = "Bike Item";
            item.ItemImage = Image.FromFile("C:\\Program Files (x86)\\Steam\\appcache\\librarycache\\730_icon.jpg"); // Make sure to provide a valid path or use another method to set the image

            // Optional: Handle the events
            item.ButtonOneClicked += (s, e) =>
            {
                MessageBox.Show("Button 1 clicked on the item!");
            };

            item.ButtonTwoClicked += (s, e) =>
            {
                MessageBox.Show("Button 2 clicked on the item!");
            };

            // Add the CustomItem control to the form's controls
            this.Controls.Add(item);
        }
    }
}