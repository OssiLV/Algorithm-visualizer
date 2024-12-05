namespace Algorithm_visualizer
{
    partial class form_algorithmvisualizer
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
            this.cb_action = new System.Windows.Forms.ComboBox();
            this.btn_action = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_action
            // 
            this.cb_action.FormattingEnabled = true;
            this.cb_action.Location = new System.Drawing.Point(12, 12);
            this.cb_action.Name = "cb_action";
            this.cb_action.Size = new System.Drawing.Size(162, 24);
            this.cb_action.TabIndex = 1;
            // 
            // btn_action
            // 
            this.btn_action.Location = new System.Drawing.Point(180, 13);
            this.btn_action.Name = "btn_action";
            this.btn_action.Size = new System.Drawing.Size(75, 23);
            this.btn_action.TabIndex = 2;
            this.btn_action.Text = "Action";
            this.btn_action.UseVisualStyleBackColor = true;
            this.btn_action.Click += new System.EventHandler(this.btn_action_Click);
            // 
            // form_algorithmvisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_action);
            this.Controls.Add(this.cb_action);
            this.Name = "form_algorithmvisualizer";
            this.Text = "Algorithm Visualizer";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_action;
        private System.Windows.Forms.Button btn_action;
    }
}

