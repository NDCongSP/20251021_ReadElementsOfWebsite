namespace ConnectAndGetInfoOfWebsite
{
    partial class frmImport
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
            this._btnImport = new System.Windows.Forms.Button();
            this._btnExport = new System.Windows.Forms.Button();
            this._grv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._grv)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnImport
            // 
            this._btnImport.Location = new System.Drawing.Point(12, 12);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(113, 23);
            this._btnImport.TabIndex = 13;
            this._btnImport.Text = "Import excel";
            this._btnImport.UseVisualStyleBackColor = true;
            // 
            // _btnExport
            // 
            this._btnExport.Location = new System.Drawing.Point(144, 12);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(113, 23);
            this._btnExport.TabIndex = 14;
            this._btnExport.Text = "Export excel";
            this._btnExport.UseVisualStyleBackColor = true;
            // 
            // _grv
            // 
            this._grv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grv.Location = new System.Drawing.Point(13, 68);
            this._grv.Name = "_grv";
            this._grv.Size = new System.Drawing.Size(1171, 698);
            this._grv.TabIndex = 15;
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 778);
            this.Controls.Add(this._grv);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._btnImport);
            this.Name = "frmImport";
            this.Text = "frmImport";
            ((System.ComponentModel.ISupportInitialize)(this._grv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnImport;
        private System.Windows.Forms.Button _btnExport;
        private System.Windows.Forms.DataGridView _grv;
    }
}