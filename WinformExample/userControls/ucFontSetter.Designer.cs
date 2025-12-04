namespace WinformExample
{
    partial class ucFontSetter
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTreeListView = new System.Windows.Forms.GroupBox();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnAddRoot = new System.Windows.Forms.Button();
            this.lvNodes = new System.Windows.Forms.ListView();
            this.tvNodes = new System.Windows.Forms.TreeView();
            this.gbModalModaless = new System.Windows.Forms.GroupBox();
            this.btnMessageBox = new System.Windows.Forms.Button();
            this.btnModaless = new System.Windows.Forms.Button();
            this.btnModal = new System.Windows.Forms.Button();
            this.gbProgress = new System.Windows.Forms.GroupBox();
            this.pgbarTest = new System.Windows.Forms.ProgressBar();
            this.tkBarTest = new System.Windows.Forms.TrackBar();
            this.gbFont = new System.Windows.Forms.GroupBox();
            this.tbFontTest = new System.Windows.Forms.TextBox();
            this.cbItalicCheck = new System.Windows.Forms.CheckBox();
            this.cbBoldCheck = new System.Windows.Forms.CheckBox();
            this.cbxFontCombo = new System.Windows.Forms.ComboBox();
            this.lbFont = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbTreeListView.SuspendLayout();
            this.gbModalModaless.SuspendLayout();
            this.gbProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBarTest)).BeginInit();
            this.gbFont.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTreeListView
            // 
            this.gbTreeListView.Controls.Add(this.btnDeleteNode);
            this.gbTreeListView.Controls.Add(this.btnAddChild);
            this.gbTreeListView.Controls.Add(this.btnAddRoot);
            this.gbTreeListView.Controls.Add(this.lvNodes);
            this.gbTreeListView.Controls.Add(this.tvNodes);
            this.gbTreeListView.Location = new System.Drawing.Point(13, 382);
            this.gbTreeListView.Name = "gbTreeListView";
            this.gbTreeListView.Size = new System.Drawing.Size(677, 278);
            this.gbTreeListView.TabIndex = 7;
            this.gbTreeListView.TabStop = false;
            this.gbTreeListView.Text = "TreeView & ListView";
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(300, 234);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(140, 38);
            this.btnDeleteNode.TabIndex = 4;
            this.btnDeleteNode.Text = "Delete Node";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            // 
            // btnAddChild
            // 
            this.btnAddChild.Location = new System.Drawing.Point(154, 234);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(140, 38);
            this.btnAddChild.TabIndex = 3;
            this.btnAddChild.Text = "Add Child";
            this.btnAddChild.UseVisualStyleBackColor = true;
            // 
            // btnAddRoot
            // 
            this.btnAddRoot.Location = new System.Drawing.Point(9, 234);
            this.btnAddRoot.Name = "btnAddRoot";
            this.btnAddRoot.Size = new System.Drawing.Size(140, 38);
            this.btnAddRoot.TabIndex = 2;
            this.btnAddRoot.Text = "Add Root";
            this.btnAddRoot.UseVisualStyleBackColor = true;
            // 
            // lvNodes
            // 
            this.lvNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvNodes.HideSelection = false;
            this.lvNodes.Location = new System.Drawing.Point(357, 27);
            this.lvNodes.Name = "lvNodes";
            this.lvNodes.Size = new System.Drawing.Size(313, 199);
            this.lvNodes.TabIndex = 1;
            this.lvNodes.UseCompatibleStateImageBehavior = false;
            this.lvNodes.View = System.Windows.Forms.View.SmallIcon;
            // 
            // tvNodes
            // 
            this.tvNodes.Location = new System.Drawing.Point(9, 27);
            this.tvNodes.Name = "tvNodes";
            this.tvNodes.Size = new System.Drawing.Size(313, 199);
            this.tvNodes.TabIndex = 0;
            // 
            // gbModalModaless
            // 
            this.gbModalModaless.Controls.Add(this.btnMessageBox);
            this.gbModalModaless.Controls.Add(this.btnModaless);
            this.gbModalModaless.Controls.Add(this.btnModal);
            this.gbModalModaless.Location = new System.Drawing.Point(13, 302);
            this.gbModalModaless.Name = "gbModalModaless";
            this.gbModalModaless.Size = new System.Drawing.Size(677, 75);
            this.gbModalModaless.TabIndex = 6;
            this.gbModalModaless.TabStop = false;
            this.gbModalModaless.Text = "Modal, Modaless & MessageBox";
            // 
            // btnMessageBox
            // 
            this.btnMessageBox.Location = new System.Drawing.Point(407, 27);
            this.btnMessageBox.Name = "btnMessageBox";
            this.btnMessageBox.Size = new System.Drawing.Size(260, 34);
            this.btnMessageBox.TabIndex = 2;
            this.btnMessageBox.Text = "MessageBox";
            this.btnMessageBox.UseVisualStyleBackColor = true;
            // 
            // btnModaless
            // 
            this.btnModaless.Location = new System.Drawing.Point(190, 27);
            this.btnModaless.Name = "btnModaless";
            this.btnModaless.Size = new System.Drawing.Size(191, 34);
            this.btnModaless.TabIndex = 1;
            this.btnModaless.Text = "Modalless";
            this.btnModaless.UseVisualStyleBackColor = true;
            // 
            // btnModal
            // 
            this.btnModal.Location = new System.Drawing.Point(20, 27);
            this.btnModal.Name = "btnModal";
            this.btnModal.Size = new System.Drawing.Size(144, 34);
            this.btnModal.TabIndex = 0;
            this.btnModal.Text = "Modal";
            this.btnModal.UseVisualStyleBackColor = true;
            // 
            // gbProgress
            // 
            this.gbProgress.Controls.Add(this.pgbarTest);
            this.gbProgress.Controls.Add(this.tkBarTest);
            this.gbProgress.Location = new System.Drawing.Point(13, 128);
            this.gbProgress.Name = "gbProgress";
            this.gbProgress.Size = new System.Drawing.Size(677, 166);
            this.gbProgress.TabIndex = 5;
            this.gbProgress.TabStop = false;
            this.gbProgress.Text = "TrackBar & ProgressBar";
            // 
            // pgbarTest
            // 
            this.pgbarTest.Location = new System.Drawing.Point(20, 88);
            this.pgbarTest.Margin = new System.Windows.Forms.Padding(4);
            this.pgbarTest.Name = "pgbarTest";
            this.pgbarTest.Size = new System.Drawing.Size(633, 52);
            this.pgbarTest.TabIndex = 1;
            // 
            // tkBarTest
            // 
            this.tkBarTest.Location = new System.Drawing.Point(9, 28);
            this.tkBarTest.Name = "tkBarTest";
            this.tkBarTest.Size = new System.Drawing.Size(659, 69);
            this.tkBarTest.TabIndex = 0;
            // 
            // gbFont
            // 
            this.gbFont.Controls.Add(this.tbFontTest);
            this.gbFont.Controls.Add(this.cbItalicCheck);
            this.gbFont.Controls.Add(this.cbBoldCheck);
            this.gbFont.Controls.Add(this.cbxFontCombo);
            this.gbFont.Controls.Add(this.lbFont);
            this.gbFont.Location = new System.Drawing.Point(11, 15);
            this.gbFont.Name = "gbFont";
            this.gbFont.Size = new System.Drawing.Size(679, 105);
            this.gbFont.TabIndex = 4;
            this.gbFont.TabStop = false;
            this.gbFont.Text = "ComboBox, CheckBox, TextBox";
            // 
            // tbFontTest
            // 
            this.tbFontTest.Location = new System.Drawing.Point(10, 62);
            this.tbFontTest.Name = "tbFontTest";
            this.tbFontTest.Size = new System.Drawing.Size(347, 28);
            this.tbFontTest.TabIndex = 4;
            this.tbFontTest.Text = "Hello World!";
            // 
            // cbItalicCheck
            // 
            this.cbItalicCheck.AutoSize = true;
            this.cbItalicCheck.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbItalicCheck.Location = new System.Drawing.Point(269, 27);
            this.cbItalicCheck.Name = "cbItalicCheck";
            this.cbItalicCheck.Size = new System.Drawing.Size(88, 22);
            this.cbItalicCheck.TabIndex = 3;
            this.cbItalicCheck.Text = "이탤릭";
            this.cbItalicCheck.UseVisualStyleBackColor = true;
            // 
            // cbBoldCheck
            // 
            this.cbBoldCheck.AutoSize = true;
            this.cbBoldCheck.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbBoldCheck.Location = new System.Drawing.Point(191, 28);
            this.cbBoldCheck.Name = "cbBoldCheck";
            this.cbBoldCheck.Size = new System.Drawing.Size(72, 22);
            this.cbBoldCheck.TabIndex = 2;
            this.cbBoldCheck.Text = "굵게";
            this.cbBoldCheck.UseVisualStyleBackColor = true;
            // 
            // cbxFontCombo
            // 
            this.cbxFontCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFontCombo.FormattingEnabled = true;
            this.cbxFontCombo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxFontCombo.Location = new System.Drawing.Point(63, 26);
            this.cbxFontCombo.Name = "cbxFontCombo";
            this.cbxFontCombo.Size = new System.Drawing.Size(121, 26);
            this.cbxFontCombo.TabIndex = 1;
            // 
            // lbFont
            // 
            this.lbFont.AutoSize = true;
            this.lbFont.Location = new System.Drawing.Point(7, 28);
            this.lbFont.Name = "lbFont";
            this.lbFont.Size = new System.Drawing.Size(61, 18);
            this.lbFont.TabIndex = 0;
            this.lbFont.Text = "Font : ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(606, 676);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucFontSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbTreeListView);
            this.Controls.Add(this.gbModalModaless);
            this.Controls.Add(this.gbProgress);
            this.Controls.Add(this.gbFont);
            this.Name = "ucFontSetter";
            this.Size = new System.Drawing.Size(749, 735);
            this.gbTreeListView.ResumeLayout(false);
            this.gbModalModaless.ResumeLayout(false);
            this.gbProgress.ResumeLayout(false);
            this.gbProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBarTest)).EndInit();
            this.gbFont.ResumeLayout(false);
            this.gbFont.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTreeListView;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnAddRoot;
        private System.Windows.Forms.ListView lvNodes;
        private System.Windows.Forms.TreeView tvNodes;
        private System.Windows.Forms.GroupBox gbModalModaless;
        private System.Windows.Forms.Button btnMessageBox;
        private System.Windows.Forms.Button btnModaless;
        private System.Windows.Forms.Button btnModal;
        private System.Windows.Forms.GroupBox gbProgress;
        private System.Windows.Forms.TrackBar tkBarTest;
        private System.Windows.Forms.GroupBox gbFont;
        private System.Windows.Forms.TextBox tbFontTest;
        private System.Windows.Forms.CheckBox cbItalicCheck;
        private System.Windows.Forms.CheckBox cbBoldCheck;
        private System.Windows.Forms.ComboBox cbxFontCombo;
        private System.Windows.Forms.Label lbFont;
        private System.Windows.Forms.ProgressBar pgbarTest;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.Button btnSave;
    }
}
