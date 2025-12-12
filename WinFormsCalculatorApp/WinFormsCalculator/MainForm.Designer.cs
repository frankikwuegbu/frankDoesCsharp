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
            addbtn = new Button();
            evaluatebtn = new Button();
            subtractbtn = new Button();
            mulbtn = new Button();
            divbtn = new Button();
            clearbtn = new Button();
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
            button1.Location = new Point(12, 73);
            button1.Name = "button1";
            button1.Size = new Size(118, 89);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += screenNumbers;
            // 
            // button2
            // 
            button2.Location = new Point(149, 73);
            button2.Name = "button2";
            button2.Size = new Size(118, 89);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += screenNumbers;
            // 
            // button3
            // 
            button3.Location = new Point(287, 73);
            button3.Name = "button3";
            button3.Size = new Size(118, 89);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += screenNumbers;
            // 
            // button4
            // 
            button4.Location = new Point(12, 168);
            button4.Name = "button4";
            button4.Size = new Size(118, 89);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += screenNumbers;
            // 
            // button5
            // 
            button5.Location = new Point(149, 168);
            button5.Name = "button5";
            button5.Size = new Size(118, 89);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += screenNumbers;
            // 
            // button6
            // 
            button6.Location = new Point(287, 168);
            button6.Name = "button6";
            button6.Size = new Size(118, 89);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += screenNumbers;
            // 
            // button7
            // 
            button7.Location = new Point(12, 263);
            button7.Name = "button7";
            button7.Size = new Size(118, 89);
            button7.TabIndex = 7;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += screenNumbers;
            // 
            // button8
            // 
            button8.Location = new Point(149, 263);
            button8.Name = "button8";
            button8.Size = new Size(118, 89);
            button8.TabIndex = 8;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += screenNumbers;
            // 
            // button9
            // 
            button9.Location = new Point(287, 263);
            button9.Name = "button9";
            button9.Size = new Size(118, 89);
            button9.TabIndex = 9;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += screenNumbers;
            // 
            // button0
            // 
            button0.Location = new Point(149, 358);
            button0.Name = "button0";
            button0.Size = new Size(118, 89);
            button0.TabIndex = 10;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += screenNumbers;
            // 
            // addbtn
            // 
            addbtn.Location = new Point(12, 358);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(118, 89);
            addbtn.TabIndex = 11;
            addbtn.Tag = "Add";
            addbtn.Text = "+";
            addbtn.UseVisualStyleBackColor = true;
            addbtn.Click += clickOperator;
            // 
            // evaluatebtn
            // 
            evaluatebtn.Location = new Point(287, 358);
            evaluatebtn.Name = "evaluatebtn";
            evaluatebtn.Size = new Size(118, 89);
            evaluatebtn.TabIndex = 12;
            evaluatebtn.Tag = "Evaluate";
            evaluatebtn.Text = "=";
            evaluatebtn.UseVisualStyleBackColor = true;
            evaluatebtn.Click += clickEvaluate;
            // 
            // subtractbtn
            // 
            subtractbtn.Location = new Point(12, 453);
            subtractbtn.Name = "subtractbtn";
            subtractbtn.Size = new Size(118, 89);
            subtractbtn.TabIndex = 13;
            subtractbtn.Tag = "Subtract";
            subtractbtn.Text = "-";
            subtractbtn.UseVisualStyleBackColor = true;
            subtractbtn.Click += clickOperator;
            // 
            // mulbtn
            // 
            mulbtn.Location = new Point(149, 453);
            mulbtn.Name = "mulbtn";
            mulbtn.Size = new Size(118, 89);
            mulbtn.TabIndex = 14;
            mulbtn.Tag = "Multiply";
            mulbtn.Text = "*";
            mulbtn.UseVisualStyleBackColor = true;
            mulbtn.Click += clickOperator;
            // 
            // divbtn
            // 
            divbtn.Location = new Point(287, 453);
            divbtn.Name = "divbtn";
            divbtn.Size = new Size(118, 89);
            divbtn.TabIndex = 15;
            divbtn.Tag = "Divide";
            divbtn.Text = "/";
            divbtn.UseVisualStyleBackColor = true;
            divbtn.Click += clickOperator;
            // 
            // clearbtn
            // 
            clearbtn.Location = new Point(12, 548);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(393, 89);
            clearbtn.TabIndex = 16;
            clearbtn.Tag = "Clear";
            clearbtn.Text = "CLEAR";
            clearbtn.UseVisualStyleBackColor = true;
            clearbtn.Click += clickClear;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(18F, 34F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 666);
            Controls.Add(clearbtn);
            Controls.Add(divbtn);
            Controls.Add(mulbtn);
            Controls.Add(subtractbtn);
            Controls.Add(evaluatebtn);
            Controls.Add(addbtn);
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
            Click += clickOperator;
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
        private Button addbtn;
        private Button evaluatebtn;
        private Button subtractbtn;
        private Button mulbtn;
        private Button divbtn;
        private Button clearbtn;
    }
}
