using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.classess
{
    class Question : ObservableObject
    {
        private string questionText;

        public string QuestionText
        {
            get { return questionText; }
            set { SetProperty(ref questionText, value); }
        }


        private string correctAns;

        public string CorrectAns
        {
            get { return correctAns; }
            set { SetProperty(ref correctAns, value); }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        private string dificulty;

        public string Dificulty
        {
            get { return dificulty; }
            set { SetProperty(ref dificulty, value); }
        }

        public Question(string questionText, string correctAns, string category, string image, string dificulty)
        {
            QuestionText = questionText;
            CorrectAns = correctAns;
            Category = category;
            Image = image;
            Dificulty = dificulty;
        }

        public Question()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(QuestionText)}={QuestionText}, {nameof(CorrectAns)}={CorrectAns}, {nameof(Category)}={Category}, {nameof(Image)}={Image}, {nameof(Dificulty)}={Dificulty}}}";
        }
    }
}
