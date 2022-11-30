using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.classess
{
    class Game : ObservableObject
    {
        private bool playing;

        public bool IsPlaying
        {
            get { return playing; }
            set { SetProperty(ref playing, value); }
        }

        private Question currQuestion;

        public Question CurrQuestion
        {
            get { return currQuestion; }
            set { SetProperty(ref currQuestion, value); }
        }

        private ObservableCollection<Question> questionList;

        public ObservableCollection<Question> QuestionList
        {
            get { return questionList; }
            set { SetProperty(ref questionList, value);  }
        }

        private Boolean[] categoryList;

        public Boolean[] CategoryList
        {
            get { return categoryList; }
            set { SetProperty(ref categoryList, value); }
        }




        public Game(bool isPlaying, Question currQuestion, ObservableCollection<Question> questionList)
        {
            IsPlaying = isPlaying;
            CurrQuestion = currQuestion;
            QuestionList = questionList;
            CategoryList = new bool[5]{false, false, false, false, false};
            
        }




    }
}
