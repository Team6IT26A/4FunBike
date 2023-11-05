using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _4FunBike
{
    public partial class ShopApplication : Form
    {
        private List<CustomItem> customItems;
        private FlowLayoutPanel panel;

        public ShopApplication()
        {
            InitializeComponent();
            customItems = new List<CustomItem>();

            // Set up a FlowLayoutPanel to contain the CustomItems and manage their layout
            panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                FlowDirection = FlowDirection.TopDown // Stack items vertically
            };
            Controls.Add(panel);

            // Add example CustomItems
            for (int i = 1; i <= 5; i++)
            {
                CustomItem item = new CustomItem
                {
                    Name = "Bike Model " + i,
                    Price = 99.99m + i, // Example price
                };

                // Attempt to load the image from the file path.
                try
                {
                    item.ItemImage = Image.FromFile("C:\\Program Files (x86)\\Steam\\appcache\\librarycache\\730_icon.jpg");
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show("Image file not found: " + ex.Message);
                    // Set a default image or leave it blank if the image file is not found
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    // Handle other potential exceptions here, such as unauthorized access.
                }

                AddCustomItem(item);
            }
        }

        // Method to add a CustomItem to the list and panel
        public void AddCustomItem(CustomItem item)
        {
            // Add the item to the list
            customItems.Add(item);

            // Subscribe to the events if needed
            item.AddButtonClicked += CustomItem_AddButtonClicked;
            item.SubtractButtonClicked += CustomItem_SubtractButtonClicked;

            // Add the item to the FlowLayoutPanel for display
            panel.Controls.Add(item);
        }

        // Method to remove a CustomItem from the list and panel by index
        public void RemoveCustomItem(int index)
        {
            if (index >= 0 && index < customItems.Count)
            {
                // Unsubscribe from the events
                customItems[index].AddButtonClicked -= CustomItem_AddButtonClicked;
                customItems[index].SubtractButtonClicked -= CustomItem_SubtractButtonClicked;

                // Remove the item from the panel and the list
                panel.Controls.Remove(customItems[index]);
                customItems.RemoveAt(index);
            }
        }

        // Event handler for the Add button click event
        private void CustomItem_AddButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Add button clicked on item!");
        }

        // Event handler for the Subtract button click event
        private void CustomItem_SubtractButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Subtract button clicked on item!");
        }

        // Other methods and event handlers...
    }
}
