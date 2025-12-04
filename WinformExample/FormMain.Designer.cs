namespace WinformExample
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tpLogViewer = new System.Windows.Forms.TabPage();
            this.tpCalculator = new System.Windows.Forms.TabPage();
            this.tpImageLoader = new System.Windows.Forms.TabPage();
            this.tpBMI = new System.Windows.Forms.TabPage();
            this.tpFontSetter = new System.Windows.Forms.TabPage();
            this.tcMainTab = new System.Windows.Forms.TabControl();
            this.tcMainTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpLogViewer
            // 
            this.tpLogViewer.Location = new System.Drawing.Point(4, 28);
            this.tpLogViewer.Name = "tpLogViewer";
            this.tpLogViewer.Size = new System.Drawing.Size(875, 840);
            this.tpLogViewer.TabIndex = 3;
            this.tpLogViewer.Text = "LogViewer";
            this.tpLogViewer.UseVisualStyleBackColor = true;
            // 
            // tpCalculator
            // 
            this.tpCalculator.Location = new System.Drawing.Point(4, 28);
            this.tpCalculator.Name = "tpCalculator";
            this.tpCalculator.Size = new System.Drawing.Size(875, 840);
            this.tpCalculator.TabIndex = 0;
            this.tpCalculator.Text = "Calculator";
            this.tpCalculator.UseVisualStyleBackColor = true;
            // 
            // tpImageLoader
            // 
            this.tpImageLoader.Location = new System.Drawing.Point(4, 28);
            this.tpImageLoader.Name = "tpImageLoader";
            this.tpImageLoader.Size = new System.Drawing.Size(875, 840);
            this.tpImageLoader.TabIndex = 8;
            this.tpImageLoader.Text = "ImageLoader";
            this.tpImageLoader.UseVisualStyleBackColor = true;
            // 
            // tpBMI
            // 
            this.tpBMI.Location = new System.Drawing.Point(4, 28);
            this.tpBMI.Name = "tpBMI";
            this.tpBMI.Size = new System.Drawing.Size(875, 840);
            this.tpBMI.TabIndex = 7;
            this.tpBMI.Text = "BMI";
            this.tpBMI.UseVisualStyleBackColor = true;
            // 
            // tpFontSetter
            // 
            this.tpFontSetter.Location = new System.Drawing.Point(4, 28);
            this.tpFontSetter.Name = "tpFontSetter";
            this.tpFontSetter.Size = new System.Drawing.Size(875, 840);
            this.tpFontSetter.TabIndex = 5;
            this.tpFontSetter.Text = "FontSetter";
            this.tpFontSetter.UseVisualStyleBackColor = true;
            // 
            // tcMainTab
            // 
            this.tcMainTab.Controls.Add(this.tpFontSetter);
            this.tcMainTab.Controls.Add(this.tpBMI);
            this.tcMainTab.Controls.Add(this.tpImageLoader);
            this.tcMainTab.Controls.Add(this.tpCalculator);
            this.tcMainTab.Controls.Add(this.tpLogViewer);
            this.tcMainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMainTab.Location = new System.Drawing.Point(0, 0);
            this.tcMainTab.Name = "tcMainTab";
            this.tcMainTab.SelectedIndex = 0;
            this.tcMainTab.Size = new System.Drawing.Size(883, 872);
            this.tcMainTab.TabIndex = 0;
            this.tcMainTab.SelectedIndexChanged += new System.EventHandler(this.tcMainTab_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 872);
            this.Controls.Add(this.tcMainTab);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tcMainTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpLogViewer;
        private System.Windows.Forms.TabPage tpCalculator;
        private System.Windows.Forms.TabPage tpImageLoader;
        private System.Windows.Forms.TabPage tpBMI;
        private System.Windows.Forms.TabPage tpFontSetter;
        private System.Windows.Forms.TabControl tcMainTab;
    }
}

