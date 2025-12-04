namespace WinformExample
{
    partial class ucLogViewer
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbFileTitle = new System.Windows.Forms.Label();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tbMain = new System.Windows.Forms.RichTextBox();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.lvFilters = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbFilters = new System.Windows.Forms.Label();
            this.tbFilterInput = new System.Windows.Forms.TextBox();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.Location = new System.Drawing.Point(3, 4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(169, 36);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "LogViewer";
            // 
            // lbFileTitle
            // 
            this.lbFileTitle.AutoSize = true;
            this.lbFileTitle.Location = new System.Drawing.Point(3, 42);
            this.lbFileTitle.Name = "lbFileTitle";
            this.lbFileTitle.Size = new System.Drawing.Size(80, 18);
            this.lbFileTitle.TabIndex = 1;
            this.lbFileTitle.Text = "제목없음";
            this.lbFileTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(8, 75);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(74, 40);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "열기";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            // 
            // tbMain
            // 
            this.tbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMain.Location = new System.Drawing.Point(9, 122);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(678, 535);
            this.tbMain.TabIndex = 3;
            this.tbMain.Text = "";
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcher.SynchronizingObject = this;
            // 
            // lvFilters
            // 
            this.lvFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.lvFilters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvFilters.HideSelection = false;
            this.lvFilters.Location = new System.Drawing.Point(8, 714);
            this.lvFilters.Name = "lvFilters";
            this.lvFilters.Size = new System.Drawing.Size(171, 92);
            this.lvFilters.TabIndex = 4;
            this.lvFilters.UseCompatibleStateImageBehavior = false;
            this.lvFilters.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "Filters";
            // 
            // lbFilters
            // 
            this.lbFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFilters.AutoSize = true;
            this.lbFilters.Location = new System.Drawing.Point(3, 658);
            this.lbFilters.Name = "lbFilters";
            this.lbFilters.Size = new System.Drawing.Size(54, 18);
            this.lbFilters.TabIndex = 5;
            this.lbFilters.Text = "Filters";
            // 
            // tbFilterInput
            // 
            this.tbFilterInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbFilterInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilterInput.Location = new System.Drawing.Point(8, 680);
            this.tbFilterInput.Name = "tbFilterInput";
            this.tbFilterInput.Size = new System.Drawing.Size(172, 28);
            this.tbFilterInput.TabIndex = 6;
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFilter.Location = new System.Drawing.Point(202, 680);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(74, 28);
            this.btnAddFilter.TabIndex = 7;
            this.btnAddFilter.Text = "추가";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteFilter.Location = new System.Drawing.Point(202, 714);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(74, 28);
            this.btnDeleteFilter.TabIndex = 8;
            this.btnDeleteFilter.Text = "삭제";
            this.btnDeleteFilter.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(612, 695);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 47);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // ucLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteFilter);
            this.Controls.Add(this.btnAddFilter);
            this.Controls.Add(this.tbFilterInput);
            this.Controls.Add(this.lbFilters);
            this.Controls.Add(this.lvFilters);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lbFileTitle);
            this.Controls.Add(this.lbTitle);
            this.Name = "ucLogViewer";
            this.Size = new System.Drawing.Size(781, 814);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbFileTitle;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.RichTextBox tbMain;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.TextBox tbFilterInput;
        private System.Windows.Forms.Label lbFilters;
        private System.Windows.Forms.ListView lvFilters;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.Button btnSave;
    }
}
