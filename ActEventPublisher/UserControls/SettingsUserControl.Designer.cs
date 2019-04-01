namespace ActEventPublisher.UserControls
{
    partial class SettingsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.updateEndpointButton = new System.Windows.Forms.Button();
            this.endpointTextBox = new System.Windows.Forms.TextBox();
            this.endpointGroupBox = new System.Windows.Forms.GroupBox();
            this.endpointGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateEndpointButton
            // 
            this.updateEndpointButton.Location = new System.Drawing.Point(309, 19);
            this.updateEndpointButton.Name = "updateEndpointButton";
            this.updateEndpointButton.Size = new System.Drawing.Size(52, 20);
            this.updateEndpointButton.TabIndex = 3;
            this.updateEndpointButton.Text = "save";
            this.updateEndpointButton.UseVisualStyleBackColor = true;
            this.updateEndpointButton.Click += new System.EventHandler(this.updateEndpointButton_Click);
            // 
            // endpointTextBox
            // 
            this.endpointTextBox.Location = new System.Drawing.Point(6, 19);
            this.endpointTextBox.Name = "endpointTextBox";
            this.endpointTextBox.Size = new System.Drawing.Size(297, 20);
            this.endpointTextBox.TabIndex = 2;
            // 
            // endpointGroupBox
            // 
            this.endpointGroupBox.Controls.Add(this.endpointTextBox);
            this.endpointGroupBox.Controls.Add(this.updateEndpointButton);
            this.endpointGroupBox.Location = new System.Drawing.Point(3, 3);
            this.endpointGroupBox.Name = "endpointGroupBox";
            this.endpointGroupBox.Size = new System.Drawing.Size(371, 52);
            this.endpointGroupBox.TabIndex = 5;
            this.endpointGroupBox.TabStop = false;
            this.endpointGroupBox.Text = "Endpoint";
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.endpointGroupBox);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(636, 324);
            this.endpointGroupBox.ResumeLayout(false);
            this.endpointGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button updateEndpointButton;
        private System.Windows.Forms.TextBox endpointTextBox;
        private System.Windows.Forms.GroupBox endpointGroupBox;
    }
}
