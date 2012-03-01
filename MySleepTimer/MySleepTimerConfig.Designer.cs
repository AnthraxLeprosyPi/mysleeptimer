namespace MySleepTimer
{
  partial class MySleepTimerConfig
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
      this.comboBoxActionType = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.numericUpDownSleepTimeMax = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownSleepTimeStep = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownNotifyInterval = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.comboBoxShutDownType = new System.Windows.Forms.ComboBox();
      this.checkBoxShutDownForce = new System.Windows.Forms.CheckBox();
      this.label7 = new System.Windows.Forms.Label();
      this.numericUpDownNotifyBeforeSleep = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBoxSleepBehavior = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.numericUpDownTimeOutB = new System.Windows.Forms.NumericUpDown();
      this.label9 = new System.Windows.Forms.Label();
      this.numericUpDownTimeOutN = new System.Windows.Forms.NumericUpDown();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkBoxUsePSSettings = new System.Windows.Forms.CheckBox();
      this.groupBoxTimer = new System.Windows.Forms.GroupBox();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleepTimeMax)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleepTimeStep)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNotifyInterval)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNotifyBeforeSleep)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOutB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOutN)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBoxTimer.SuspendLayout();
      this.SuspendLayout();
      // 
      // comboBoxActionType
      // 
      this.comboBoxActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxActionType.DropDownWidth = 250;
      this.comboBoxActionType.FormattingEnabled = true;
      this.comboBoxActionType.Location = new System.Drawing.Point(169, 6);
      this.comboBoxActionType.Name = "comboBoxActionType";
      this.comboBoxActionType.Size = new System.Drawing.Size(168, 21);
      this.comboBoxActionType.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(146, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "ActionType to set sleep timer:";
      // 
      // numericUpDownSleepTimeMax
      // 
      this.numericUpDownSleepTimeMax.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericUpDownSleepTimeMax.Location = new System.Drawing.Point(210, 19);
      this.numericUpDownSleepTimeMax.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
      this.numericUpDownSleepTimeMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownSleepTimeMax.Name = "numericUpDownSleepTimeMax";
      this.numericUpDownSleepTimeMax.Size = new System.Drawing.Size(71, 20);
      this.numericUpDownSleepTimeMax.TabIndex = 25;
      this.numericUpDownSleepTimeMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // numericUpDownSleepTimeStep
      // 
      this.numericUpDownSleepTimeStep.Location = new System.Drawing.Point(210, 45);
      this.numericUpDownSleepTimeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownSleepTimeStep.Name = "numericUpDownSleepTimeStep";
      this.numericUpDownSleepTimeStep.Size = new System.Drawing.Size(71, 20);
      this.numericUpDownSleepTimeStep.TabIndex = 30;
      this.numericUpDownSleepTimeStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // numericUpDownNotifyInterval
      // 
      this.numericUpDownNotifyInterval.Location = new System.Drawing.Point(210, 123);
      this.numericUpDownNotifyInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownNotifyInterval.Name = "numericUpDownNotifyInterval";
      this.numericUpDownNotifyInterval.Size = new System.Drawing.Size(71, 20);
      this.numericUpDownNotifyInterval.TabIndex = 45;
      this.numericUpDownNotifyInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownNotifyInterval.ValueChanged += new System.EventHandler(this.numericUpDownNotifyInterval_ValueChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(94, 21);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(105, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Sleep time maximum:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(112, 47);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(87, 13);
      this.label5.TabIndex = 0;
      this.label5.Text = "Sleep time steps:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(98, 125);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(101, 13);
      this.label8.TabIndex = 0;
      this.label8.Text = "Notification Interval:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 45);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(81, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Shutdown type:";
      // 
      // comboBoxShutDownType
      // 
      this.comboBoxShutDownType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.comboBoxShutDownType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxShutDownType.FormattingEnabled = true;
      this.comboBoxShutDownType.Location = new System.Drawing.Point(93, 42);
      this.comboBoxShutDownType.Name = "comboBoxShutDownType";
      this.comboBoxShutDownType.Size = new System.Drawing.Size(171, 21);
      this.comboBoxShutDownType.TabIndex = 15;
      // 
      // checkBoxShutDownForce
      // 
      this.checkBoxShutDownForce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.checkBoxShutDownForce.AutoSize = true;
      this.checkBoxShutDownForce.Location = new System.Drawing.Point(270, 44);
      this.checkBoxShutDownForce.Name = "checkBoxShutDownForce";
      this.checkBoxShutDownForce.Size = new System.Drawing.Size(50, 17);
      this.checkBoxShutDownForce.TabIndex = 20;
      this.checkBoxShutDownForce.Text = "force";
      this.checkBoxShutDownForce.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(50, 99);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(149, 13);
      this.label7.TabIndex = 0;
      this.label7.Text = "Start notification prior to sleep:";
      // 
      // numericUpDownNotifyBeforeSleep
      // 
      this.numericUpDownNotifyBeforeSleep.Location = new System.Drawing.Point(210, 97);
      this.numericUpDownNotifyBeforeSleep.Name = "numericUpDownNotifyBeforeSleep";
      this.numericUpDownNotifyBeforeSleep.Size = new System.Drawing.Size(71, 20);
      this.numericUpDownNotifyBeforeSleep.TabIndex = 40;
      this.numericUpDownNotifyBeforeSleep.ValueChanged += new System.EventHandler(this.numericUpDownNotifyBeforeSleep_ValueChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(77, 35);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(81, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Sleep behavior:";
      // 
      // comboBoxSleepBehavior
      // 
      this.comboBoxSleepBehavior.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
      this.comboBoxSleepBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxSleepBehavior.DropDownWidth = 250;
      this.comboBoxSleepBehavior.FormattingEnabled = true;
      this.comboBoxSleepBehavior.Items.AddRange(new object[] {
            "Shutdown",
            "Exit MediaPortal",
            "Show Basic Home"});
      this.comboBoxSleepBehavior.Location = new System.Drawing.Point(169, 33);
      this.comboBoxSleepBehavior.Name = "comboBoxSleepBehavior";
      this.comboBoxSleepBehavior.Size = new System.Drawing.Size(168, 21);
      this.comboBoxSleepBehavior.TabIndex = 10;
      this.comboBoxSleepBehavior.SelectedIndexChanged += new System.EventHandler(this.comboBoxSleepBehavior_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(101, 73);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(98, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "Button TimeOut [s]:";
      // 
      // numericUpDownTimeOutB
      // 
      this.numericUpDownTimeOutB.Location = new System.Drawing.Point(210, 71);
      this.numericUpDownTimeOutB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownTimeOutB.Name = "numericUpDownTimeOutB";
      this.numericUpDownTimeOutB.Size = new System.Drawing.Size(71, 20);
      this.numericUpDownTimeOutB.TabIndex = 35;
      this.numericUpDownTimeOutB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(79, 151);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(120, 13);
      this.label9.TabIndex = 0;
      this.label9.Text = "Notification TimeOut [s]:";
      // 
      // numericUpDownTimeOutN
      // 
      this.numericUpDownTimeOutN.Location = new System.Drawing.Point(210, 149);
      this.numericUpDownTimeOutN.Maximum = new decimal(new int[] {
            65,
            0,
            0,
            0});
      this.numericUpDownTimeOutN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownTimeOutN.Name = "numericUpDownTimeOutN";
      this.numericUpDownTimeOutN.Size = new System.Drawing.Size(71, 20);
      this.numericUpDownTimeOutN.TabIndex = 50;
      this.numericUpDownTimeOutN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.checkBoxUsePSSettings);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.comboBoxShutDownType);
      this.groupBox1.Controls.Add(this.checkBoxShutDownForce);
      this.groupBox1.Location = new System.Drawing.Point(12, 73);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(326, 75);
      this.groupBox1.TabIndex = 56;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Shutdown options";
      // 
      // checkBoxUsePSSettings
      // 
      this.checkBoxUsePSSettings.AutoSize = true;
      this.checkBoxUsePSSettings.Location = new System.Drawing.Point(9, 19);
      this.checkBoxUsePSSettings.Name = "checkBoxUsePSSettings";
      this.checkBoxUsePSSettings.Size = new System.Drawing.Size(234, 17);
      this.checkBoxUsePSSettings.TabIndex = 21;
      this.checkBoxUsePSSettings.Text = "Use settings of Powerscheduler client plugin";
      this.checkBoxUsePSSettings.UseVisualStyleBackColor = true;
      this.checkBoxUsePSSettings.CheckedChanged += new System.EventHandler(this.checkBoxUsePSSettings_CheckedChanged);
      // 
      // groupBoxTimer
      // 
      this.groupBoxTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBoxTimer.Controls.Add(this.label4);
      this.groupBoxTimer.Controls.Add(this.numericUpDownSleepTimeMax);
      this.groupBoxTimer.Controls.Add(this.label9);
      this.groupBoxTimer.Controls.Add(this.numericUpDownSleepTimeStep);
      this.groupBoxTimer.Controls.Add(this.numericUpDownTimeOutN);
      this.groupBoxTimer.Controls.Add(this.numericUpDownNotifyInterval);
      this.groupBoxTimer.Controls.Add(this.label6);
      this.groupBoxTimer.Controls.Add(this.label5);
      this.groupBoxTimer.Controls.Add(this.numericUpDownTimeOutB);
      this.groupBoxTimer.Controls.Add(this.label8);
      this.groupBoxTimer.Controls.Add(this.numericUpDownNotifyBeforeSleep);
      this.groupBoxTimer.Controls.Add(this.label7);
      this.groupBoxTimer.Location = new System.Drawing.Point(12, 154);
      this.groupBoxTimer.Name = "groupBoxTimer";
      this.groupBoxTimer.Size = new System.Drawing.Size(326, 181);
      this.groupBoxTimer.TabIndex = 57;
      this.groupBoxTimer.TabStop = false;
      this.groupBoxTimer.Text = "Timer && notify settings";
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(263, 341);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 58;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(182, 341);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 59;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // MySleepTimerConfig
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(350, 372);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.groupBoxTimer);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.comboBoxSleepBehavior);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBoxActionType);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MySleepTimerConfig";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "MySleepTimer - Configuration";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleepTimeMax)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSleepTimeStep)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNotifyInterval)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNotifyBeforeSleep)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOutB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeOutN)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBoxTimer.ResumeLayout(false);
      this.groupBoxTimer.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox comboBoxActionType;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown numericUpDownSleepTimeMax;
    private System.Windows.Forms.NumericUpDown numericUpDownSleepTimeStep;
    private System.Windows.Forms.NumericUpDown numericUpDownNotifyInterval;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboBoxShutDownType;
    private System.Windows.Forms.CheckBox checkBoxShutDownForce;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown numericUpDownNotifyBeforeSleep;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBoxSleepBehavior;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown numericUpDownTimeOutB;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.NumericUpDown numericUpDownTimeOutN;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox checkBoxUsePSSettings;
    private System.Windows.Forms.GroupBox groupBoxTimer;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
  }
}