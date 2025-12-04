namespace WinformExample
{
    partial class ucImageLoad
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
            this.btnImageLoad = new System.Windows.Forms.Button();
            this.pbMainPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbImageFiltered = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFiltered)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImageLoad
            // 
            this.btnImageLoad.Location = new System.Drawing.Point(154, 74);
            this.btnImageLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImageLoad.Name = "btnImageLoad";
            this.btnImageLoad.Size = new System.Drawing.Size(106, 31);
            this.btnImageLoad.TabIndex = 0;
            this.btnImageLoad.Text = "이미지 불러오기";
            this.btnImageLoad.UseVisualStyleBackColor = true;
            // 
            // pbMainPicture
            // 
            this.pbMainPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMainPicture.Location = new System.Drawing.Point(18, 109);
            this.pbMainPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbMainPicture.Name = "pbMainPicture";
            this.pbMainPicture.Size = new System.Drawing.Size(242, 297);
            this.pbMainPicture.TabIndex = 1;
            this.pbMainPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(18, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "<ImageFilter>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "원본";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(299, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "필터 결과";
            // 
            // pbImageFiltered
            // 
            this.pbImageFiltered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImageFiltered.Location = new System.Drawing.Point(299, 109);
            this.pbImageFiltered.Margin = new System.Windows.Forms.Padding(2);
            this.pbImageFiltered.Name = "pbImageFiltered";
            this.pbImageFiltered.Size = new System.Drawing.Size(242, 297);
            this.pbImageFiltered.TabIndex = 4;
            this.pbImageFiltered.TabStop = false;
            // 
            // ucImageLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbImageFiltered);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMainPicture);
            this.Controls.Add(this.btnImageLoad);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucImageLoad";
            this.Size = new System.Drawing.Size(650, 598);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageFiltered)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImageLoad;
        private System.Windows.Forms.PictureBox pbMainPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbImageFiltered;
    }
}
