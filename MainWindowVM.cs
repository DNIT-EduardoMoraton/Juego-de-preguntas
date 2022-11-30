using CommunityToolkit.Mvvm.ComponentModel;
using Juego_de_preguntas.classess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas
{
    class MainWindowVM: ObservableObject
    {
        private Game currGame;

        public Game CurrGame
        {
            get { return currGame; }
            set { SetProperty(ref currGame, value); }
        }

            
        private Question addCurrQuestion;

        public Question AddCurrQuestion
        {
            get { return addCurrQuestion; }
            set { SetProperty(ref addCurrQuestion, value); }
        }

        private Question editCurrQuestion;

        public Question EditCurrQuestion
        {
            get { return editCurrQuestion; }
            set { SetProperty(ref editCurrQuestion, value); }
        }

        private ObservableCollection<Question> currQuestionList;

        public ObservableCollection<Question> CurrQuestionList
        {
            get { return currQuestionList; }
            set { SetProperty(ref currQuestionList, value); }
        }

        private ObservableCollection<string> categories;

        public ObservableCollection<string> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

        public MainWindowVM()
        {
            currQuestionList = new ObservableCollection<Question>();
            EditCurrQuestion = null;
            AddCurrQuestion = null;
            CurrGame = new Game(false, null, null);
            Categories = new ObservableCollection<string> { "Arte y literatura", "Historia", "Deportes", "Ciencia", "Deportes" };
        }



    }
}
