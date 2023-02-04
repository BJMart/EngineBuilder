namespace EngineBuilder
{
    partial class EngineBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineBuilder));
            this.cmbLayout = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEngineName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCylinders = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStroke = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtBore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.txtRPM = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGenerated = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtChamberVolume = new System.Windows.Forms.TextBox();
            this.txtRod = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbLayout
            // 
            this.cmbLayout.FormattingEnabled = true;
            this.cmbLayout.Items.AddRange(new object[] {
            "Straight",
            "V",
            "Boxer",
            "W(3 Bank)",
            "W(4 Bank)",
            "Radial",
            "Rotary(WIP)"});
            this.cmbLayout.Location = new System.Drawing.Point(12, 32);
            this.cmbLayout.Name = "cmbLayout";
            this.cmbLayout.Size = new System.Drawing.Size(121, 21);
            this.cmbLayout.TabIndex = 0;
            this.cmbLayout.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Engine Layout";
            // 
            // txtEngineName
            // 
            this.txtEngineName.Location = new System.Drawing.Point(15, 146);
            this.txtEngineName.Multiline = true;
            this.txtEngineName.Name = "txtEngineName";
            this.txtEngineName.Size = new System.Drawing.Size(197, 20);
            this.txtEngineName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Angle";
            // 
            // txtCylinders
            // 
            this.txtCylinders.Location = new System.Drawing.Point(186, 33);
            this.txtCylinders.Multiline = true;
            this.txtCylinders.Name = "txtCylinders";
            this.txtCylinders.Size = new System.Drawing.Size(41, 20);
            this.txtCylinders.TabIndex = 2;
            this.txtCylinders.TextChanged += new System.EventHandler(this.txtCylinders_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cylinders";
            // 
            // txtStroke
            // 
            this.txtStroke.Location = new System.Drawing.Point(77, 104);
            this.txtStroke.Multiline = true;
            this.txtStroke.Name = "txtStroke";
            this.txtStroke.Size = new System.Drawing.Size(41, 20);
            this.txtStroke.TabIndex = 2;
            this.txtStroke.TextChanged += new System.EventHandler(this.txtStroke_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Stroke";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(139, 104);
            this.txtCapacity.Multiline = true;
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(73, 20);
            this.txtCapacity.TabIndex = 2;
            this.txtCapacity.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Capacity (cc)";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(5, 291);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(227, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create Engine";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtBore
            // 
            this.txtBore.Location = new System.Drawing.Point(15, 104);
            this.txtBore.Multiline = true;
            this.txtBore.Name = "txtBore";
            this.txtBore.Size = new System.Drawing.Size(41, 20);
            this.txtBore.TabIndex = 2;
            this.txtBore.TextChanged += new System.EventHandler(this.txtBore_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bore";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Engine Name";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(139, 32);
            this.txtAngle.Multiline = true;
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(41, 20);
            this.txtAngle.TabIndex = 2;
            this.txtAngle.TextChanged += new System.EventHandler(this.txtCylinders_TextChanged);
            // 
            // txtRPM
            // 
            this.txtRPM.Location = new System.Drawing.Point(49, 59);
            this.txtRPM.Multiline = true;
            this.txtRPM.Name = "txtRPM";
            this.txtRPM.Size = new System.Drawing.Size(41, 20);
            this.txtRPM.TabIndex = 2;
            this.txtRPM.TextChanged += new System.EventHandler(this.txtBore_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "RPM";
            // 
            // lblGenerated
            // 
            this.lblGenerated.AutoSize = true;
            this.lblGenerated.Location = new System.Drawing.Point(12, 275);
            this.lblGenerated.Name = "lblGenerated";
            this.lblGenerated.Size = new System.Drawing.Size(0, 13);
            this.lblGenerated.TabIndex = 1;
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(15, 185);
            this.txtOrder.Multiline = true;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(197, 20);
            this.txtOrder.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Order";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Chamber Vol";
            // 
            // txtChamberVolume
            // 
            this.txtChamberVolume.Location = new System.Drawing.Point(15, 233);
            this.txtChamberVolume.Multiline = true;
            this.txtChamberVolume.Name = "txtChamberVolume";
            this.txtChamberVolume.Size = new System.Drawing.Size(64, 20);
            this.txtChamberVolume.TabIndex = 2;
            // 
            // txtRod
            // 
            this.txtRod.Location = new System.Drawing.Point(85, 233);
            this.txtRod.Multiline = true;
            this.txtRod.Name = "txtRod";
            this.txtRod.Size = new System.Drawing.Size(64, 20);
            this.txtRod.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(82, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Rod Length";
            // 
            // EngineBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 326);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.txtCylinders);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.txtRPM);
            this.Controls.Add(this.txtBore);
            this.Controls.Add(this.txtStroke);
            this.Controls.Add(this.txtRod);
            this.Controls.Add(this.txtChamberVolume);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.txtEngineName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblGenerated);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EngineBuilder";
            this.Text = "Engine Builder";
            this.Load += new System.EventHandler(this.EngineBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEngineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCylinders;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStroke;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtBore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.TextBox txtRPM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGenerated;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtChamberVolume;
        private System.Windows.Forms.TextBox txtRod;
        private System.Windows.Forms.Label label11;
    }
}

