namespace ComListener
{
    partial class GeneralForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralForm));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.labelHashStatus = new System.Windows.Forms.Label();
            this.bConnect = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTransmitterPowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dBmToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dBmToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.dBmToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxReceiverBytes = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonStatusUpdate = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonConnect.Location = new System.Drawing.Point(13, 56);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(149, 22);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Send Command";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCommand.Location = new System.Drawing.Point(10, 85);
            this.textBoxCommand.Multiline = true;
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.ReadOnly = true;
            this.textBoxCommand.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCommand.Size = new System.Drawing.Size(526, 207);
            this.textBoxCommand.TabIndex = 2;
            this.textBoxCommand.TextChanged += new System.EventHandler(this.textBoxCommand_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 20);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0x31";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 20);
            this.textBox2.MaxLength = 4;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(34, 23);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "0xff";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(90, 20);
            this.textBox3.MaxLength = 4;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(34, 23);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "0x06";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(129, 20);
            this.textBox4.MaxLength = 4;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(34, 23);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "0x";
            // 
            // labelHashStatus
            // 
            this.labelHashStatus.AutoSize = true;
            this.labelHashStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelHashStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHashStatus.Location = new System.Drawing.Point(314, 260);
            this.labelHashStatus.Name = "labelHashStatus";
            this.labelHashStatus.Size = new System.Drawing.Size(127, 16);
            this.labelHashStatus.TabIndex = 9;
            this.labelHashStatus.Text = "<Status HashCode>";
            this.labelHashStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bConnect
            // 
            this.bConnect.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bConnect.Location = new System.Drawing.Point(10, 300);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(138, 86);
            this.bConnect.TabIndex = 10;
            this.bConnect.Text = "Disconnect";
            this.bConnect.UseVisualStyleBackColor = false;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsToolStripMenuItem,
            this.logsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(710, 27);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataReadToolStripMenuItem,
            this.setAddressToolStripMenuItem,
            this.setTransmitterPowerToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(91, 23);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // dataReadToolStripMenuItem
            // 
            this.dataReadToolStripMenuItem.Name = "dataReadToolStripMenuItem";
            this.dataReadToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.dataReadToolStripMenuItem.Text = "Read data";
            this.dataReadToolStripMenuItem.Click += new System.EventHandler(this.dataReadToolStripMenuItem_Click);
            // 
            // setAddressToolStripMenuItem
            // 
            this.setAddressToolStripMenuItem.Name = "setAddressToolStripMenuItem";
            this.setAddressToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.setAddressToolStripMenuItem.Text = "Set address";
            this.setAddressToolStripMenuItem.Click += new System.EventHandler(this.setAddressToolStripMenuItem_Click);
            // 
            // setTransmitterPowerToolStripMenuItem
            // 
            this.setTransmitterPowerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dBmToolStripMenuItem,
            this.dBmToolStripMenuItem1,
            this.dBmToolStripMenuItem2,
            this.dBmToolStripMenuItem3,
            this.dBmToolStripMenuItem4});
            this.setTransmitterPowerToolStripMenuItem.Name = "setTransmitterPowerToolStripMenuItem";
            this.setTransmitterPowerToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.setTransmitterPowerToolStripMenuItem.Text = "Set transmitter power";
            // 
            // dBmToolStripMenuItem
            // 
            this.dBmToolStripMenuItem.Name = "dBmToolStripMenuItem";
            this.dBmToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.dBmToolStripMenuItem.Text = "-21 dBm";
            this.dBmToolStripMenuItem.Click += new System.EventHandler(this.dBmToolStripMenuItem_Click);
            // 
            // dBmToolStripMenuItem1
            // 
            this.dBmToolStripMenuItem1.Name = "dBmToolStripMenuItem1";
            this.dBmToolStripMenuItem1.Size = new System.Drawing.Size(134, 24);
            this.dBmToolStripMenuItem1.Text = "-9 dBm";
            this.dBmToolStripMenuItem1.Click += new System.EventHandler(this.dBmToolStripMenuItem1_Click);
            // 
            // dBmToolStripMenuItem2
            // 
            this.dBmToolStripMenuItem2.Name = "dBmToolStripMenuItem2";
            this.dBmToolStripMenuItem2.Size = new System.Drawing.Size(134, 24);
            this.dBmToolStripMenuItem2.Text = "0 dBm";
            this.dBmToolStripMenuItem2.Click += new System.EventHandler(this.dBmToolStripMenuItem2_Click);
            // 
            // dBmToolStripMenuItem3
            // 
            this.dBmToolStripMenuItem3.Name = "dBmToolStripMenuItem3";
            this.dBmToolStripMenuItem3.Size = new System.Drawing.Size(134, 24);
            this.dBmToolStripMenuItem3.Text = "+2 dBm";
            this.dBmToolStripMenuItem3.Click += new System.EventHandler(this.dBmToolStripMenuItem3_Click);
            // 
            // dBmToolStripMenuItem4
            // 
            this.dBmToolStripMenuItem4.Name = "dBmToolStripMenuItem4";
            this.dBmToolStripMenuItem4.Size = new System.Drawing.Size(134, 24);
            this.dBmToolStripMenuItem4.Text = "+5 dBm";
            this.dBmToolStripMenuItem4.Click += new System.EventHandler(this.dBmToolStripMenuItem4_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.logsToolStripMenuItem.Text = "Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Roboto", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox5.Location = new System.Drawing.Point(177, 300);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(139, 86);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "COM";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Location = new System.Drawing.Point(360, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 86);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Roboto", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(10, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 37);
            this.button1.TabIndex = 16;
            this.button1.Text = "Read data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Roboto", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(112, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 37);
            this.button2.TabIndex = 17;
            this.button2.Text = "Set address";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxReceiverBytes
            // 
            this.textBoxReceiverBytes.Font = new System.Drawing.Font("Roboto", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxReceiverBytes.Location = new System.Drawing.Point(362, 38);
            this.textBoxReceiverBytes.MaxLength = 4;
            this.textBoxReceiverBytes.Name = "textBoxReceiverBytes";
            this.textBoxReceiverBytes.Size = new System.Drawing.Size(161, 33);
            this.textBoxReceiverBytes.TabIndex = 9;
            this.textBoxReceiverBytes.Text = "<ReceiverBytes>";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(559, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(138, 341);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set transmitter power";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 56);
            this.button3.TabIndex = 5;
            this.button3.Text = "Set";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(36, 154);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(66, 21);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "5 dBm";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(36, 128);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(66, 21);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "2 dBm";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(36, 78);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 21);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "-9 dBm";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(36, 103);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(66, 21);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "0 dBm";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(36, 52);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "-21 dBm";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonStatusUpdate
            // 
            this.buttonStatusUpdate.Font = new System.Drawing.Font("Roboto", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatusUpdate.Location = new System.Drawing.Point(251, 35);
            this.buttonStatusUpdate.Name = "buttonStatusUpdate";
            this.buttonStatusUpdate.Size = new System.Drawing.Size(105, 37);
            this.buttonStatusUpdate.TabIndex = 20;
            this.buttonStatusUpdate.Text = "Status update";
            this.buttonStatusUpdate.UseVisualStyleBackColor = true;
            this.buttonStatusUpdate.Click += new System.EventHandler(this.buttonStatusUpdate_Click);
            // 
            // GeneralForm
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(710, 398);
            this.Controls.Add(this.buttonStatusUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxReceiverBytes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.labelHashStatus);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Roboto", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GeneralForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COM Listener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.GeneralForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label labelHashStatus;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTransmitterPowerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dBmToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dBmToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem dBmToolStripMenuItem4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxReceiverBytes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button buttonStatusUpdate;
    }
}

