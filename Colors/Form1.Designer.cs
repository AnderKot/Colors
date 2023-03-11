using System.Windows.Forms;

namespace Colors
{
    partial class Form1
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
            this.m_colorPicker = new Colors.ColorWheelCtrl();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // m_colorPicker
            // 
            this.m_colorPicker.BackColor = System.Drawing.Color.Transparent;
            this.m_colorPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_colorPicker.Location = new System.Drawing.Point(0, 0);
            this.m_colorPicker.Name = "m_colorPicker";
            this.m_colorPicker.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.m_colorPicker.Size = new System.Drawing.Size(642, 561);
            this.m_colorPicker.TabIndex = 3;
            this.m_colorPicker.Load += new System.EventHandler(this.m_colorPicker_Load);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Последовательная",
            "Монохромная",
            "Комплементарная",
            "Треугольная",
            "Квадратная"});
            this.checkedListBox1.Location = new System.Drawing.Point(321, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(155, 79);
            this.checkedListBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(470, 420);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.m_colorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Color Picker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private ColorWheelCtrl m_colorPicker;
        private CheckedListBox checkedListBox1;
    }
}

