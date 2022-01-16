namespace WeAreTheChampions
{
    partial class ColorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorForm));
            this.grbColor = new System.Windows.Forms.GroupBox();
            this.btnColorEdit = new System.Windows.Forms.Button();
            this.btnColorAdd = new System.Windows.Forms.Button();
            this.nudColorBlue = new System.Windows.Forms.NumericUpDown();
            this.nudColorGreen = new System.Windows.Forms.NumericUpDown();
            this.nudColorRed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstColors = new System.Windows.Forms.ListBox();
            this.grbColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorRed)).BeginInit();
            this.SuspendLayout();
            // 
            // grbColor
            // 
            this.grbColor.BackColor = System.Drawing.Color.Transparent;
            this.grbColor.Controls.Add(this.btnColorEdit);
            this.grbColor.Controls.Add(this.btnColorAdd);
            this.grbColor.Controls.Add(this.nudColorBlue);
            this.grbColor.Controls.Add(this.nudColorGreen);
            this.grbColor.Controls.Add(this.nudColorRed);
            this.grbColor.Controls.Add(this.label4);
            this.grbColor.Controls.Add(this.label3);
            this.grbColor.Controls.Add(this.label2);
            this.grbColor.Controls.Add(this.txtColorName);
            this.grbColor.Controls.Add(this.label1);
            this.grbColor.Location = new System.Drawing.Point(12, 12);
            this.grbColor.Name = "grbColor";
            this.grbColor.Size = new System.Drawing.Size(391, 189);
            this.grbColor.TabIndex = 0;
            this.grbColor.TabStop = false;
            this.grbColor.Text = "Add Color";
            // 
            // btnColorEdit
            // 
            this.btnColorEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnColorEdit.Location = new System.Drawing.Point(270, 81);
            this.btnColorEdit.Name = "btnColorEdit";
            this.btnColorEdit.Size = new System.Drawing.Size(79, 32);
            this.btnColorEdit.TabIndex = 10;
            this.btnColorEdit.Text = "Edit";
            this.btnColorEdit.UseVisualStyleBackColor = true;
            this.btnColorEdit.Click += new System.EventHandler(this.btnColorEdit_Click);
            // 
            // btnColorAdd
            // 
            this.btnColorAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnColorAdd.Location = new System.Drawing.Point(270, 33);
            this.btnColorAdd.Name = "btnColorAdd";
            this.btnColorAdd.Size = new System.Drawing.Size(79, 30);
            this.btnColorAdd.TabIndex = 1;
            this.btnColorAdd.Text = "Add";
            this.btnColorAdd.UseVisualStyleBackColor = true;
            this.btnColorAdd.Click += new System.EventHandler(this.btnColorAdd_Click);
            // 
            // nudColorBlue
            // 
            this.nudColorBlue.Location = new System.Drawing.Point(147, 151);
            this.nudColorBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudColorBlue.Name = "nudColorBlue";
            this.nudColorBlue.Size = new System.Drawing.Size(38, 20);
            this.nudColorBlue.TabIndex = 9;
            // 
            // nudColorGreen
            // 
            this.nudColorGreen.Location = new System.Drawing.Point(147, 115);
            this.nudColorGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudColorGreen.Name = "nudColorGreen";
            this.nudColorGreen.Size = new System.Drawing.Size(38, 20);
            this.nudColorGreen.TabIndex = 8;
            // 
            // nudColorRed
            // 
            this.nudColorRed.Location = new System.Drawing.Point(147, 84);
            this.nudColorRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudColorRed.Name = "nudColorRed";
            this.nudColorRed.Size = new System.Drawing.Size(38, 20);
            this.nudColorRed.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(82, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Red: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(82, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Blue: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(82, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Green: ";
            // 
            // txtColorName
            // 
            this.txtColorName.Location = new System.Drawing.Point(59, 43);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new System.Drawing.Size(133, 20);
            this.txtColorName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // lstColors
            // 
            this.lstColors.BackColor = System.Drawing.Color.LightCoral;
            this.lstColors.DisplayMember = "(none)";
            this.lstColors.FormattingEnabled = true;
            this.lstColors.Location = new System.Drawing.Point(12, 207);
            this.lstColors.Name = "lstColors";
            this.lstColors.Size = new System.Drawing.Size(229, 238);
            this.lstColors.TabIndex = 1;
            this.lstColors.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstColors_KeyDown);
            // 
            // ColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(415, 460);
            this.Controls.Add(this.lstColors);
            this.Controls.Add(this.grbColor);
            this.Name = "ColorForm";
            this.Text = "Color";
            this.grbColor.ResumeLayout(false);
            this.grbColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColorRed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbColor;
        private System.Windows.Forms.NumericUpDown nudColorRed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudColorBlue;
        private System.Windows.Forms.NumericUpDown nudColorGreen;
        private System.Windows.Forms.Button btnColorAdd;
        private System.Windows.Forms.Button btnColorEdit;
        private System.Windows.Forms.ListBox lstColors;
    }
}