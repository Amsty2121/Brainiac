namespace simplex
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.StartButton = new System.Windows.Forms.Button();
            this.inputData = new System.Windows.Forms.RichTextBox();
            this.outputData = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.variablesNumber = new System.Windows.Forms.TextBox();
            this.constraintsNumber = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkMax = new System.Windows.Forms.CheckBox();
            this.checkMin = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.inputSign = new System.Windows.Forms.RichTextBox();
            this.inputB = new System.Windows.Forms.RichTextBox();
            this.objectiveFunction = new System.Windows.Forms.RichTextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.StartButton.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.StartButton.Location = new System.Drawing.Point(527, 319);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(295, 61);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // inputData
            // 
            this.inputData.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.inputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputData.ForeColor = System.Drawing.Color.White;
            this.inputData.Location = new System.Drawing.Point(10, 231);
            this.inputData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputData.Name = "inputData";
            this.inputData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.inputData.Size = new System.Drawing.Size(297, 218);
            this.inputData.TabIndex = 5;
            this.inputData.Text = "";
            this.inputData.WordWrap = false;
            // 
            // outputData
            // 
            this.outputData.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.outputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputData.ForeColor = System.Drawing.Color.White;
            this.outputData.Location = new System.Drawing.Point(527, 69);
            this.outputData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.outputData.Name = "outputData";
            this.outputData.ReadOnly = true;
            this.outputData.Size = new System.Drawing.Size(295, 242);
            this.outputData.TabIndex = 6;
            this.outputData.Text = "";
            this.outputData.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox1.Location = new System.Drawing.Point(324, 199);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(52, 26);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Sign";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox2.Location = new System.Drawing.Point(394, 199);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(107, 26);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Free Terms";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox3.Location = new System.Drawing.Point(10, 199);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(297, 26);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "Subject to Constraints";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox4.Location = new System.Drawing.Point(10, 34);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(158, 26);
            this.textBox4.TabIndex = 12;
            this.textBox4.Text = "Total Variables";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox5.Location = new System.Drawing.Point(266, 34);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(159, 26);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "Total Constraints";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // variablesNumber
            // 
            this.variablesNumber.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.variablesNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.variablesNumber.ForeColor = System.Drawing.Color.White;
            this.variablesNumber.Location = new System.Drawing.Point(193, 34);
            this.variablesNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.variablesNumber.Name = "variablesNumber";
            this.variablesNumber.Size = new System.Drawing.Size(49, 26);
            this.variablesNumber.TabIndex = 14;
            // 
            // constraintsNumber
            // 
            this.constraintsNumber.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.constraintsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.constraintsNumber.ForeColor = System.Drawing.Color.White;
            this.constraintsNumber.Location = new System.Drawing.Point(452, 34);
            this.constraintsNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.constraintsNumber.Name = "constraintsNumber";
            this.constraintsNumber.Size = new System.Drawing.Size(49, 26);
            this.constraintsNumber.TabIndex = 15;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox6.Location = new System.Drawing.Point(9, 135);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(159, 27);
            this.textBox6.TabIndex = 16;
            this.textBox6.Text = "Objective Function";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox7.Location = new System.Drawing.Point(10, 86);
            this.textBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(158, 26);
            this.textBox7.TabIndex = 18;
            this.textBox7.Text = "Operation";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkMax
            // 
            this.checkMax.AutoSize = true;
            this.checkMax.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.checkMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkMax.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.checkMax.Location = new System.Drawing.Point(224, 88);
            this.checkMax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkMax.Name = "checkMax";
            this.checkMax.Size = new System.Drawing.Size(101, 24);
            this.checkMax.TabIndex = 20;
            this.checkMax.Text = "Maximize";
            this.checkMax.UseVisualStyleBackColor = false;
            // 
            // checkMin
            // 
            this.checkMin.AutoSize = true;
            this.checkMin.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.checkMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkMin.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.checkMin.Location = new System.Drawing.Point(384, 88);
            this.checkMin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkMin.Name = "checkMin";
            this.checkMin.Size = new System.Drawing.Size(97, 24);
            this.checkMin.TabIndex = 21;
            this.checkMin.Text = "Minimize";
            this.checkMin.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.button1.Location = new System.Drawing.Point(527, 388);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 61);
            this.button1.TabIndex = 22;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputSign
            // 
            this.inputSign.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.inputSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputSign.ForeColor = System.Drawing.Color.White;
            this.inputSign.Location = new System.Drawing.Point(324, 232);
            this.inputSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputSign.Name = "inputSign";
            this.inputSign.Size = new System.Drawing.Size(52, 217);
            this.inputSign.TabIndex = 23;
            this.inputSign.Text = "";
            this.inputSign.WordWrap = false;
            // 
            // inputB
            // 
            this.inputB.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.inputB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputB.ForeColor = System.Drawing.Color.White;
            this.inputB.Location = new System.Drawing.Point(394, 232);
            this.inputB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputB.Name = "inputB";
            this.inputB.Size = new System.Drawing.Size(107, 217);
            this.inputB.TabIndex = 24;
            this.inputB.Text = "";
            this.inputB.WordWrap = false;
            // 
            // objectiveFunction
            // 
            this.objectiveFunction.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.objectiveFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectiveFunction.ForeColor = System.Drawing.Color.White;
            this.objectiveFunction.Location = new System.Drawing.Point(192, 135);
            this.objectiveFunction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.objectiveFunction.Name = "objectiveFunction";
            this.objectiveFunction.Size = new System.Drawing.Size(309, 48);
            this.objectiveFunction.TabIndex = 25;
            this.objectiveFunction.Text = "";
            this.objectiveFunction.WordWrap = false;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox8.Location = new System.Drawing.Point(527, 33);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(295, 27);
            this.textBox8.TabIndex = 26;
            this.textBox8.Text = "Result";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::simplex.Properties.Resources.gradient_violet_dots_and_circles_geometric_shapes_on_dark_background_23_2148428979;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.objectiveFunction);
            this.Controls.Add(this.inputB);
            this.Controls.Add(this.inputSign);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkMin);
            this.Controls.Add(this.checkMax);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.constraintsNumber);
            this.Controls.Add(this.variablesNumber);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.outputData);
            this.Controls.Add(this.inputData);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Brainiac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.RichTextBox inputData;
        private System.Windows.Forms.RichTextBox outputData;
        private System.Windows.Forms.RichTextBox inputSign;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox variablesNumber;
        private System.Windows.Forms.TextBox constraintsNumber;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox checkMax;
        private System.Windows.Forms.CheckBox checkMin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox inputB;
        private System.Windows.Forms.RichTextBox objectiveFunction;
        private System.Windows.Forms.TextBox textBox8;
    }
}

