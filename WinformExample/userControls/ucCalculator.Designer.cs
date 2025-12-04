namespace WinformExample
{
    partial class ucCalculator
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
            this.tbMainOperation = new System.Windows.Forms.TextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnPoint = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnGetRest = new System.Windows.Forms.Button();
            this.btnBackSpace = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbBackground = new System.Windows.Forms.TextBox();
            this.gbButtons.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMainOperation
            // 
            this.tbMainOperation.Enabled = false;
            this.tbMainOperation.Font = new System.Drawing.Font("굴림", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMainOperation.Location = new System.Drawing.Point(18, 40);
            this.tbMainOperation.Margin = new System.Windows.Forms.Padding(2);
            this.tbMainOperation.Name = "tbMainOperation";
            this.tbMainOperation.Size = new System.Drawing.Size(383, 40);
            this.tbMainOperation.TabIndex = 0;
            this.tbMainOperation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(14, 9);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(41, 12);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "계산기";
            // 
            // gbButtons
            // 
            this.gbButtons.Controls.Add(this.tlpButtons);
            this.gbButtons.Location = new System.Drawing.Point(16, 89);
            this.gbButtons.Margin = new System.Windows.Forms.Padding(2);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Padding = new System.Windows.Forms.Padding(2);
            this.gbButtons.Size = new System.Drawing.Size(381, 313);
            this.gbButtons.TabIndex = 2;
            this.gbButtons.TabStop = false;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.Controls.Add(this.btnPoint, 2, 4);
            this.tlpButtons.Controls.Add(this.btnEqual, 3, 4);
            this.tlpButtons.Controls.Add(this.btnZero, 1, 4);
            this.tlpButtons.Controls.Add(this.btnPlus, 3, 3);
            this.tlpButtons.Controls.Add(this.btnThree, 2, 3);
            this.tlpButtons.Controls.Add(this.btnTwo, 1, 3);
            this.tlpButtons.Controls.Add(this.btnOne, 0, 3);
            this.tlpButtons.Controls.Add(this.btnMinus, 3, 2);
            this.tlpButtons.Controls.Add(this.btnSix, 2, 2);
            this.tlpButtons.Controls.Add(this.btnFive, 1, 2);
            this.tlpButtons.Controls.Add(this.btnFour, 0, 2);
            this.tlpButtons.Controls.Add(this.btnMulti, 3, 1);
            this.tlpButtons.Controls.Add(this.btnNine, 2, 1);
            this.tlpButtons.Controls.Add(this.btnEight, 1, 1);
            this.tlpButtons.Controls.Add(this.btnSeven, 0, 1);
            this.tlpButtons.Controls.Add(this.btnDivide, 3, 0);
            this.tlpButtons.Controls.Add(this.btnGetRest, 2, 0);
            this.tlpButtons.Controls.Add(this.btnBackSpace, 1, 0);
            this.tlpButtons.Controls.Add(this.btnClear, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(2, 16);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(2);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 5;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpButtons.Size = new System.Drawing.Size(377, 295);
            this.tlpButtons.TabIndex = 3;
            // 
            // btnPoint
            // 
            this.btnPoint.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPoint.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPoint.Location = new System.Drawing.Point(190, 238);
            this.btnPoint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(90, 55);
            this.btnPoint.TabIndex = 20;
            this.btnPoint.TabStop = false;
            this.btnPoint.Text = ".";
            this.btnPoint.UseVisualStyleBackColor = false;
            // 
            // btnEqual
            // 
            this.btnEqual.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEqual.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEqual.Location = new System.Drawing.Point(284, 238);
            this.btnEqual.Margin = new System.Windows.Forms.Padding(2);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(91, 55);
            this.btnEqual.TabIndex = 19;
            this.btnEqual.TabStop = false;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = false;
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZero.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZero.Location = new System.Drawing.Point(96, 238);
            this.btnZero.Margin = new System.Windows.Forms.Padding(2);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(90, 55);
            this.btnZero.TabIndex = 17;
            this.btnZero.TabStop = false;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = false;
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlus.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlus.Location = new System.Drawing.Point(284, 179);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(91, 55);
            this.btnPlus.TabIndex = 15;
            this.btnPlus.TabStop = false;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = false;
            // 
            // btnThree
            // 
            this.btnThree.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThree.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnThree.Location = new System.Drawing.Point(190, 179);
            this.btnThree.Margin = new System.Windows.Forms.Padding(2);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(90, 55);
            this.btnThree.TabIndex = 14;
            this.btnThree.TabStop = false;
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = false;
            // 
            // btnTwo
            // 
            this.btnTwo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTwo.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTwo.Location = new System.Drawing.Point(96, 179);
            this.btnTwo.Margin = new System.Windows.Forms.Padding(2);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(90, 55);
            this.btnTwo.TabIndex = 13;
            this.btnTwo.TabStop = false;
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = false;
            // 
            // btnOne
            // 
            this.btnOne.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOne.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOne.Location = new System.Drawing.Point(2, 179);
            this.btnOne.Margin = new System.Windows.Forms.Padding(2);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(90, 55);
            this.btnOne.TabIndex = 12;
            this.btnOne.TabStop = false;
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = false;
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinus.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMinus.Location = new System.Drawing.Point(284, 120);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(91, 55);
            this.btnMinus.TabIndex = 11;
            this.btnMinus.TabStop = false;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = false;
            // 
            // btnSix
            // 
            this.btnSix.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSix.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSix.Location = new System.Drawing.Point(190, 120);
            this.btnSix.Margin = new System.Windows.Forms.Padding(2);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(90, 55);
            this.btnSix.TabIndex = 10;
            this.btnSix.TabStop = false;
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = false;
            // 
            // btnFive
            // 
            this.btnFive.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnFive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFive.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFive.Location = new System.Drawing.Point(96, 120);
            this.btnFive.Margin = new System.Windows.Forms.Padding(2);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(90, 55);
            this.btnFive.TabIndex = 9;
            this.btnFive.TabStop = false;
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = false;
            // 
            // btnFour
            // 
            this.btnFour.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFour.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFour.Location = new System.Drawing.Point(2, 120);
            this.btnFour.Margin = new System.Windows.Forms.Padding(2);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(90, 55);
            this.btnFour.TabIndex = 8;
            this.btnFour.TabStop = false;
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = false;
            // 
            // btnMulti
            // 
            this.btnMulti.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnMulti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMulti.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMulti.Location = new System.Drawing.Point(284, 61);
            this.btnMulti.Margin = new System.Windows.Forms.Padding(2);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(91, 55);
            this.btnMulti.TabIndex = 7;
            this.btnMulti.TabStop = false;
            this.btnMulti.Text = "*";
            this.btnMulti.UseVisualStyleBackColor = false;
            // 
            // btnNine
            // 
            this.btnNine.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNine.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNine.Location = new System.Drawing.Point(190, 61);
            this.btnNine.Margin = new System.Windows.Forms.Padding(2);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(90, 55);
            this.btnNine.TabIndex = 6;
            this.btnNine.TabStop = false;
            this.btnNine.Text = "9";
            this.btnNine.UseVisualStyleBackColor = false;
            // 
            // btnEight
            // 
            this.btnEight.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnEight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEight.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEight.Location = new System.Drawing.Point(96, 61);
            this.btnEight.Margin = new System.Windows.Forms.Padding(2);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(90, 55);
            this.btnEight.TabIndex = 5;
            this.btnEight.TabStop = false;
            this.btnEight.Text = "8";
            this.btnEight.UseVisualStyleBackColor = false;
            // 
            // btnSeven
            // 
            this.btnSeven.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSeven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSeven.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSeven.Location = new System.Drawing.Point(2, 61);
            this.btnSeven.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(90, 55);
            this.btnSeven.TabIndex = 4;
            this.btnSeven.TabStop = false;
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = false;
            // 
            // btnDivide
            // 
            this.btnDivide.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDivide.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDivide.Location = new System.Drawing.Point(284, 2);
            this.btnDivide.Margin = new System.Windows.Forms.Padding(2);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(91, 55);
            this.btnDivide.TabIndex = 3;
            this.btnDivide.TabStop = false;
            this.btnDivide.Text = "/";
            this.btnDivide.UseVisualStyleBackColor = false;
            // 
            // btnGetRest
            // 
            this.btnGetRest.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnGetRest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetRest.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGetRest.Location = new System.Drawing.Point(190, 2);
            this.btnGetRest.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetRest.Name = "btnGetRest";
            this.btnGetRest.Size = new System.Drawing.Size(90, 55);
            this.btnGetRest.TabIndex = 2;
            this.btnGetRest.TabStop = false;
            this.btnGetRest.Text = "%";
            this.btnGetRest.UseVisualStyleBackColor = false;
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnBackSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackSpace.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBackSpace.Location = new System.Drawing.Point(96, 2);
            this.btnBackSpace.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(90, 55);
            this.btnBackSpace.TabIndex = 1;
            this.btnBackSpace.TabStop = false;
            this.btnBackSpace.Text = "<X";
            this.btnBackSpace.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear.Location = new System.Drawing.Point(2, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 55);
            this.btnClear.TabIndex = 1;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // tbHidden
            // 
            this.tbBackground.Location = new System.Drawing.Point(20, 59);
            this.tbBackground.Name = "tbHidden";
            this.tbBackground.Size = new System.Drawing.Size(100, 21);
            this.tbBackground.TabIndex = 3;
            // 
            // ucCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.tbMainOperation);
            this.Controls.Add(this.tbBackground);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucCalculator";
            this.Size = new System.Drawing.Size(409, 418);
            this.gbButtons.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMainOperation;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnMulti;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnGetRest;
        private System.Windows.Forms.Button btnBackSpace;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPoint;
        private System.Windows.Forms.TextBox tbBackground;
    }
}
