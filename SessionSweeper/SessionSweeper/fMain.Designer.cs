namespace SessionSweeper
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.tmrResume = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblSessionStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLockSessionInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPauseBreak = new System.Windows.Forms.Button();
            this.btnScrollLock = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrResume
            // 
            this.tmrResume.Interval = 10000;
            this.tmrResume.Tick += new System.EventHandler(this.tmrResume_Tick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Created by Dysanix - Version 1.2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSessionStatus
            // 
            this.lblSessionStatus.BackColor = System.Drawing.Color.Green;
            this.lblSessionStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSessionStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionStatus.ForeColor = System.Drawing.Color.White;
            this.lblSessionStatus.Location = new System.Drawing.Point(0, 178);
            this.lblSessionStatus.Name = "lblSessionStatus";
            this.lblSessionStatus.Size = new System.Drawing.Size(330, 38);
            this.lblSessionStatus.TabIndex = 2;
            this.lblSessionStatus.Text = "Session is unlocked!";
            this.lblSessionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnScrollLock);
            this.groupBox1.Controls.Add(this.btnPauseBreak);
            this.groupBox1.Controls.Add(this.lblLockSessionInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 164);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keybinds";
            // 
            // lblLockSessionInfo
            // 
            this.lblLockSessionInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLockSessionInfo.Location = new System.Drawing.Point(52, 70);
            this.lblLockSessionInfo.Name = "lblLockSessionInfo";
            this.lblLockSessionInfo.Size = new System.Drawing.Size(248, 91);
            this.lblLockSessionInfo.TabIndex = 3;
            this.lblLockSessionInfo.Text = "This hotkey will stop players from joining. Only works when alone or with friends" +
    " who also locked the session using SessionSweeper. Windows Firewall must be enab" +
    "led on your computer!";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "This hotkey will disconnect you from all other players in the session.";
            // 
            // btnPauseBreak
            // 
            this.btnPauseBreak.Image = global::SessionSweeper.Properties.Resources.pausebreak;
            this.btnPauseBreak.Location = new System.Drawing.Point(6, 24);
            this.btnPauseBreak.Name = "btnPauseBreak";
            this.btnPauseBreak.Size = new System.Drawing.Size(40, 38);
            this.btnPauseBreak.TabIndex = 4;
            this.btnPauseBreak.TabStop = false;
            this.btnPauseBreak.UseVisualStyleBackColor = true;
            this.btnPauseBreak.Click += new System.EventHandler(this.btnPauseBreak_Click);
            // 
            // btnScrollLock
            // 
            this.btnScrollLock.Image = global::SessionSweeper.Properties.Resources.scrolllock;
            this.btnScrollLock.Location = new System.Drawing.Point(6, 70);
            this.btnScrollLock.Name = "btnScrollLock";
            this.btnScrollLock.Size = new System.Drawing.Size(40, 38);
            this.btnScrollLock.TabIndex = 5;
            this.btnScrollLock.TabStop = false;
            this.btnScrollLock.UseVisualStyleBackColor = true;
            this.btnScrollLock.Click += new System.EventHandler(this.btnScrollLock_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(330, 243);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSessionStatus);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SessionSweeper";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrResume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSessionStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLockSessionInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScrollLock;
        private System.Windows.Forms.Button btnPauseBreak;
    }
}

