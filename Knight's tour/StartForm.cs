using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Knight_s_tour
{
    /// <summary>
    /// Форма настройки и запуска
    /// </summary>
    public partial class StartForm : Form
    {
        /// <summary>
        /// Запуск формы
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Успешное закрытие формы по нажатию на "OK" 
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Аргументы события</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            int BoardWidth = 0, BoardHeight = 0;

            #region Проверка на валидность входных данных
            if (Regex.Match(txbBoardWidth.Text, @"[0-9]").Success)
                BoardWidth = int.Parse(txbBoardWidth.Text, NumberStyles.Integer);
            else
            {
                MessageBox.Show("Неверно введена ширина доски! Введите правильное значение!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            if (Regex.Match(txbBoardHeight.Text, @"[0-9]").Success)
                BoardHeight = int.Parse(txbBoardHeight.Text, NumberStyles.Integer);
            else
            {
                MessageBox.Show("Неверно введена высота доски! Введите правильное значение!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            #endregion

            if (BoardWidth != 0 && BoardHeight != 0)
            {
                var parent = (MainForm) this.Owner;
                parent.DrawBoard(BoardWidth, BoardHeight);
            }
            else
            {
                MessageBox.Show("Неверно введена высота доски! Введите правильное значение!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
