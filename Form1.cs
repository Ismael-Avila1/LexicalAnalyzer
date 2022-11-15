namespace LexicalAnalyzer
{
    public partial class Form1 : Form
    {
        List<Element> elements;

        public Form1()
        {
            InitializeComponent();
            elements = new List<Element>();
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            List<string> strings = new List<string>();

            for(int i=0; i<textBoxInput.Lines.Length; i++)
                strings.Add(textBoxInput.Lines[i] + "$");

            for(int i = 0; i < strings.Count; i++)
                analyze(strings[i]);
        }

        void analyze(string s)
        {
            int state = 0;
            string lexeme = "", token = "error";

            for(int i=0; i<s.Length; i++) {
                switch(state) {
                    case 0:
                        if(s[i] == ' ')
                            state = 0;
                        else if(Char.IsLetter(s[i]) || s[i] == '_') {
                            state = 1;
                            lexeme += s[i];
                            token = "id";
                        }
                        else if(char.IsDigit(s[i])) {
                            state = 2;
                            lexeme += s[i];
                            token = "Numero";
                        }
                        else if(s[i] == ';') {
                            elements.Add(new Element(s[i].ToString(), "Punto y coma", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == ',') {
                            elements.Add(new Element(s[i].ToString(), "Coma", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == '(') {
                            elements.Add(new Element(s[i].ToString(), "Parentesis Izq", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == ')') {
                            elements.Add(new Element(s[i].ToString(), "Parentesis Der", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == '{') {
                            elements.Add(new Element(s[i].ToString(), "Llave Izq", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == '}') {
                            elements.Add(new Element(s[i].ToString(), "Llave Der", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == '$') {
                            elements.Add(new Element(s[i].ToString(), "Pesos", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == '!') {
                            state = 11;
                            lexeme += s[i];
                            token = "OpRelacional";
                        }
                        else if(s[i] == '>') {
                            state = 13;
                            lexeme += s[i];
                            token = "OpRelacional";
                        }
                        else if(s[i] == '<') {
                            state = 15;
                            lexeme += s[i];
                            token = "OpRelacional";
                        }
                        else if(s[i] == '=') {
                            state = 17;
                            lexeme += s[i];
                            token = "Asignacion";
                        }
                        else if(s[i] == '|') {
                            state = 19;
                            lexeme += s[i];
                            token = "OpLogico";
                        }
                        else if(s[i] == '&') {
                            state = 21;
                            lexeme += s[i];
                            token = "OpLogico";
                        }
                        else if(s[i] == '+' || s[i] == '-') {
                            elements.Add(new Element(s[i].ToString(), "OpSuma", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else if(s[i] == '*' || s[i] == '/') {
                            elements.Add(new Element(s[i].ToString(), "OpMultiplicacion", 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }

                        break;


                    case 1:
                        if(Char.IsDigit(s[i]) || Char.IsLetter(s[i]) || s[i] == '_') {
                            state = 1;
                            lexeme += s[i];
                            token = "id";
                        }
                        else {
                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 2:
                        if(Char.IsDigit(s[i])) {
                            state = 2;
                            lexeme += s[i];
                            token = "Numero";
                        }
                        else if(s[i] == '.') {
                            state = 3;
                            lexeme += s[i];
                            token = "Numero";
                        }
                        else {
                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 3:
                        if(Char.IsDigit(s[i])) {
                            state = 3;
                            lexeme += s[i];
                            token = "Numero";
                        }
                        else {
                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 11:
                        if(s[i] == '=') {
                            lexeme += s[i];
                            token = "OpRelacional";

                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 13:
                        if(s[i] == '=') {
                            lexeme += s[i];
                            token = "OpRelacional";

                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 15:
                        if(s[i] == '=') {
                            lexeme += s[i];
                            token = "OpRelacional";

                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 17:
                        if(s[i] == '=') {
                            lexeme += s[i];
                            token = "OpRelacional";

                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        else {
                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 19:
                        if(s[i] == '|') {
                            lexeme += s[i];
                            token = "OpLogico";

                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;


                    case 21:
                        if(s[i] == '&') {
                            lexeme += s[i];
                            token = "OpLogico";

                            elements.Add(new Element(lexeme, token, 0));

                            state = 0;
                            lexeme = "";
                            token = "";
                        }
                        break;
                }
                
            }
            
        }



    }
}