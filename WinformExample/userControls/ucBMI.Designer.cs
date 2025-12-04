namespace WinformExample
{
    partial class ucBMI
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
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.tkBarBMI = new System.Windows.Forms.TrackBar();
            this.lbHeavyWeightBoundary = new System.Windows.Forms.Label();
            this.lbNormalWeightBoundary = new System.Windows.Forms.Label();
            this.lbLowWeightBoundary = new System.Windows.Forms.Label();
            this.lbObesity = new System.Windows.Forms.Label();
            this.lbHeavyWeight = new System.Windows.Forms.Label();
            this.lbNormalWeight = new System.Windows.Forms.Label();
            this.lbLowWeight = new System.Windows.Forms.Label();
            this.gbHeightWeightInput = new System.Windows.Forms.GroupBox();
            this.btnCalculateBMI = new System.Windows.Forms.Button();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.lbWeight = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBarBMI)).BeginInit();
            this.gbHeightWeightInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.lbResult);
            this.gbResult.Controls.Add(this.tkBarBMI);
            this.gbResult.Controls.Add(this.lbHeavyWeightBoundary);
            this.gbResult.Controls.Add(this.lbNormalWeightBoundary);
            this.gbResult.Controls.Add(this.lbLowWeightBoundary);
            this.gbResult.Controls.Add(this.lbObesity);
            this.gbResult.Controls.Add(this.lbHeavyWeight);
            this.gbResult.Controls.Add(this.lbNormalWeight);
            this.gbResult.Controls.Add(this.lbLowWeight);
            this.gbResult.Location = new System.Drawing.Point(3, 123);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(680, 220);
            this.gbResult.TabIndex = 3;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "결과";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResult.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbResult.Location = new System.Drawing.Point(33, 184);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(0, 24);
            this.lbResult.TabIndex = 8;
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tkBarBMI
            // 
            this.tkBarBMI.Enabled = false;
            this.tkBarBMI.Location = new System.Drawing.Point(36, 93);
            this.tkBarBMI.Name = "tkBarBMI";
            this.tkBarBMI.Size = new System.Drawing.Size(629, 69);
            this.tkBarBMI.TabIndex = 7;
            // 
            // lbHeavyWeightBoundary
            // 
            this.lbHeavyWeightBoundary.AutoSize = true;
            this.lbHeavyWeightBoundary.Location = new System.Drawing.Point(481, 40);
            this.lbHeavyWeightBoundary.Name = "lbHeavyWeightBoundary";
            this.lbHeavyWeightBoundary.Size = new System.Drawing.Size(28, 18);
            this.lbHeavyWeightBoundary.TabIndex = 6;
            this.lbHeavyWeightBoundary.Text = "25";
            this.lbHeavyWeightBoundary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNormalWeightBoundary
            // 
            this.lbNormalWeightBoundary.AutoSize = true;
            this.lbNormalWeightBoundary.Location = new System.Drawing.Point(367, 40);
            this.lbNormalWeightBoundary.Name = "lbNormalWeightBoundary";
            this.lbNormalWeightBoundary.Size = new System.Drawing.Size(28, 18);
            this.lbNormalWeightBoundary.TabIndex = 5;
            this.lbNormalWeightBoundary.Text = "23";
            this.lbNormalWeightBoundary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLowWeightBoundary
            // 
            this.lbLowWeightBoundary.AutoSize = true;
            this.lbLowWeightBoundary.Location = new System.Drawing.Point(130, 40);
            this.lbLowWeightBoundary.Name = "lbLowWeightBoundary";
            this.lbLowWeightBoundary.Size = new System.Drawing.Size(44, 18);
            this.lbLowWeightBoundary.TabIndex = 4;
            this.lbLowWeightBoundary.Text = "18.5";
            this.lbLowWeightBoundary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbObesity
            // 
            this.lbObesity.BackColor = System.Drawing.Color.Crimson;
            this.lbObesity.Location = new System.Drawing.Point(499, 58);
            this.lbObesity.Name = "lbObesity";
            this.lbObesity.Size = new System.Drawing.Size(164, 20);
            this.lbObesity.TabIndex = 3;
            this.lbObesity.Text = "비만";
            this.lbObesity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHeavyWeight
            // 
            this.lbHeavyWeight.BackColor = System.Drawing.Color.Wheat;
            this.lbHeavyWeight.Location = new System.Drawing.Point(390, 58);
            this.lbHeavyWeight.Name = "lbHeavyWeight";
            this.lbHeavyWeight.Size = new System.Drawing.Size(100, 20);
            this.lbHeavyWeight.TabIndex = 2;
            this.lbHeavyWeight.Text = "과체중";
            this.lbHeavyWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNormalWeight
            // 
            this.lbNormalWeight.BackColor = System.Drawing.Color.Turquoise;
            this.lbNormalWeight.Location = new System.Drawing.Point(159, 58);
            this.lbNormalWeight.Name = "lbNormalWeight";
            this.lbNormalWeight.Size = new System.Drawing.Size(224, 20);
            this.lbNormalWeight.TabIndex = 1;
            this.lbNormalWeight.Text = "정상";
            this.lbNormalWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLowWeight
            // 
            this.lbLowWeight.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbLowWeight.Location = new System.Drawing.Point(33, 58);
            this.lbLowWeight.Name = "lbLowWeight";
            this.lbLowWeight.Size = new System.Drawing.Size(120, 20);
            this.lbLowWeight.TabIndex = 0;
            this.lbLowWeight.Text = "저체중";
            this.lbLowWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbHeightWeightInput
            // 
            this.gbHeightWeightInput.Controls.Add(this.btnCalculateBMI);
            this.gbHeightWeightInput.Controls.Add(this.tbWeight);
            this.gbHeightWeightInput.Controls.Add(this.lbWeight);
            this.gbHeightWeightInput.Controls.Add(this.tbHeight);
            this.gbHeightWeightInput.Controls.Add(this.lbHeight);
            this.gbHeightWeightInput.Location = new System.Drawing.Point(3, 15);
            this.gbHeightWeightInput.Name = "gbHeightWeightInput";
            this.gbHeightWeightInput.Size = new System.Drawing.Size(680, 100);
            this.gbHeightWeightInput.TabIndex = 2;
            this.gbHeightWeightInput.TabStop = false;
            this.gbHeightWeightInput.Text = "등록";
            // 
            // btnCalculateBMI
            // 
            this.btnCalculateBMI.Location = new System.Drawing.Point(534, 34);
            this.btnCalculateBMI.Name = "btnCalculateBMI";
            this.btnCalculateBMI.Size = new System.Drawing.Size(114, 45);
            this.btnCalculateBMI.TabIndex = 4;
            this.btnCalculateBMI.Text = "계산";
            this.btnCalculateBMI.UseVisualStyleBackColor = true;
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(370, 45);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(130, 28);
            this.tbWeight.TabIndex = 3;
            // 
            // lbWeight
            // 
            this.lbWeight.AutoSize = true;
            this.lbWeight.Location = new System.Drawing.Point(271, 48);
            this.lbWeight.Name = "lbWeight";
            this.lbWeight.Size = new System.Drawing.Size(93, 18);
            this.lbWeight.TabIndex = 2;
            this.lbWeight.Text = "몸무게(kg)";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(104, 45);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(130, 28);
            this.tbHeight.TabIndex = 1;
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(19, 48);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(81, 18);
            this.lbHeight.TabIndex = 0;
            this.lbHeight.Text = "신장(cm)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(593, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 47);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucBMI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.gbHeightWeightInput);
            this.Name = "ucBMI";
            this.Size = new System.Drawing.Size(691, 496);
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkBarBMI)).EndInit();
            this.gbHeightWeightInput.ResumeLayout(false);
            this.gbHeightWeightInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TrackBar tkBarBMI;
        private System.Windows.Forms.Label lbHeavyWeightBoundary;
        private System.Windows.Forms.Label lbNormalWeightBoundary;
        private System.Windows.Forms.Label lbLowWeightBoundary;
        private System.Windows.Forms.Label lbObesity;
        private System.Windows.Forms.Label lbNormalWeight;
        private System.Windows.Forms.Label lbLowWeight;
        private System.Windows.Forms.GroupBox gbHeightWeightInput;
        private System.Windows.Forms.Button btnCalculateBMI;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.Label lbWeight;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbHeavyWeight;
        private System.Windows.Forms.Button btnSave;
    }
}
