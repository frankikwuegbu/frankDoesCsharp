namespace WinFormsCalculator
{
    partial class MainForm
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
            calculatorScreen = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button0 = new Button();
            add = new Button();
            result = new Button();
            SuspendLayout();
            // 
            // calculatorScreen
            // 
            calculatorScreen.Location = new Point(12, 12);
            calculatorScreen.Name = "calculatorScreen";
            calculatorScreen.Size = new Size(393, 41);
            calculatorScreen.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 101);
            button1.Name = "button1";
            button1.Size = new Size(118, 89);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ValueString;
            // 
            // button2
            // 
            button2.Location = new Point(149, 101);
            button2.Name = "button2";
            button2.Size = new Size(118, 89);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ValueString;
            // 
            // button3
            // 
            button3.Location = new Point(287, 101);
            button3.Name = "button3";
            button3.Size = new Size(118, 89);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ValueString;
            // 
            // button4
            // 
            button4.Location = new Point(12, 239);
            button4.Name = "button4";
            button4.Size = new Size(118, 89);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ValueString;
            // 
            // button5
            // 
            button5.Location = new Point(149, 239);
            button5.Name = "button5";
            button5.Size = new Size(118, 89);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += ValueString;
            // 
            // button6
            // 
            button6.Location = new Point(287, 239);
            button6.Name = "button6";
            button6.Size = new Size(118, 89);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ValueString;
            // 
            // button7
            // 
            button7.Location = new Point(12, 368);
            button7.Name = "button7";
            button7.Size = new Size(118, 89);
            button7.TabIndex = 7;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += ValueString;
            // 
            // button8
            // 
            button8.Location = new Point(149, 368);
            button8.Name = "button8";
            button8.Size = new Size(118, 89);
            button8.TabIndex = 8;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += ValueString;
            // 
            // button9
            // 
            button9.Location = new Point(287, 368);
            button9.Name = "button9";
            button9.Size = new Size(118, 89);
            button9.TabIndex = 9;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += ValueString;
            // 
            // button0
            // 
            button0.Location = new Point(149, 498);
            button0.Name = "button0";
            button0.Size = new Size(118, 89);
            button0.TabIndex = 10;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += ValueString;
            // 
            // add
            // 
            add.Location = new Point(12, 498);
            add.Name = "add";
            add.Size = new Size(118, 89);
            add.TabIndex = 11;
            add.Text = "+";
            add.UseVisualStyleBackColor = true;
            add.Click += calculationButton;
            // 
            // result
            // 
            result.Location = new Point(287, 498);
            result.Name = "result";
            result.Size = new Size(118, 89);
            result.TabIndex = 12;
            result.Text = "=";
            result.UseVisualStyleBackColor = true;
            result.Click += result_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 34F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 666);
            Controls.Add(result);
            Controls.Add(add);
            Controls.Add(button0);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(calculatorScreen);
            Font = new Font("Tahoma", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainForm";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox calculatorScreen;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button0;
        private Button add;
        private Button result;
    }
}
