using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalLaboratoryN20.Util
{
    class Captcha
    {
        private List<char> _chars;
        public Captcha()
        {
            InitChars();
            Generate();

        }

        private void InitChars()
        {
            _chars = new List<char>();
            for (int i = 48; i < 58; i++)//цифры 48-58 буквы 65-90
            {
                _chars.Add((char)i);
            }

            for (int i = 65; i < 91; i++)//цифры 48-57 буквы 65-91
            {
                _chars.Add((char)i);
            }
        }

        public void Generate()
        {
            var strb = new StringBuilder();
            var rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                strb.Append(_chars[rnd.Next(0, _chars.Count)]);
            }

            Value = strb.ToString();
        }

        public string Value { get; private set; }

    }
}
