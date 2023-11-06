namespace _4FunBike
{
    partial class ShopApplication
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            bindingSource1 = new BindingSource(components);
            tabControl1 = new TabControl();
            productsTab = new TabPage();
            shoppingcardTab = new TabPage();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(productsTab);
            tabControl1.Controls.Add(shoppingcardTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // productsTab
            // 
            productsTab.AutoScroll = true;
            productsTab.Location = new Point(4, 24);
            productsTab.Name = "productsTab";
            productsTab.Size = new Size(792, 422);
            productsTab.TabIndex = 0;
            productsTab.Text = "Produkte";
            productsTab.UseVisualStyleBackColor = true;
            // 
            // shoppingcardTab
            // 
            shoppingcardTab.Location = new Point(4, 24);
            shoppingcardTab.Name = "shoppingcardTab";
            shoppingcardTab.Size = new Size(792, 422);
            shoppingcardTab.TabIndex = 0;
            shoppingcardTab.Text = "Warenkorb";
            shoppingcardTab.UseVisualStyleBackColor = true;
            // 
            // ShopApplication
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "ShopApplication";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private BindingSource bindingSource1;
        private TabControl tabControl1;
        private TabPage productsTab;
        private TabPage shoppingcardTab;
    }
}