namespace oneXDisconnect
{
    partial class Form1
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
            panelTypeHook = new MaterialSkin.Controls.MaterialExpansionPanel();
            radioClamping = new MaterialSkin.Controls.MaterialRadioButton();
            radioSwitcher = new MaterialSkin.Controls.MaterialRadioButton();
            radioHolder = new MaterialSkin.Controls.MaterialRadioButton();
            txtHolderTimer = new MaterialSkin.Controls.MaterialTextBox();
            panelRuleConfig = new MaterialSkin.Controls.MaterialExpansionPanel();
            txtAppFilepath = new MaterialSkin.Controls.MaterialTextBox();
            chkOut = new MaterialSkin.Controls.MaterialCheckbox();
            chkIn = new MaterialSkin.Controls.MaterialCheckbox();
            btnSetFilepath = new MaterialSkin.Controls.MaterialButton();
            comboDevice = new MaterialSkin.Controls.MaterialComboBox();
            txtHotKey = new MaterialSkin.Controls.MaterialTextBox();
            btnHook = new MaterialSkin.Controls.MaterialButton();
            btnUnhook = new MaterialSkin.Controls.MaterialButton();
            btnEditHotKey = new MaterialSkin.Controls.MaterialButton();
            panelTypeHook.SuspendLayout();
            panelRuleConfig.SuspendLayout();
            SuspendLayout();
            // 
            // panelTypeHook
            // 
            panelTypeHook.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTypeHook.BackColor = Color.FromArgb(255, 255, 255);
            panelTypeHook.BorderStyle = BorderStyle.FixedSingle;
            panelTypeHook.CancelButtonText = "";
            panelTypeHook.Collapse = true;
            panelTypeHook.Controls.Add(radioClamping);
            panelTypeHook.Controls.Add(radioSwitcher);
            panelTypeHook.Controls.Add(radioHolder);
            panelTypeHook.Controls.Add(txtHolderTimer);
            panelTypeHook.Depth = 0;
            panelTypeHook.Description = "";
            panelTypeHook.ExpandHeight = 200;
            panelTypeHook.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelTypeHook.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelTypeHook.Location = new Point(26, 80);
            panelTypeHook.Margin = new Padding(16, 1, 16, 0);
            panelTypeHook.MouseState = MaterialSkin.MouseState.HOVER;
            panelTypeHook.Name = "panelTypeHook";
            panelTypeHook.Padding = new Padding(24, 64, 24, 16);
            panelTypeHook.ShowValidationButtons = false;
            panelTypeHook.Size = new Size(307, 48);
            panelTypeHook.TabIndex = 28;
            panelTypeHook.Title = "Type hook";
            panelTypeHook.ValidationButtonText = "";
            // 
            // radioClamping
            // 
            radioClamping.AutoSize = true;
            radioClamping.Depth = 0;
            radioClamping.Location = new Point(24, 64);
            radioClamping.Margin = new Padding(0);
            radioClamping.MouseLocation = new Point(-1, -1);
            radioClamping.MouseState = MaterialSkin.MouseState.HOVER;
            radioClamping.Name = "radioClamping";
            radioClamping.Ripple = true;
            radioClamping.Size = new Size(103, 37);
            radioClamping.TabIndex = 7;
            radioClamping.TabStop = true;
            radioClamping.Text = "Clamping";
            radioClamping.UseVisualStyleBackColor = true;
            radioClamping.CheckedChanged += radioClamping_CheckedChanged;
            // 
            // radioSwitcher
            // 
            radioSwitcher.AutoSize = true;
            radioSwitcher.Depth = 0;
            radioSwitcher.Location = new Point(24, 101);
            radioSwitcher.Margin = new Padding(0);
            radioSwitcher.MouseLocation = new Point(-1, -1);
            radioSwitcher.MouseState = MaterialSkin.MouseState.HOVER;
            radioSwitcher.Name = "radioSwitcher";
            radioSwitcher.Ripple = true;
            radioSwitcher.Size = new Size(96, 37);
            radioSwitcher.TabIndex = 8;
            radioSwitcher.TabStop = true;
            radioSwitcher.Text = "Switcher";
            radioSwitcher.UseVisualStyleBackColor = true;
            radioSwitcher.CheckedChanged += radioSwitcher_CheckedChanged;
            // 
            // radioHolder
            // 
            radioHolder.AutoSize = true;
            radioHolder.Depth = 0;
            radioHolder.Location = new Point(24, 138);
            radioHolder.Margin = new Padding(0);
            radioHolder.MouseLocation = new Point(-1, -1);
            radioHolder.MouseState = MaterialSkin.MouseState.HOVER;
            radioHolder.Name = "radioHolder";
            radioHolder.Ripple = true;
            radioHolder.Size = new Size(81, 37);
            radioHolder.TabIndex = 9;
            radioHolder.TabStop = true;
            radioHolder.Text = "Holder";
            radioHolder.UseVisualStyleBackColor = true;
            radioHolder.CheckedChanged += radioHolder_CheckedChanged;
            // 
            // txtHolderTimer
            // 
            txtHolderTimer.AnimateReadOnly = false;
            txtHolderTimer.BorderStyle = BorderStyle.None;
            txtHolderTimer.Depth = 0;
            txtHolderTimer.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtHolderTimer.Hint = "(sec)";
            txtHolderTimer.LeadingIcon = null;
            txtHolderTimer.LeaveOnEnterKey = true;
            txtHolderTimer.Location = new Point(130, 130);
            txtHolderTimer.MaxLength = 50;
            txtHolderTimer.MouseState = MaterialSkin.MouseState.OUT;
            txtHolderTimer.Multiline = false;
            txtHolderTimer.Name = "txtHolderTimer";
            txtHolderTimer.Size = new Size(80, 50);
            txtHolderTimer.TabIndex = 10;
            txtHolderTimer.Text = "";
            txtHolderTimer.TrailingIcon = null;
            txtHolderTimer.UseAccent = false;
            txtHolderTimer.WordWrap = false;
            txtHolderTimer.Leave += txtHolderTimer_Leave;
            // 
            // panelRuleConfig
            // 
            panelRuleConfig.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelRuleConfig.BackColor = Color.FromArgb(255, 255, 255);
            panelRuleConfig.BorderStyle = BorderStyle.FixedSingle;
            panelRuleConfig.CancelButtonText = "";
            panelRuleConfig.Collapse = true;
            panelRuleConfig.Controls.Add(txtAppFilepath);
            panelRuleConfig.Controls.Add(chkOut);
            panelRuleConfig.Controls.Add(chkIn);
            panelRuleConfig.Controls.Add(btnSetFilepath);
            panelRuleConfig.Depth = 0;
            panelRuleConfig.Description = "";
            panelRuleConfig.ExpandHeight = 200;
            panelRuleConfig.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelRuleConfig.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelRuleConfig.Location = new Point(26, 149);
            panelRuleConfig.Margin = new Padding(16, 1, 16, 0);
            panelRuleConfig.MouseState = MaterialSkin.MouseState.HOVER;
            panelRuleConfig.Name = "panelRuleConfig";
            panelRuleConfig.Padding = new Padding(24, 64, 24, 16);
            panelRuleConfig.ShowValidationButtons = false;
            panelRuleConfig.Size = new Size(307, 48);
            panelRuleConfig.TabIndex = 29;
            panelRuleConfig.Title = "Rule config";
            panelRuleConfig.ValidationButtonText = "";
            // 
            // txtAppFilepath
            // 
            txtAppFilepath.AnimateReadOnly = true;
            txtAppFilepath.BorderStyle = BorderStyle.None;
            txtAppFilepath.Depth = 0;
            txtAppFilepath.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAppFilepath.Hint = "Filepath";
            txtAppFilepath.LeadingIcon = null;
            txtAppFilepath.Location = new Point(18, 65);
            txtAppFilepath.MaxLength = 250;
            txtAppFilepath.MouseState = MaterialSkin.MouseState.OUT;
            txtAppFilepath.Multiline = false;
            txtAppFilepath.Name = "txtAppFilepath";
            txtAppFilepath.ReadOnly = true;
            txtAppFilepath.Size = new Size(190, 50);
            txtAppFilepath.TabIndex = 27;
            txtAppFilepath.Text = "";
            txtAppFilepath.TrailingIcon = null;
            txtAppFilepath.WordWrap = false;
            // 
            // chkOut
            // 
            chkOut.AutoSize = true;
            chkOut.Depth = 0;
            chkOut.Location = new Point(60, 133);
            chkOut.Margin = new Padding(0);
            chkOut.MouseLocation = new Point(-1, -1);
            chkOut.MouseState = MaterialSkin.MouseState.HOVER;
            chkOut.Name = "chkOut";
            chkOut.ReadOnly = false;
            chkOut.Ripple = true;
            chkOut.Size = new Size(60, 37);
            chkOut.TabIndex = 19;
            chkOut.Text = "Out";
            chkOut.UseVisualStyleBackColor = true;
            chkOut.CheckedChanged += chkOut_CheckedChanged;
            // 
            // chkIn
            // 
            chkIn.AutoSize = true;
            chkIn.Depth = 0;
            chkIn.Location = new Point(132, 133);
            chkIn.Margin = new Padding(0);
            chkIn.MouseLocation = new Point(-1, -1);
            chkIn.MouseState = MaterialSkin.MouseState.HOVER;
            chkIn.Name = "chkIn";
            chkIn.ReadOnly = false;
            chkIn.Ripple = true;
            chkIn.Size = new Size(48, 37);
            chkIn.TabIndex = 20;
            chkIn.Text = "In";
            chkIn.UseVisualStyleBackColor = true;
            chkIn.CheckedChanged += chkIn_CheckedChanged;
            // 
            // btnSetFilepath
            // 
            btnSetFilepath.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSetFilepath.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSetFilepath.Depth = 0;
            btnSetFilepath.HighEmphasis = true;
            btnSetFilepath.Icon = null;
            btnSetFilepath.Location = new Point(215, 72);
            btnSetFilepath.Margin = new Padding(4, 6, 4, 6);
            btnSetFilepath.MouseState = MaterialSkin.MouseState.HOVER;
            btnSetFilepath.Name = "btnSetFilepath";
            btnSetFilepath.NoAccentTextColor = Color.Empty;
            btnSetFilepath.Size = new Size(64, 36);
            btnSetFilepath.TabIndex = 21;
            btnSetFilepath.Text = "PATH";
            btnSetFilepath.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSetFilepath.UseAccentColor = false;
            btnSetFilepath.UseVisualStyleBackColor = true;
            btnSetFilepath.Click += btnSetFilepath_Click;
            // 
            // comboDevice
            // 
            comboDevice.Anchor = AnchorStyles.None;
            comboDevice.AutoResize = false;
            comboDevice.BackColor = Color.FromArgb(255, 255, 255);
            comboDevice.Depth = 0;
            comboDevice.DrawMode = DrawMode.OwnerDrawVariable;
            comboDevice.DropDownHeight = 174;
            comboDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDevice.DropDownWidth = 121;
            comboDevice.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboDevice.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboDevice.FormattingEnabled = true;
            comboDevice.Hint = "Device";
            comboDevice.IntegralHeight = false;
            comboDevice.ItemHeight = 43;
            comboDevice.Items.AddRange(new object[] { "Keyboard", "Mouse", "Controller" });
            comboDevice.Location = new Point(45, 232);
            comboDevice.MaxDropDownItems = 4;
            comboDevice.MouseState = MaterialSkin.MouseState.OUT;
            comboDevice.Name = "comboDevice";
            comboDevice.Size = new Size(190, 49);
            comboDevice.StartIndex = 0;
            comboDevice.TabIndex = 38;
            comboDevice.SelectedIndexChanged += comboDevice_SelectedIndexChanged;
            // 
            // txtHotKey
            // 
            txtHotKey.Anchor = AnchorStyles.None;
            txtHotKey.AnimateReadOnly = false;
            txtHotKey.BorderStyle = BorderStyle.None;
            txtHotKey.Depth = 0;
            txtHotKey.Enabled = false;
            txtHotKey.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtHotKey.Hint = "Hot-Key";
            txtHotKey.LeadingIcon = null;
            txtHotKey.Location = new Point(45, 301);
            txtHotKey.MaxLength = 50;
            txtHotKey.MouseState = MaterialSkin.MouseState.OUT;
            txtHotKey.Multiline = false;
            txtHotKey.Name = "txtHotKey";
            txtHotKey.Size = new Size(190, 50);
            txtHotKey.TabIndex = 39;
            txtHotKey.Text = "";
            txtHotKey.TrailingIcon = null;
            // 
            // btnHook
            // 
            btnHook.Anchor = AnchorStyles.None;
            btnHook.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHook.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnHook.Depth = 0;
            btnHook.HighEmphasis = true;
            btnHook.Icon = null;
            btnHook.Location = new Point(199, 376);
            btnHook.Margin = new Padding(4, 6, 4, 6);
            btnHook.MouseState = MaterialSkin.MouseState.HOVER;
            btnHook.Name = "btnHook";
            btnHook.NoAccentTextColor = Color.Empty;
            btnHook.Size = new Size(64, 36);
            btnHook.TabIndex = 36;
            btnHook.Text = "HOOK";
            btnHook.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnHook.UseAccentColor = false;
            btnHook.UseVisualStyleBackColor = true;
            btnHook.Click += btnHook_Click;
            // 
            // btnUnhook
            // 
            btnUnhook.Anchor = AnchorStyles.None;
            btnUnhook.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUnhook.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUnhook.Depth = 0;
            btnUnhook.Enabled = false;
            btnUnhook.HighEmphasis = false;
            btnUnhook.Icon = null;
            btnUnhook.Location = new Point(109, 376);
            btnUnhook.Margin = new Padding(4, 6, 4, 6);
            btnUnhook.MouseState = MaterialSkin.MouseState.HOVER;
            btnUnhook.Name = "btnUnhook";
            btnUnhook.NoAccentTextColor = Color.Empty;
            btnUnhook.Size = new Size(82, 36);
            btnUnhook.TabIndex = 37;
            btnUnhook.Text = "UNHOOK";
            btnUnhook.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUnhook.UseAccentColor = false;
            btnUnhook.UseVisualStyleBackColor = true;
            btnUnhook.Click += btnUnhook_Click;
            // 
            // btnEditHotKey
            // 
            btnEditHotKey.Anchor = AnchorStyles.None;
            btnEditHotKey.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditHotKey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditHotKey.Depth = 0;
            btnEditHotKey.HighEmphasis = true;
            btnEditHotKey.Icon = null;
            btnEditHotKey.Location = new Point(244, 307);
            btnEditHotKey.Margin = new Padding(4, 6, 4, 6);
            btnEditHotKey.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditHotKey.Name = "btnEditHotKey";
            btnEditHotKey.NoAccentTextColor = Color.Empty;
            btnEditHotKey.Size = new Size(64, 36);
            btnEditHotKey.TabIndex = 41;
            btnEditHotKey.Text = "Edit";
            btnEditHotKey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditHotKey.UseAccentColor = false;
            btnEditHotKey.UseVisualStyleBackColor = true;
            btnEditHotKey.Click += btnEditHotKey_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(374, 440);
            Controls.Add(panelTypeHook);
            Controls.Add(panelRuleConfig);
            Controls.Add(comboDevice);
            Controls.Add(btnHook);
            Controls.Add(btnUnhook);
            Controls.Add(btnEditHotKey);
            Controls.Add(txtHotKey);
            MaximizeBox = false;
            Name = "Form1";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "1xDisconnect";
            Load += Form1_Load;
            panelTypeHook.ResumeLayout(false);
            panelTypeHook.PerformLayout();
            panelRuleConfig.ResumeLayout(false);
            panelRuleConfig.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialExpansionPanel panelTypeHook;
        private MaterialSkin.Controls.MaterialRadioButton radioClamping;
        private MaterialSkin.Controls.MaterialRadioButton radioSwitcher;
        private MaterialSkin.Controls.MaterialRadioButton radioHolder;
        private MaterialSkin.Controls.MaterialTextBox txtHolderTimer;
        private MaterialSkin.Controls.MaterialExpansionPanel panelRuleConfig;
        private MaterialSkin.Controls.MaterialTextBox txtAppFilepath;
        private MaterialSkin.Controls.MaterialCheckbox chkOut;
        private MaterialSkin.Controls.MaterialCheckbox chkIn;
        private MaterialSkin.Controls.MaterialButton btnSetFilepath;
        private MaterialSkin.Controls.MaterialComboBox comboDevice;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private MaterialSkin.Controls.MaterialButton btnEditDevice;
        private MaterialSkin.Controls.MaterialTextBox txtHotKey;
        private MaterialSkin.Controls.MaterialButton btnHook;
        private MaterialSkin.Controls.MaterialButton btnUnhook;
        private MaterialSkin.Controls.MaterialButton btnEditHotKey;
    }
}
