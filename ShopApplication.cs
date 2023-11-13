using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _4FunBike
{
    public partial class ShopApplication : Form
    {
        private List<CustomItem> customItems;
        private List<CustomItem> shoppingcart;
        private FlowLayoutPanel panel1;
        private FlowLayoutPanel panel2;
        private OrderLabel label;

        public ShopApplication()
        {
            InitializeComponent();
            customItems = new List<CustomItem>();
            shoppingcart = new List<CustomItem>();


            panel1 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown, // Stack items vertically
                WrapContents = false, // Prevent wrapping to the next line
            };
            panel2 = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown, // Stack items vertically
                WrapContents = false, // Prevent wrapping to the next line
            };
            label = new OrderLabel
            {
                AutoSize = true
            };
            label.ButtonClicked += CustomItem_ButtonClicked3;
            updatePrice();
            productsTab.Controls.Add(panel1);
            shoppingcardTab.Controls.Add(panel2);
            panel2.Controls.Add(label);


            foreach (Product product in DataHolder.GetInstance().Products)
            {
                CustomItem item = new CustomItem
                {
                    Name = product.Name,
                    Price = product.Price,
                    ItemImage = product.Image,
                    btnText = "+"
                };
                AddCustomItem(item, 1);
            }
        }

        // ... Keep the rest of your methods and event handlers as is.


        // Method to add a CustomItem to the list and panel
        public void AddCustomItem(CustomItem item, int what)
        {
            if (what == 1)
            {
                // Add the item to the list
                customItems.Add(item);

                // Subscribe to the events with correct syntax
                item.ButtonClicked += (sender, e) => CustomItem_ButtonClicked(sender, e, customItems.IndexOf(item));

                panel1.Controls.Add(item);
            }
            else if(what == 2)
            {
                // Add the item to the list
                shoppingcart.Add(item);
                item.btnText = "-";

                // Subscribe to the events with correct syntax
                item.ButtonClicked += (sender, e) => CustomItem_ButtonClicked2(sender, e, shoppingcart.IndexOf(item));

                panel2.Controls.Add(item);
                updatePrice();
            }

        }

        public void RemoveCustomItem(int index, int what)
        {
            if (what == 1)
            {
                if (index >= 0 && index < customItems.Count)
                {
                    // Unsubscribe from the events with correct syntax
                    customItems[index].ButtonClicked -= (sender, e) => CustomItem_ButtonClicked(sender, e, index);

                    panel1.Controls.Remove(customItems[index]);
                    customItems.RemoveAt(index);
                }
            }
            else if(what == 2)
            {
                if (index >= 0 && index < shoppingcart.Count)
                {
                    // Unsubscribe from the events with correct syntax
                    shoppingcart[index].ButtonClicked -= (sender, e) => CustomItem_ButtonClicked(sender, e, index);

                    panel2.Controls.Remove(shoppingcart[index]);
                    shoppingcart.RemoveAt(index);
                    updatePrice();
                }
            }
        }

        // Event handler for the Add button click event
        private void CustomItem_ButtonClicked(object sender, EventArgs e, int index)
        {
            AddCustomItem(customItems[index].copy(),2);
        }

        private void CustomItem_ButtonClicked2(object sender, EventArgs e, int index)
        {
            RemoveCustomItem(index, 2);
        }

        private void CustomItem_ButtonClicked3(object sender, EventArgs e)
        {
            MessageBox.Show("Danke für deinen Einkauf der Preis beträgt: " + calculatePrice() + "€");
            while (shoppingcart.Count != 0)
            {
                RemoveCustomItem(0, 2);
            }
            updatePrice();
        }

        private void updatePrice()
        {
            label.setText("Preis: " + calculatePrice() + "€");
        }

        private double calculatePrice()
        {

            double pricea = 0;
            foreach (CustomItem item in shoppingcart)
            {
                pricea += item.price;
            }
            return pricea;
        }

    }
}