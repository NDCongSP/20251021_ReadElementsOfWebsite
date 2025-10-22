namespace ConnectAndGetInfoOfWebsite
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._txtProductUrl = new System.Windows.Forms.TextBox();
            this._labUrlProduct = new System.Windows.Forms.Label();
            this._btnGetInformation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtProductCategory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtProductDescription = new System.Windows.Forms.TextBox();
            this._pic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this._txtProductImageUrl = new System.Windows.Forms.TextBox();
            this._btnImport = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this._txtBrandName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtNet = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._pic)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtProductUrl
            // 
            this._txtProductUrl.Location = new System.Drawing.Point(120, 49);
            this._txtProductUrl.Name = "_txtProductUrl";
            this._txtProductUrl.Size = new System.Drawing.Size(525, 20);
            this._txtProductUrl.TabIndex = 0;
            // 
            // _labUrlProduct
            // 
            this._labUrlProduct.AutoSize = true;
            this._labUrlProduct.Location = new System.Drawing.Point(13, 52);
            this._labUrlProduct.Name = "_labUrlProduct";
            this._labUrlProduct.Size = new System.Drawing.Size(69, 13);
            this._labUrlProduct.TabIndex = 1;
            this._labUrlProduct.Text = "Product URL";
            // 
            // _btnGetInformation
            // 
            this._btnGetInformation.Location = new System.Drawing.Point(662, 46);
            this._btnGetInformation.Name = "_btnGetInformation";
            this._btnGetInformation.Size = new System.Drawing.Size(113, 23);
            this._btnGetInformation.TabIndex = 2;
            this._btnGetInformation.Text = "Get Information";
            this._btnGetInformation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Product Name";
            // 
            // _txtProductName
            // 
            this._txtProductName.Location = new System.Drawing.Point(120, 147);
            this._txtProductName.Multiline = true;
            this._txtProductName.Name = "_txtProductName";
            this._txtProductName.ReadOnly = true;
            this._txtProductName.Size = new System.Drawing.Size(444, 40);
            this._txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product Categorry";
            // 
            // _txtProductCategory
            // 
            this._txtProductCategory.Location = new System.Drawing.Point(120, 277);
            this._txtProductCategory.Multiline = true;
            this._txtProductCategory.Name = "_txtProductCategory";
            this._txtProductCategory.ReadOnly = true;
            this._txtProductCategory.Size = new System.Drawing.Size(525, 65);
            this._txtProductCategory.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Product Description";
            // 
            // _txtProductDescription
            // 
            this._txtProductDescription.Location = new System.Drawing.Point(120, 348);
            this._txtProductDescription.Multiline = true;
            this._txtProductDescription.Name = "_txtProductDescription";
            this._txtProductDescription.ReadOnly = true;
            this._txtProductDescription.Size = new System.Drawing.Size(525, 263);
            this._txtProductDescription.TabIndex = 7;
            // 
            // _pic
            // 
            this._pic.Location = new System.Drawing.Point(662, 96);
            this._pic.Name = "_pic";
            this._pic.Size = new System.Drawing.Size(465, 515);
            this._pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pic.TabIndex = 9;
            this._pic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Product Image URL";
            // 
            // _txtProductImageUrl
            // 
            this._txtProductImageUrl.Location = new System.Drawing.Point(120, 202);
            this._txtProductImageUrl.Multiline = true;
            this._txtProductImageUrl.Name = "_txtProductImageUrl";
            this._txtProductImageUrl.ReadOnly = true;
            this._txtProductImageUrl.Size = new System.Drawing.Size(525, 40);
            this._txtProductImageUrl.TabIndex = 10;
            // 
            // _btnImport
            // 
            this._btnImport.Location = new System.Drawing.Point(802, 47);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(113, 23);
            this._btnImport.TabIndex = 12;
            this._btnImport.Text = "Import excel";
            this._btnImport.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Brand Name";
            // 
            // _txtBrandName
            // 
            this._txtBrandName.Location = new System.Drawing.Point(120, 96);
            this._txtBrandName.Multiline = true;
            this._txtBrandName.Name = "_txtBrandName";
            this._txtBrandName.ReadOnly = true;
            this._txtBrandName.Size = new System.Drawing.Size(525, 40);
            this._txtBrandName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(570, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Net";
            // 
            // _txtNet
            // 
            this._txtNet.Location = new System.Drawing.Point(573, 161);
            this._txtNet.Multiline = true;
            this._txtNet.Name = "_txtNet";
            this._txtNet.ReadOnly = true;
            this._txtNet.Size = new System.Drawing.Size(71, 26);
            this._txtNet.TabIndex = 15;
            // 
            // Form1
            // 
            this.AcceptButton = this._btnGetInformation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 646);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._txtNet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._txtBrandName);
            this.Controls.Add(this._btnImport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._txtProductImageUrl);
            this.Controls.Add(this._pic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtProductDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtProductCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtProductName);
            this.Controls.Add(this._btnGetInformation);
            this.Controls.Add(this._labUrlProduct);
            this.Controls.Add(this._txtProductUrl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Get Elements Information Of The Website";
            ((System.ComponentModel.ISupportInitialize)(this._pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtProductUrl;
        private System.Windows.Forms.Label _labUrlProduct;
        private System.Windows.Forms.Button _btnGetInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtProductCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtProductDescription;
        private System.Windows.Forms.PictureBox _pic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtProductImageUrl;
        private System.Windows.Forms.Button _btnImport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtBrandName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _txtNet;
    }
}

