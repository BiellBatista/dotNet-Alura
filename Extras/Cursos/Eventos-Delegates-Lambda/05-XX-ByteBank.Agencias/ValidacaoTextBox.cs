﻿using System.Windows.Controls;
using System.Windows.Media;

namespace _05_XX_ByteBank.Agencias
{
    public delegate bool ValidacaoEventHandler(string texto);

    public class ValidacaoTextBox : TextBox
    {
        /**
         * Devo criar um campo privado do tipo ValidacaoEventHandler, para que eu possa manipular as ações de adicionar e remover evento
         */
        private ValidacaoEventHandler _validacao;

        public event ValidacaoEventHandler Validacao
        {
            add
            {
                _validacao += value;
                OnValidacao();
            }
            remove
            {
                _validacao -= value;
            }
        }

        public ValidacaoTextBox()
        {
            TextChanged += ValidacaoTextBox_TextChanged;
        }

        private void ValidacaoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnValidacao();
        }

        private void OnValidacao()
        {
            if (_validacao != null)
            {
                var ehValido = _validacao(Text);
                Background = ehValido
                ? new SolidColorBrush(Colors.White)
                : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
